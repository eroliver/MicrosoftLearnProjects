using System;
using System.IO;
using System.Collections.Generic;



namespace WorkingWithFiles
{
    public class Class1
    {
        
        IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
            {
                // The file name will contain the full path, so only check the end of it
                if (file.EndsWith("sales.json"))
                {
                    salesFiles.Add(file);
                }
            }

            return salesFiles;
        }

        public void GetFiles()
        {
            var salesFiles = FindFiles("stores");

            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }
        }

    }
}
