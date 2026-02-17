using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreadCsharp
{
    internal class Work
    {
        public int InstanceNumber { get; set; }
        public StreamWriter? Fichier { get; set; }
        public Mutex? Mutex { get; set; }

        public void Run()
        {
            // ptite sécurité
            if (Fichier == null || Mutex == null) return;

            for (int i = 0; i < 100; i++)
            {
                Mutex.WaitOne();
                try
                {
                    Fichier.WriteLine($"Thread {InstanceNumber} - Ligne {i + 1}");
             
                }
                finally
                {
                    Mutex.ReleaseMutex();
                }

                // mini pause pour mélanger les threads
                Thread.Sleep(1);
            }
        }
    }
}
