using System;

namespace AdvanceTopics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main starts");

            Publisher publisher = new Publisher();
            Consumer consumer = new Consumer();

            publisher.ProductAdded += consumer.OnProductAdded;

            publisher.AddProduct("Lenovo T440");
        }
    }
}
