using System;
using System.Collections.Generic;
using System.Threading;

public static class Database
{

}

public class ProducerConsumner
{
    static Queue<string> queue = new Queue<string>();
    static SemaphoreSlim semaphore = new SemaphoreSlim(0);

    static readonly object consumerLock = new object();

    static readonly object producerLock = new object();

    public void Producer(string item)
    {
        lock (producerLock)
        {
            queue.Enqueue(item);
            semaphore.Release();
            System.Console.WriteLine("Producer enqueue {0}", item);
            System.Console.WriteLine("Producer counter = {0}", semaphore.CurrentCount);
            //Thread.Sleep(10);
        }
    }

    public void Consumer()
    {
        while (true)
        {
            lock (consumerLock)
            {
                semaphore.Wait();
                string item = queue.Dequeue();
                System.Console.WriteLine("Consumer dequeue {0}", item);
                System.Console.WriteLine("Consumer counter = {0}", semaphore.CurrentCount);
                Thread.Sleep(10);
            }
        }
    }
}