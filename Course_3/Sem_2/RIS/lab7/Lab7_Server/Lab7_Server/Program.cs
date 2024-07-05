using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Commands
{
    public static string Hello { get { return "hello"; } }
    public static string HelloResponse { get { return "helloResponse"; } }
    public static string Voting { get { return "voting"; } }
    public static string Ok { get { return "ok"; } }
    public static string Won { get { return "won"; } }
    public static string Run { get { return "run"; } }
    public static string Cancel { get { return "cancel"; } }
    public static string Ping { get { return "ping"; } }
    public static string Pong { get { return "pong"; } }
    public static string Get { get { return "get"; } }
    public static string Connect { get { return "connect"; } }
    public static string Time { get { return "time"; } }
}

class Program
{
    private static UdpClient server;
    private static int port = 5555;
    private static HashSet<string> servers = new HashSet<string>();
    private static Timer timerWaitRejects;
    private static Timer timerWaitPong;
    private static Timer timerIntervalPing;
    private static string addressLocal;
    private static string lastOctet;
    private static string coordinator = null;
    private static int timeOut = 10000;
    private static readonly string mainServer = "192.168.43.137";
    private static readonly string localServer = "192.168.43.195";

    static void Main(string[] args)
    {
        server = new UdpClient(port);
        server.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        addressLocal = localServer;
        lastOctet = addressLocal.Split('.')[3];
        Console.WriteLine("Server is listening at port: " + port);
        Console.WriteLine("Server ip: " + addressLocal);
        Voting();
        while (true) { }
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
        byte[] bytes = server.EndReceive(ar, ref remoteEP);
        string data = Encoding.ASCII.GetString(bytes);
        Console.WriteLine("Data received from client : " + data);
        Console.WriteLine("Received {0} bytes from {1}:{2}", data.Length, remoteEP.Address.ToString(), remoteEP.Port);

        dynamic msg = Newtonsoft.Json.JsonConvert.DeserializeObject(data);

        if (msg.command == Commands.Voting)
        {
            Reject(remoteEP);
            Voting();
        }
        else if (msg.command == Commands.Ok)
        {
            WaitResponses(Commands.Cancel);
        }
        else if (msg.command == Commands.Won)
        {
            SetCoordinator(remoteEP.Address.ToString());
            timerIntervalPing.Change(Timeout.Infinite, Timeout.Infinite);
            timerIntervalPing = new Timer(state => PingCoordinator(remoteEP), null, 0, timeOut);
        }
        else if (msg.command == Commands.Ping)
        {
            Ping(remoteEP);
        }
        else if (msg.command == Commands.Pong)
        {
            Pong(remoteEP);
        }
        else if (msg.command == Commands.Get)
        {
            SendTime();
        }
        else if (msg.command == Commands.Hello)
        {
            HandleHello(remoteEP);
        }
        else if (msg.command == Commands.HelloResponse)
        {
            HandleHelloResponse(remoteEP);
        }
        server.BeginReceive(new AsyncCallback(ReceiveCallback), null);
    }

    private static void HandleHello(IPEndPoint remoteEP)
    {
        Console.WriteLine("Handle hello to " + remoteEP.Address.ToString());

        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.HelloResponse });
        byte[] responseBytes = Encoding.ASCII.GetBytes(paramsJson);
        server.Send(responseBytes, responseBytes.Length, remoteEP);
    }

    private static void HandleHelloResponse(IPEndPoint remoteEP)
    {
        Console.WriteLine("Hello response from " + remoteEP.Address.ToString());
        if (!servers.Contains(remoteEP.Address.ToString()) && remoteEP.Address.ToString() != localServer)
        {
            Console.WriteLine("Add new server " + remoteEP.Address.ToString());
            servers.Add(remoteEP.Address.ToString());
            Voting();
        }
    }

    private static void Voting()
    {
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Voting });

        foreach (string address in servers)
        {
            if (int.Parse(lastOctet) < int.Parse(address.Split('.')[3]))
            {
                server.Send(Encoding.ASCII.GetBytes(paramsJson), paramsJson.Length, address, port);
                Console.WriteLine("vote sent : " + address);
            }
        }
        if (timerIntervalPing != null)
        {
            timerIntervalPing.Change(Timeout.Infinite, Timeout.Infinite);
        }

        WaitResponses(Commands.Run);
    }

    private static void Reject(IPEndPoint remoteEP)
    {
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Ok });
        byte[] responseBytes = Encoding.ASCII.GetBytes(paramsJson);
        server.Send(responseBytes, responseBytes.Length, remoteEP);
        Console.WriteLine("ok sent : " + remoteEP.Address.ToString());
    }

    private static void WaitResponses(string command)
    {
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Won });

        if (Commands.Run == command)
        {
            timerWaitRejects = new Timer(state =>
            {
                SetCoordinator(addressLocal);
                foreach (string address in servers)
                {
                    server.Send(Encoding.ASCII.GetBytes(paramsJson), paramsJson.Length, address, port);
                    Console.WriteLine("won sent : " + address);
                }
            }, null, 5000, Timeout.Infinite);
        }
        else if (Commands.Cancel == command)
        {
            timerWaitRejects.Dispose();
        }
    }

    private static void PingCoordinator(IPEndPoint remoteEP)
    {
        Console.WriteLine("pingCoordinator");
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Ping });

        server.Send(Encoding.ASCII.GetBytes(paramsJson), paramsJson.Length, remoteEP);
        timerWaitPong = new Timer(state => Voting(), null, 4000, Timeout.Infinite);
    }


    private static void Ping(IPEndPoint remoteEP)
    {
        Console.WriteLine("ping");
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Pong });
        server.Send(Encoding.ASCII.GetBytes(paramsJson), paramsJson.Length, remoteEP);
    }

    private static void Pong(IPEndPoint remoteEP)
    {
        Console.WriteLine("pong");
        timerWaitPong.Change(Timeout.Infinite, Timeout.Infinite);
    }

    private static void SetCoordinator(string ip)
    {
        coordinator = ip;
        Connect();
        Console.WriteLine("set ip " + ip);
    }

    private static void Connect()
    {
        string paramsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Connect, ip = coordinator });

        server.Send(Encoding.ASCII.GetBytes(paramsJson), paramsJson.Length, mainServer, 7777);
        Console.WriteLine("sent connect");
    }

    private static void SendTime()
    {
        string time = Newtonsoft.Json.JsonConvert.SerializeObject(new { command = Commands.Time, time = DateTime.Now.ToString() });

        server.Send(Encoding.ASCII.GetBytes(time), time.Length, mainServer, 7777);
    }
}


