using NetMQ;
using NetMQ.Sockets;

namespace Homework
{
    internal class Client
    {
        public static async Task Run()
        {
            Console.WriteLine("Введите имя:");
            string? name = Console.ReadLine();
            if (name == null)
                name = new Guid().ToString();

            Console.WriteLine("Укажите порт:");
            using (var reciever = new PullSocket($"@tcp://127.0.0.1:{Console.ReadLine()}"))
            using (var sender = new PushSocket($">tcp://127.0.0.1:{Console.ReadLine()}"))
            {
                Task tSender = new Task(() =>
                {
                    try
                    {
                        while (true)
                        {
                            sender.SendFrame(name + ": " + Console.ReadLine());
                        }
                    }
                    catch (Exception es)
                    {

                        Console.WriteLine(es.Message);
                    }

                });
                tSender.Start();

                Task tReciever = new Task(() =>
                {
                    try
                    {
                        while (true)
                        {
                            string fromServerMessage = reciever.ReceiveFrameString();
                            Console.WriteLine(fromServerMessage);
                        }
                    }
                    catch (Exception es)
                    {

                        Console.WriteLine(es.Message);
                    }
                });
                tReciever.Start();

                tSender.Wait();
                tReciever.Wait();
            }
        }
    }
}