using JoseQuizApp.Logic;
using JoseQuizApp.VIewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly QuizManager _quizManager;

        public MainViewModel(QuizManager quizManager)
        {
            _quizManager = quizManager;
        }


        public ICommand TakeQuiz_Clicked => new Command(async () =>
        {
            await _quizManager.CreateQuiz();

            for (int i = 0; i < _quizManager.Quiz.ObservableQuestionsList.Count; i++)
            {
                var v = Resolver.Resolve<QuizView>();
                var vm = v.BindingContext as QuizViewModel;
                vm.QuestionCount = $"QUIZ Question: {i} of {_quizManager.Quiz.ObservableQuestionsList.Count}";
                vm.Question = _quizManager.Quiz.ObservableQuestionsList[i];
                vm.YourResponse = _quizManager.Quiz.UserResponses[i];
                await Navigation.PushAsync(v);
            }

        });
        public ICommand ManageDb_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<ManageDbView>());
        });
        public ICommand Options_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<OptionsView>());
        });
    }
}
