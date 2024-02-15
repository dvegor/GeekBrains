using System.Net.Sockets;
using System.Security;

namespace L1_Client1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            Thread.Sleep(1000);
            tcpClient.Connect("127.0.0.1", 55555);

            Console.ReadLine();
        }
    }
}