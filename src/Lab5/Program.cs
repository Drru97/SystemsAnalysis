using System;

namespace Lab5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var manager = new DijkstraManager();

            try
            {
                manager.InputData();
                manager.Calculate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
