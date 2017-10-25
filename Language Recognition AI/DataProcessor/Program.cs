using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allowed = new List<string>
            {
                "deu",
                "rus",
                "fra",
                "eng",
                "ita",
                "epo",
                "spa",
                "por",
            };

            var csv = new StringBuilder();

            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\sentences.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] x = line.Split('\t');

                if (allowed.Contains(x[1]))
                {
                    var taal = x[1];
                    var text = x[2];

                    var newline = string.Format("{0}\t{1}", taal, text);

                    csv.AppendLine(newline);
                }
            }

            file.Close();

            File.WriteAllText(@"c:\Users\Epeirios\Desktop\new\sentences.cvs", csv.ToString());

            System.Console.ReadLine();
        }
    }
}
