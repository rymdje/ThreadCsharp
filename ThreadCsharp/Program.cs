namespace TestThread1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Démarrage de l'application...");
            Console.WriteLine("1- Ecriture Ecran");
            Console.WriteLine("2- Ecriture Fichier");
            Console.WriteLine("Votre choix : ");
            string choix = Console.ReadLine();
            if (choix == "1")
                ConsoleWork();
            else
                FichierWork();
            Console.WriteLine("====================== Fin du Logiciel ====================");

        }

        private static void ConsoleWork()
        {
            Mutex mutex = new Mutex();
            int couleur = 1;
            for (int i = 0; i < 50; i++)
            {
                WorkConsole work = new WorkConsole();
                work.InstanceNumber = i;
                work.Couleur = couleur;
                work.mutex = mutex;

                Thread thread = new Thread(work.Run);
                thread.Start();
                //
                couleur++;
                if (couleur > 15)
                    couleur = 1;
            }
        }

        private static void FichierWork()
        {
            StreamWriter fichier = new StreamWriter("test.txt");
            Mutex mutex = new Mutex();

            for (int i = 0; i < 50; i++)
            {
                Work work = new Work();
                work.InstanceNumber = i;
                work.fichier = fichier;
                work.mutex = mutex;

                Thread thread = new Thread(work.Run);
                thread.Start();
                //
            }
        }
    }
}
