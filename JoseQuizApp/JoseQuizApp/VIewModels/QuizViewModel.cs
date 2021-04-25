using JoseQuizApp.Logic;
using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class QuizViewModel : ViewModel
    {
        private readonly QuizManager _quizManager;

        public QuizViewModel(QuizManager quizManager)
        {
            _quizManager = quizManager;


            
        }

        public string QuestionCount { get; set; }
        public QuestionItemViewModel Question { get; set; }
        public UserResponse YourResponse { get; set; } = new UserResponse();
        public int Count { get; set; } = 0;


        public void LoadQuestion()
        {
            Question = _quizManager.Quiz.QuestionsList[Count];
            QuestionCount = $"QUIZ: Question {Count} of {_quizManager.Quiz.QuestionsList.Count}";
        }

        public ICommand Next_Clicked => new Command(async () =>
        {
            _quizManager.Quiz.UserResponses[Count] = YourResponse;
            if (Count == _quizManager.Quiz.QuestionsList.Count)
            {
                //results page
            }
            else
            {
                //continue next question
                var v = Resolver.Resolve<QuizView>();
                var vm = v.BindingContext as QuizViewModel;
                vm.Count = Count++;
                vm.LoadQuestion();
                await Navigation.PushAsync(v);
            }
        });
    }
}
