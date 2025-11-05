using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadCsharp
{
    internal class WorkConsole
    {
        public int InstanceNumber { private get; set; }
        public Mutex mutex { get; internal set; }
        public int Couleur { get; set; }

        public WorkConsole()
        {
            InstanceNumber = 0;
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                //
                string toWrite = "Thread " + InstanceNumber.ToString();
                //
                mutex.WaitOne();
                //
                Console.ForegroundColor = (ConsoleColor)Couleur;
                Console.WriteLine(toWrite);
                mutex.ReleaseMutex();
            }

        }
    }
}
