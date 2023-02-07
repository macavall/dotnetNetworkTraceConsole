namespace deleteconsole563
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var semaphore = new SemaphoreSlim(10);

            var tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                await semaphore.WaitAsync();

                tasks.Add(MyMethod().ContinueWith((t) => semaphore.Release()));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine();
        }
        
        public static async Task MyMethod()
        {
            await Task.Delay(6000);
            Console.WriteLine("");
        }
    }
}