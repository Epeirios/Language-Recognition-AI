using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Recognition_AI
{
    public partial class MainForm : Form
    {
        private ModelControl[] modelControls;
        private TrainingControl[] trainingControls;
        BackgroundWorker backgroundWorker;

        public MainForm()
        {
            InitializeComponent();
        }

        public NGramModel GetNGramModel(string modelname)
        {
            if (modelname == "TriGramModel")
            {
                return new NGramModel(trainingControls[1].GetNGramMatrix, trainingControls[0].GetNGramMatrix);
            }
            else
            {
                return new NGramModel(trainingControls[2].GetNGramMatrix, trainingControls[1].GetNGramMatrix);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trainingControls = new TrainingControl[]
            {
                new TrainingControl(new BiGramMatrix(), "BiGram"),
                new TrainingControl(new TriGramMatrix(), "TriGram"),
                //new TrainingControl(new QuadGramMatrix(), "QuadGram")
            };

            modelControls = new ModelControl[]
            {
                new ModelControl("TriGramModel", this, GetNGramModel("TriGramModel")),
                //new ModelControl("QuadGramModel", this, GetNGramModel("QuadGramModel")),
            };

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var trainingControl in trainingControls)
            {
                flpTraining.Controls.Add(trainingControl);
                trainingControl.Train();
            }

            foreach (var modelControl in modelControls)
            {
                flpModels.Controls.Add(modelControl);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FillTvStats();
        }

        private void FillTvStats()
        {
            LanguageRecords[] trainingData = DataManager.Instance.TrainingData;

            foreach (var item in trainingData)
            {
                TreeNode recordCount = new TreeNode(string.Format("Record Count: {0}", item.RecordCount));
                TreeNode maxLength = new TreeNode(string.Format("Max Length record: {0}", item.MaxLenghtRecord));
                TreeNode minLength = new TreeNode(string.Format("Min Length record: {0}", item.MinLenghtRecord));
                TreeNode dictLength = new TreeNode(string.Format("Dict Lenght: {0}", item.CharDictionary.Count));

                TreeNode[] array = new TreeNode[] { recordCount, maxLength, minLength, dictLength };

                this.InvokeEx(f => f.tvDataStats.Nodes.Add(new TreeNode(item.Language.ToString(), array)));
            }

            this.InvokeEx(f => f.tvDataStats.ExpandAll());
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dgvResults.Rows.Clear();
            dgvResults.Columns.Clear();

            dgvResults.Columns.Add("Model", "Model");

            foreach (var language in Enum.GetNames(typeof(Languages)))
            {
                dgvResults.Columns.Add(string.Format("Col{0}", language), language);
            }

            dgvResults.Columns.Add("Highest", "Highest");

            foreach (var modelcontrol in modelControls)
            {
                double highestValue = 0.0f;

                List<string> cells = new List<string>();

                cells.Add(modelcontrol.ModelName);

                Dictionary<Languages, double> propabilities = modelcontrol.Model.ValidateSentence(tbInputString.Text);

                foreach (var item in propabilities)
                {
                    double value = item.Value;

                    if (value > highestValue)
                    {
                        highestValue = value;
                    }

                    cells.Add(value.ToString());
                }

                cells.Add(highestValue.ToString());

                dgvResults.Rows.Add(cells.ToArray());
            }
        }
    }
}
