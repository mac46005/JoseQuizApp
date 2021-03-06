using JoseQuizApp.Logic;
using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class QuizViewModel : ViewModel
    {
        private readonly QuizManager _quizManager;
        private readonly AnswerRepository _answerRepository;

        public QuizViewModel(QuizManager quizManager, AnswerRepository answerRepository)
        {
            _quizManager = quizManager;
            _answerRepository = answerRepository;
        }

        public string QuestionCount { get; set; }
        public QuestionItemViewModel QuestionVM { get; set; }
        public UserResponse YourResponse { get; set; } = new UserResponse();
        public int Count { get; set; } = 0;
        public string Answer { get; set; }

        public void LoadQuestion()
        {
            if (Count > _quizManager.Quiz.QuestionsList.Count)
            {
                return;
            }
            QuestionVM = _quizManager.Quiz.QuestionsList[Count];
            QuestionCount = $"QUIZ: Question {Count} of {_quizManager.Quiz.QuestionsList.Count - 1}";
        }


        public bool SubmitBtnIsEnabled { get; set; } = true;

        public ICommand Submit_Clicked => new Command(async () =>
        {
            var answerlist = await _answerRepository.GetItems();
            Answer = answerlist.Find(a => a.Id == QuestionVM.Question.Answer_Id).Solution;
            NextBtnIsEnabled = true;
            SubmitBtnIsEnabled = false;
        });
        public bool NextBtnIsEnabled { get; set; } = false;

        public ICommand Next_Clicked => new Command(async () =>
        {
            _quizManager.Quiz.UserResponses.Add(YourResponse);
            if (Count == _quizManager.Quiz.QuestionsList.Count - 1)
            {
                //results page
                var v = Resolver.Resolve<ResultsView>();

                var vm = v.BindingContext as ResultsViewModel;
                var PremadeVM = _quizManager.EvaluateQuiz();

                vm.CorrectQuestions = PremadeVM.CorrectQuestions;
                vm.TotalQuestions = PremadeVM.TotalQuestions;
                vm.Accuracy = PremadeVM.Accuracy;
                vm.ObsList_RLVM = PremadeVM.ObsList_RLVM;
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
