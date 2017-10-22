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

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modelControls = new ModelControl[] { new ModelControl(new BiGramModel(), "BiGram") };

            foreach (var modelControl in modelControls)
            {
                listView1.Controls.Add(modelControl);
            }

            FillTvStats();

            TrainModels();

            ValidateModels();
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

                tvDataStats.Nodes.Add(new TreeNode(item.Language.ToString(), array));
            }

            tvDataStats.ExpandAll();
        }

        private void TrainModels()
        {
            foreach (var modelControl in modelControls)
            {
                modelControl.Model.Train(DataManager.Instance.TrainingData);

                modelControl.AddNode("Trained Data");
            }
        }

        private void ValidateModels()
        {
            foreach (var modelControl in modelControls)
            {
                IModel model = modelControl.Model;
                
                Report report = model.Validate(DataManager.Instance.ValidationData);

                modelControl.AddNode(string.Format("Number of Cases: {0}", report.CountCases));
                modelControl.AddNode(string.Format("Cases Correct: {0}", report.CountCorrect));
                modelControl.AddNode(string.Format("Cases Incorrect: {0}", report.CountIncorrect));
            }
        }
    }
}
