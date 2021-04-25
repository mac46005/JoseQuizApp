using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JoseQuizApp.VIewModels
{
    public class ResultsViewModel : ViewModel
    {
        public int CorrectQuestions { get; set; }
        public int TotalQuestions { get; set; }
        public string Accuracy { get; set; }
    }
}
