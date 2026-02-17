using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ThreadCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demarrage de l'application..");
            Console.WriteLine("1 Ecriture ecran");
            Console.WriteLine("2 Ecriture fichier");
            Console.Write("Votre choix : ");

            string? choix = Console.ReadLine();

            if (choix == "1")
                ConsoleWork();
            else if (choix == "2")
                FichierWork();
            else
                Console.WriteLine("Choix invalide.");

            Console.WriteLine(" === Fin du logiciel === ");
            Console.WriteLine("Appuyez sur Entree pour quitter...");
            Console.ReadLine();
        }

        private static void ConsoleWork()
        {
            Mutex mutex = new Mutex();
            List<Thread> threads = new List<Thread>();

            int couleur = 1;

            for (int i = 0; i < 50; i++)
            {
                WorkConsole work = new WorkConsole
                {
                    InstanceNumber = i,
                    Couleur = couleur,
                    Mutex = mutex
                };

                Thread t = new Thread(work.Run);
                threads.Add(t);
                t.Start();

                couleur++;
                if (couleur > 15) couleur = 1;
            }

            // !!! attendre que tous les threads finissent
            foreach (var t in threads)
                t.Join();
        }

        private static void FichierWork()
        {
            Mutex mutex = new Mutex();
            List<Thread> threads = new List<Thread>();

            // using => ça fermera le fichier à la fin de la méthode
            using StreamWriter fichier = new StreamWriter("test.txt");

            for (int i = 0; i < 50; i++)
            {
                Work work = new Work
                {
                    InstanceNumber = i,
                    Fichier = fichier,
                    Mutex = mutex
                };

                Thread t = new Thread(work.Run);
                threads.Add(t);
                t.Start();
            }

            // !!! attendre la fin avant de fermer le fichier
            foreach (var t in threads)
                t.Join();

            // le fichier se ferme auto grâce au using
            Console.WriteLine("Fichier test.txt genere.");
        }
    }
}
