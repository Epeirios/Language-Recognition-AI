using NeuralNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Models
{
    public class NeuralNetworkFacade : IModelFacade
    {
        NeuralNetworkModel neuralNet;
        ValidationReport validationReport;
        char[] chardict;
        int inputnodes;

        public NeuralNetworkFacade(double learningrate, int[] layers, char[] chardict)
        {
            this.neuralNet = new NeuralNetworkModel(learningrate, layers);
            this.validationReport = new ValidationReport();
            this.chardict = chardict;
            this.inputnodes = layers[0];
        }

        public ValidationReport GetValidationReport()
        {
            return validationReport;
        }

        public long TrainModel(LanguageRecords[] languagerecords)
        {
            Stopwatch t = new Stopwatch();
            t.Start();

            foreach (var languagerecord in languagerecords)
            {
                List<double> output = OutputFromLanguage(languagerecord.Language);

                foreach (var record in languagerecord.Records)
                {
                    List<double> input = InputFromString(record, inputnodes);

                    neuralNet.Train(input, output);
                }
            }

            t.Stop();

            return t.ElapsedMilliseconds;
        }

        private List<double> OutputFromLanguage(Languages language)
        {
            List<double> output = new List<double>();

            foreach (Languages item in Enum.GetValues(typeof(Languages)))
            {
                if (item == language)
                {
                    output.Add(100);
                }
                else
                {
                    output.Add(1);
                }
            }

            return output;
        }

        private List<double> InputFromString(string record, int cap)
        {
            int len;
            double[] input = new double[inputnodes];

            if (record.Length > cap || cap != 0)
            {
                len = cap;
            }
            else
            {
                len = record.Length;
            }

            char[] stringchars = record.ToCharArray().Take(len).ToArray();

            for (int i = 0; i < stringchars.Length; i++)
            {
                if (chardict.Contains(stringchars[i]))
                {
                    input[i] = (Array.IndexOf(chardict, stringchars[i]) + 1);
                }
                else
                {
                    input[i] = 0;
                }
            }

            return input.ToList();
        }

        public ValidationReport ValidateModel(LanguageRecords[] languagerecords)
        {
            ValidationReport localReport = new ValidationReport();

            foreach (var languagerecord in languagerecords)
            {
                foreach (var record in languagerecord.Records)
                {
                    Dictionary<Languages, double> report = ValidateSentence(record);

                    Languages language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    localReport.AddCase(language, languagerecord.Language);
                    validationReport.AddCase(language, languagerecord.Language);
                }
            }

            return localReport;
        }

        public Dictionary<Languages, double> ValidateSentence(string sentence)
        {
            Dictionary<Languages, double> products = new Dictionary<Languages, double>();

            List<double> input = InputFromString(sentence, inputnodes);

            double[] output = neuralNet.Run(input);

            for (int i = 0; i < output.Length - 1; i++)
            {
                products.Add((Languages)i, output[i]);
            }

            return products;
        }
    }
}
