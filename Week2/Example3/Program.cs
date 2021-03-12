using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Example2
{

    class Layer
    {
        public DirectoryInfo dir
        {
            get;
            set;
        }
        public int pos
        {
            get;
            set;
        }
        public List<FileSystemInfo> content
        {
            get;
            set;
        }

        public Layer(DirectoryInfo dir, int pos)
        {
            this.dir = dir;
            this.pos = pos;
            this.content = new List<FileSystemInfo>();



            content.AddRange(this.dir.GetDirectories());
            content.AddRange(this.dir.GetFiles());
        }

        public void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            int cnt = 0;
            foreach (DirectoryInfo d in dir.GetDirectories())
            {

                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                DateTime creationTime = d.CreationTime;

                long size = 0;
                foreach (FileInfo fi in d.GetFiles())
                {

                    size += fi.Length;
                }
                Console.WriteLine(d.Name + "     |  " + size + " bytes  |  Created: " + creationTime);

                cnt++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (FileInfo f in dir.GetFiles())
            {

                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                DateTime creationTime = f.CreationTime;

                Console.WriteLine(f.Name + "     |  " + f.Length + " bytes  |  Created: " + creationTime);
                cnt++;
            }
        }

        public void OpenFile(string path, string extension, bool isFile)
        {
   
           
            if (extension == ".txt")
            {
                StreamReader sr = new StreamReader(path);
                Console.WriteLine(sr.ReadToEnd());
                    
                //string readFile = File.ReadAllText(path);
                //Console.WriteLine(readFile);
            }
            else Console.WriteLine("Sorry, can not open file");
               

            
            
          
        }

        public FileSystemInfo GetCurrentObject()
        {
            return content[pos];
        }

        public void SetNewPosition(int d)
        {
            if (d > 0)
            {
                pos++;
            }
            else
            {
                pos--;
            }
            if (pos >= content.Count)
            {
                pos = 0;
            }
            else if (pos < 0)
            {
                pos = content.Count - 1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void F3()
        {

            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(new DirectoryInfo(@"C:\Users\админ\Documents\rktko"), 0));

            bool escape = false;
            bool isFile = false;

            while (!escape)
            {
                Console.Clear();

                history.Peek().PrintInfo();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (history.Peek().GetCurrentObject().GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(new Layer(history.Peek().GetCurrentObject() as DirectoryInfo, 0));
                        }
                        else if (history.Peek().GetCurrentObject().GetType() == typeof(FileInfo))
                        {
                            isFile = true;
                            history.Peek().OpenFile(history.Peek().GetCurrentObject().FullName, history.Peek().GetCurrentObject().Extension, isFile);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SetNewPosition(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SetNewPosition(1);
                        break;
                    case ConsoleKey.Escape:
                        history.Pop();
                        break;
                }
            }
        }

        private static void F2()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape) break;
                Console.WriteLine(consoleKeyInfo.KeyChar);
            }
        }

        private static void F1()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine(consoleKeyInfo);
        }
    }
}
