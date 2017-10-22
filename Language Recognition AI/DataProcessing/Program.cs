using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Properties.Resources.DSL_DEV.Split('\n');

            string[] temp = { "bs", "id", "pt-PT", "pt-BR", "fr-CA", "fr-FR" };
            List<string> languages = new List<string>(temp);

            foreach (string line in data)
            {
                string[] cur = line.Split('\t');

                if (cur.Length == 2)
                {
                    if (languages.Contains(cur[1]))
                    {

                    }
                }
            }


            foreach (var item in languages)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("Hello World!");
        }
    }
}
