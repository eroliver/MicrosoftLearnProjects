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

        var salesFiles = FindFiles(storesDirectory);

        var salesTotal = CalculateSalesTotal(salesFiles);

        File.AppendAllText(Path.Combine(salesTotalDirectory, "totals.txt"), $"{salesTotal}{Environment.NewLine}");


        IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
            
            foreach (var file in foundFiles)
            {
                var extension = Path.GetExtension(file);
                if (extension == ".json")
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

            return salesTotal;
        }
    }
}

