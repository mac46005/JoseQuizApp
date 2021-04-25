using JoseQuizApp.Logic;
using JoseQuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class QuizViewModel
    {

        public QuizViewModel()
        {

        }

        public string QuestionCount { get; set; }
        public QuestionItemViewModel Question { get; set; }
        public UserResponse YourResponse { get; set; }
        public int Count { get; set; }

        public ICommand FunctionName => new Command(async () =>
        {
        });
    }
}
