using System;
using System.Threading;

namespace ThreadCsharp
{
    internal class WorkConsole
    {
        public int InstanceNumber { get; set; }
        public int Couleur { get; set; } = 7; 
        public Mutex? Mutex { get; set; }

        public void Run()
        {
            if (Mutex == null) return;

            for (int i = 0; i < 50; i++)
            {
                Mutex.WaitOne();
                try
                {
                    Console.ForegroundColor = (ConsoleColor)Couleur;
                    Console.WriteLine($"Thread {InstanceNumber} - {i + 1}");
                    Console.ResetColor();
                }
                finally
                {
                    Mutex.ReleaseMutex();
                }

                Thread.Sleep(1);
            }
        }
    }
}
