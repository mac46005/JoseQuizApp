using JoseQuizApp.Logic;
using JoseQuizApp.VIewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            /////////////////////////////////////////////////////////
            ///LoadThisOnce
            Task.Run(async() => await _quizManager.LoadDataOnce());
            /////////////////////////////////////////////////////////
        }


        public ICommand TakeQuiz_Clicked => new Command(async () =>
        {
            await _quizManager.CreateQuiz();
            var v = Resolver.Resolve<QuizView>();
            var vm = v.BindingContext as QuizViewModel;
            vm.LoadQuestion();
            await Navigation.PushAsync(v);
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
