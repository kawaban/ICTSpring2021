using System;
using System.IO;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }

        private static void PrintFolderInfo(string path, string prefix = "")
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            try
            {
                foreach (FileSystemInfo fi in dir.GetFileSystemInfos())
                {
                    Console.WriteLine(prefix + " " + fi.Name);
                    if (fi.GetType() == typeof(DirectoryInfo))
                    {
                        PrintFolderInfo(fi.FullName, prefix + "--");
                    }
                }
            } 
            catch (Exception) { }
            
        }

        private static void F4()
        {
            PrintFolderInfo(@"C:\Users\админ\Documents");
        }
        private static void getFileSystemsNames()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\админ\Documents\National Instruments\Circuit Design Suite 14.0");

            foreach(FileSystemInfo fi in dir.GetFileSystemInfos())
            {
                Console.WriteLine(fi.Name);
            }
        }

        private static void getDirectoriesAndFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\админ\Documents\National Instruments\Circuit Design Suite 14.0");

            foreach(DirectoryInfo d in dir.GetDirectories())
            {
                Console.WriteLine(d.Name);
            }
            foreach (FileInfo f in dir.GetFiles())
            {
                Console.WriteLine(f.Name);
            }
        }

        private static void getDirectoryName()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\админ\Documents\National Instruments\");

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Console.WriteLine(d.FullName);
            }
        }

        private static void getDisksName()
        {
            foreach (string l in Environment.GetLogicalDrives())
            {
                Console.WriteLine(l);
            }
        }

        
    }
}
