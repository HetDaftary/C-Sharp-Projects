using System;
using System.IO;

namespace DirectoryTree
{
    class Program
    {
        private static readonly string depthString = "--";

        /**
         * @breif Recursive helper for the printDirectoryTree.
         * @param path: path to print.
         * @param depth: level of sub folders.
      
         */
        private static void directoryTreeHelper(string path, int depth)
        {
            string[] contentFiles = Directory.GetFiles(path);
            string[] contentDirectory = Directory.GetDirectories(path);
            int i;

            // for is for the int i = 0 to n type of loops.
            foreach(string file in contentFiles)
            {
                for (i = 0; i < depth; i++)
                {
                    Console.Write(depthString);
                }
                Console.WriteLine(file);
            }

            foreach(string dir in contentDirectory)
            {
                for (i = 0; i < depth; i++)
                {
                    Console.Write(depthString);
                }
                Console.WriteLine(dir);
                directoryTreeHelper(dir, depth + 1);
            }
        }

        /**
         * @breif A function to print the directory tree for given path.
         * @param path: Path to print.
         */
        static void printDirectoryTree(string path)
        {
            directoryTreeHelper(path, 0);
        }

        static void Main(string[] args)
        {
            printDirectoryTree(".");
        }
    }
}
