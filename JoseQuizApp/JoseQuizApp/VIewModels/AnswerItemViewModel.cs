using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class AnswerItemViewModel : ViewModel
    {
        public AnswerModel Answer { get; set; }

        public ICommand Options_Clicked => new Command(async () =>
        {

        });
    }
}
