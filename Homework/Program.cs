namespace Homework
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Client.Run();
            Console.ReadKey();
        }
    }
}
