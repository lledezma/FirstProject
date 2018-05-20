using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Firstproject
{
    class MainClass
    {

        public class Worker
        {
            bool _shouldStop;
            public void DoWork()
            {
                bool isPrime = true;


                Console.WriteLine("Prime Numbers are: ");

                for (int i = 2; i < 100; i++)
                {
                    for (int j = 2; j < 100; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            Thread.Sleep(500);
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        Console.Write(i + "\n");
                    }
                    isPrime = true;
                }

            }
            public void RequestStop()
            {
                _shouldStop = true;
            }

            public void Summation()
            {
                int n = 100;
                int sum = 0;

                for (int c = 0; c <= n; c++)
                {
                    sum = sum + c;
                    Console.WriteLine(sum);
                    Thread.Sleep(500);
                }

            }
        }

        // this is just a comment
        class Program
        {
            static void Main(string[] args)
            {
                Worker workerObject = new Worker();
                Thread workerThread = new Thread(workerObject.DoWork);
                Thread summationThread = new Thread(workerObject.Summation);

                workerThread.Start();
                Console.WriteLine("main thread: Starting worker thread...");

                // Loop until worker thread activates.
                while (!workerThread.IsAlive) ;

                // Put the main thread to sleep for 1 millisecond to allow the worker thread to do some work:
                Thread.Sleep(5000);

                // Request that the worker thread stop itself:
                workerObject.RequestStop();

                // Use the Join method to block the current thread until the object's thread terminates.
                workerThread.Join();
                Console.WriteLine("main thread: Worker thread has terminated.\n");



                //START SECOND THREAD
                summationThread.Start();
                Console.WriteLine("Second thread: Starting worker thread...");

                // Loop until worker thread activates.
                while (!summationThread.IsAlive) ;

                // Put the main thread to sleep for 1 millisecond to allow the worker thread to do some work:
                Thread.Sleep(5000);

                // Request that the worker thread stop itself:
                workerObject.RequestStop();

                // Use the Join method to block the current thread until the object's thread terminates.
                summationThread.Join();
                Console.WriteLine("Secondthread: Worker thread has terminated.\n");

            }
        }
    }
}