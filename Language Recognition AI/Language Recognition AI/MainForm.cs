﻿using System;
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
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                TreeNode dictLength = new TreeNode(string.Format("Dict Lenght: {0}", item.CharDictionary.Length));

                TreeNode[] array = new TreeNode[] { recordCount, maxLength, minLength, dictLength};

                tvDataStats.Nodes.Add(new TreeNode(item.Language, array));
            }

            tvDataStats.ExpandAll();
        }

        private void TrainMatrix()
        {
            LanguageRecords[] trainingData = DataManager.Instance.TrainingData;

            foreach (LanguageRecords lang in trainingData)
            {
                int dictLength = lang.CharDictionary.Length;
                int[,] matrix = new int[dictLength, dictLength];

                foreach (string record in lang.Records)
                {

                }
            }
        }
    }
}
