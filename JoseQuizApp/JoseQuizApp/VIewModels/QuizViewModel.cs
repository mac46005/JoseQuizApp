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
        public QuestionItemViewModel QuestionVM { get; set; }
        public UserResponse YourResponse { get; set; } = new UserResponse();
        public int Count { get; set; } = 0;


        public void LoadQuestion()
        {
            if (Count > _quizManager.Quiz.QuestionsList.Count)
            {
                return;
            }
            QuestionVM = _quizManager.Quiz.QuestionsList[Count];
            QuestionCount = $"QUIZ: Question {Count} of {_quizManager.Quiz.QuestionsList.Count}";
        }

        public ICommand Next_Clicked => new Command(async () =>
        {
            _quizManager.Quiz.UserResponses.Add(YourResponse);
            if (Count == _quizManager.Quiz.QuestionsList.Count)
            {
                //results page
                var v = Resolver.Resolve<ResultsView>();
                var vm = v.BindingContext as ResultsViewModel;
                vm = _quizManager.EvaluateQuiz();
                await Navigation.PushAsync(v);
            }
            else
            {
                //continue next question
                var v = Resolver.Resolve<QuizView>();
                var vm = v.BindingContext as QuizViewModel;
                vm.Count += Count + 1;
                vm.LoadQuestion();
                await Navigation.PushAsync(v);
            }
        });
    }
}
