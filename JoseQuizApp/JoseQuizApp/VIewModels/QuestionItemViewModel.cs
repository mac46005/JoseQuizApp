using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.VIewModels
{
    public class QuestionItemViewModel : ViewModel
    {
        public QuestionModel Question { get; set; }
    }
}
