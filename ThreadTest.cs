using System;
using System.Threading;

class ThreadTest
{
    public ThreadTest()
    {

    }

    public void Run()
    {
        Thread t = new Thread(Print);
        t.Start();
    }

    private void Print()
    {
        for(int i = 0; i < 1000; i++)
        {
            Console.Write("{0}", 0);
            //Console.WriteLine("Hello World!");
        }
    }
}