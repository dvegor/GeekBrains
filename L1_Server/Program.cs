    using System.Net;
    using System.Net.Sockets;

namespace L1_Server
{
        internal class Program
        {
            static async Task Main(string[] args)
            {
                var server = new ChatServer();
                await server.Run();
            }
        }
        public class ChatServer
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 55555);
            public async Task Run()
            {
                try
                {
                    listener.Start();
                    await Console.Out.WriteLineAsync("Запущен");

                    while (true)
                    {
                        var tcpClient = await listener.AcceptTcpClientAsync();
                        Console.WriteLine("Успешно подключен");

                        Task.Run(() => ProcessClient(tcpClient));
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync($"Error: {ex.Message}");
                }

            }
            public async Task ProcessClient(TcpClient client)
            {
                var reader = new StreamReader(client.GetStream());
                var messege = await reader.ReadLineAsync();
                Console.WriteLine(messege);
            }
        }
    }