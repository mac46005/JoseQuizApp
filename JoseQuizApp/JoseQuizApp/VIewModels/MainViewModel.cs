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


        public ICommand btnTakeQuiz_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<QuizView>());
        });
        public ICommand btnManageDb_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<ManageDbView>());
        });
        public ICommand btnOptions_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<OptionsView>());
        });
    }
}
