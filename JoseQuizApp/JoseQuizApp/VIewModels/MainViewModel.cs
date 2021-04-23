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
        public MainViewModel()
        {
                
        }


        public ICommand TakeQuiz_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<QuizView>());
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
