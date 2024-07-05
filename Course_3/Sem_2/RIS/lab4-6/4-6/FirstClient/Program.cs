using DatabaseClasses.Pattern;
using Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FirstClient
{
    class Program
    {
        static string ip = "192.168.43.137";
        static void Main(string[] args)
        {
            Console.WriteLine("Начало работы: первый клиент");
            GetRequestFromServerForData();
            GetRequestFromServerForState();
            //----------------------------------------------------
            while (true)
            {

            }
        }

        async public static void GetRequestFromServerForData()
        {
            await Task.Run(() => {
                while (true)
                {
                    try
                    {
                        int port = 2001;
                        IPEndPoint ipPoint = new(IPAddress.Parse(ip), port);
                        Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                        socket.Connect(ipPoint);
                        
                        
                        byte[] inMessage = new byte[256];
                        int getBytes = 0;
                        do
                        {
                            Console.WriteLine("Ожидание ответа с данными от второго клиента...");
                            getBytes = socket.Receive(inMessage);

                        } while (socket.Available > 0);

                        byte[] onlyGoodData = new byte[getBytes];
                        for (int i = 0; i < getBytes; i++)
                        {
                            onlyGoodData[i] = inMessage[i];
                        }

                        Data data = JsonSerializer.Deserialize<Data>(onlyGoodData);

                        Console.WriteLine("Данные от сервера-----------------------\n"
                                        + "id: " + data.CreatorNumber + " Time: " + data.Time + "\n"
                                        + "------------------------------------------------");

                        using (UnitOfWork unitOfWork = new UnitOfWork("FirstDB"))
                        {
                            Console.WriteLine("Запись только что полученных данных от второго клиента в первую бд...");
                            unitOfWork.DataRepository.AddItem(data);
                            unitOfWork.Save();
                        }

               
                        //-------------------------------------------------------

                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();

                        Thread.Sleep(2000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });



        }

        async public static void GetRequestFromServerForState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        int port = 2003;
                        IPEndPoint ipPoint = new(IPAddress.Parse(ip), port);
                        Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                        socket.Connect(ipPoint);
                        //Request zone-------------------------------------------
                                                StringBuilder request = new();
                                                byte[] inMessage = new byte[256];
                                                int getByte = 0;
                                                do
                                                {
                                                    Console.WriteLine("\nFOR STATE: Ожидание запроса на получение состояния от сервера...");
                                                    getByte = socket.Receive(inMessage);
                                                    request.Append(Encoding.Default.GetString(inMessage));
                        
                                                } while (socket.Available > 0);
                                                //-------------------------------------------------------
                        
                                                //Response zone------------------------------------------
                                                byte[] outMessage;
                                                int sendBytes = 0;
                        
                                                Console.WriteLine("FOR STATE: Анализ состояния...");
                                                outMessage = Encoding.Default.GetBytes(FirstListWork.GetLength().ToString());
                        
                                                Console.WriteLine("FOR STATE: Отправка серверу ответа с состоянием...");
                                                sendBytes = socket.Send(outMessage);
                                                //-------------------------------------------------------
                        
                                                socket.Shutdown(SocketShutdown.Both);
                                                socket.Close();
                        
                                                Thread.Sleep(2000);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                    });
                        
                        
                                }
                        
                                async public static void ReceiveDataAndInsertIntoDB()
                                {
                                    await Task.Run(() =>
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                // Создание сокета и подключение к серверу
                                                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                                serverSocket.Connect(IPAddress.Parse("192.168.43.137"), 2000); // IP и порт сервера
                        
                                                // Запрос данных у сервера
                                                byte[] requestBytes = Encoding.UTF8.GetBytes("GetData");
                                                serverSocket.Send(requestBytes);
                        
                                                // Получение данных от сервера
                                                byte[] dataBytes = new byte[1024];
                                                int bytesRead = serverSocket.Receive(dataBytes);
                        
                                                // Преобразование данных в строку JSON
                                                string jsonData = Encoding.UTF8.GetString(dataBytes, 0, bytesRead);
                        
                                                // Десериализация JSON в объект Data
                                                Data receivedData = JsonSerializer.Deserialize<Data>(jsonData);
                        
                                                // Вставка данных в базу данных FirstDB
                                                using (UnitOfWork unitOfWork = new UnitOfWork("FirstDBConnect"))
                                                {
                                                    unitOfWork.DataRepository.AddItem(receivedData);
                                                    unitOfWork.Save();
                                                    Console.WriteLine("Данные вставлены в FirstDB.");
                                                }
                        
                                                // Вставка данных в базу данных SecondDB
                                                using (UnitOfWork unitOfWork = new UnitOfWork("SecondDBConnect"))
                                                {
                                                    unitOfWork.DataRepository.AddItem(receivedData);
                                                    unitOfWork.Save();
                                                    Console.WriteLine("Данные вставлены в SecondDB.");
                                                }
                        
                                                // Закрытие соединения с сервером
                                                serverSocket.Shutdown(SocketShutdown.Both);
                                                serverSocket.Close();

                        // Засыпаем на 2 секунды перед получением следующих данных
                                                Thread.Sleep(2000);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"Error: {ex.Message}");
                                            }
                                        }
                                    });
                                }
                        
                        
                        
                            }
                        }
