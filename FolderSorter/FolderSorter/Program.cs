using System;
using System.IO;

namespace FolderSorter
{
    class Program
    {
        /**
         * @breif A helper function for foldersorter to recursively move in files.
         * @param path: Current Path
         * @param originalPath: Original Path
         */
        private static void helper(string path, string originalPath)
        {
            string ext, toPlaceAt, f, toMoveAt;
            string[] fileParts;
            foreach (string file in Directory.GetFiles(path, "*.*"))
            {
                f = Path.GetFileName(file);
                fileParts = f.Split('.');
                ext = fileParts[fileParts.Length - 1]; // Last one is the extension.
                toPlaceAt = Path.Join(originalPath, ext);
                if (!Directory.Exists(toPlaceAt))
                {
                    Directory.CreateDirectory(toPlaceAt);
                }
                //Console.WriteLine($"{path}\n{file}");
                toMoveAt = Path.Join(toPlaceAt, f);
                if (file != toMoveAt)
                {
                    Directory.Move(file, toMoveAt);
                }
            }

            foreach (string dir in Directory.GetDirectories(path))
            {
                helper(dir, originalPath);
            }
        }

        /**
         * @breif A function to sort all the files into required folders based on the extension of the files.
         * @param path: The path to sort.
         */
        public static void folderSorter(string path)
        {
            helper(path, path);
        }

        static void Main(string[] args)
        {
            folderSorter("Enter the path you want to sort here.");
            // If path is valid, it will sort it out.
        }
    }
}
