using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadCsharp
{
    internal class Work
    {
        public int InstanceNumber { private get; set; }
        public StreamWriter fichier { private get; set; }
        public Mutex mutex { get; internal set; }

        public Work()
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
                char[] buffer = new char[toWrite.Length + 2];
                toWrite.CopyTo(0, buffer, 0, toWrite.Length);
                buffer[buffer.Length - 2] = '\r';
                buffer[buffer.Length - 1] = '\n';
                //
                mutex.WaitOne();
                //
                fichier.Write(buffer);
                mutex.ReleaseMutex();
            }

        }
    }
}
