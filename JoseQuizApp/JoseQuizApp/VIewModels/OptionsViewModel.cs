using JoseQuizApp.Logic;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class OptionsViewModel : ViewModel
    {
        private readonly QuizManager _quizManager;

        public OptionsViewModel(QuizManager quizManager)
        {
            _quizManager = quizManager;
        }
        public int? QuestionCount { get; set; } = 0;



        public ICommand Apply => new Command(async () =>
        {
            //apply settings
            ApplyQuestionCount();
            await Navigation.PopAsync();
        });



        private void ApplyQuestionCount()
        {
            if (QuestionCount == null||QuestionCount == 0)
            {
                return;
            }
            else
            {
                _quizManager.QuestionCount = (int)QuestionCount;
            }
        }
    }
}
