using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using Newtonsoft.Json;

namespace Lab7
{
    internal class Client { 

    private static UdpClient client;
    private static IPEndPoint endPoint;
    private static System.Timers.Timer timer;
    private static string mainServer = "192.168.43.137";
    private static string localServer = "192.168.43.137";

    public static void Main()
    {
        client = new UdpClient(9999);
        endPoint = new IPEndPoint(IPAddress.Parse(mainServer), 7777);

        timer = new System.Timers.Timer(3000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;

        while (true)
        {
            var receivedBytes = client.Receive(ref endPoint);
            var receivedData = Encoding.ASCII.GetString(receivedBytes);
            Console.WriteLine($"Data received from server: {receivedData}");
            Console.WriteLine($"Received {receivedBytes.Length} bytes from {endPoint.Address}:{endPoint.Port}\n");
        }
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        var command = new { command = Commands.Get };
        var paramsToSend = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(command));

        client.Send(paramsToSend, paramsToSend.Length, endPoint);
        Console.WriteLine("get time");
    }
}

public static class Commands
{
    public const string Hello = "hello";
    public const string HelloResponse = "helloResponse";
    public const string Voting = "voting";
    public const string Ok = "ok";
    public const string Won = "won";
    public const string Run = "run";
    public const string Cancel = "cancel";
    public const string Ping = "ping";
    public const string Pong = "pong";
    public const string Get = "get";
    public const string Connect = "connect";
    public const string Time = "time";
}
}
