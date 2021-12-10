using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json; 


class Program
{
    static void Main(string[] args)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var storesDirectory = Path.Combine(currentDirectory, "stores");
        var salesTotalDirectory = Path.Combine(currentDirectory, "salesTotalDirectory");
        Directory.CreateDirectory(salesTotalDirectory);

            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }

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

        static extern record SalesData (double Total);

        static double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            foreach (var file in salesFiles)
            {      
                // Read the contents of the file
                string salesJson = File.ReadAllText(file);

                // Parse the contents as JSON
                SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

                // Add the amount found in the Total field to the salesTotal variable
                salesTotal += data?.Total ?? 0;
            }

        }
    }

