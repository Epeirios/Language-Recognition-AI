﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public interface IModel
    {
        event EventHandler<EventArgsProgress> EventValidationProgress;
        event EventHandler<EventArgsProgress> EventTrainingProgress;

        void Train(LanguageRecords[] languageRecords);

        Report Validate(LanguageRecords[] languageRecords);

        Dictionary<Languages, float> ValidateSentence(string sentence);
    }
}