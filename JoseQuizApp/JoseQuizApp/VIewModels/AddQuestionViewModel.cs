﻿using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class AddQuestionViewModel : ViewModel
    {
        public QuestionModel Question { get; set; }

        public ICommand FunctionName => new Command(async () =>
        {

        });
    }
}
