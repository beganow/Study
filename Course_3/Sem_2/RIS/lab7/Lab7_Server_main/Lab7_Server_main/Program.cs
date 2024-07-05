using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Program
{
    private static UdpClient server;
    private static IPEndPoint endPoint;
    private static string mainServer = "192.168.43.137";
    private static string localServer = "192.168.1.138";
    private static string coordinator = null;
    private static List<IPEndPoint> awaitingClients = new List<IPEndPoint>();

    public static void Main()
    {
        server = new UdpClient(7777);
        endPoint = new IPEndPoint(IPAddress.Parse(mainServer), 5555);

        while (true)
        {
            var remoteEP = new IPEndPoint(IPAddress.Any, 0);
            var data = server.Receive(ref remoteEP);
            var message = Encoding.ASCII.GetString(data);
            var obj = JsonConvert.DeserializeObject<dynamic>(message);

            if (obj.command == Commands.Get)
            {
                if (coordinator != null)
                {
                    var paramsToSend = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { command = Commands.Get }));
                    server.Send(paramsToSend, paramsToSend.Length, new IPEndPoint(IPAddress.Parse(coordinator), 5555));
                    awaitingClients.Add(remoteEP);
                }
                else
                {
                    Console.WriteLine("Coordinator not initialised");
                }
            }
            else if (obj.command == Commands.Connect)
            {
                coordinator = obj.ip;
                Console.WriteLine($"Coordinator: {coordinator}");
            }
            else if (obj.command == Commands.Time)
            {
                if (awaitingClients.Count > 0)
                {
                    foreach (var client in awaitingClients)
                    {
                        server.Send(data, data.Length, client);
                    }
                    awaitingClients.Clear();
                }
            }
        }
    }
}

public static class Commands
{
    public const string Get = "get";
    public const string Connect = "connect";
    public const string Time = "time";
}
