using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class ManageDbViewModel : ViewModel
    {
        public ICommand AddQuestion_Clicked => new Command(async () => 
        {
            await Navigation.PushAsync(Resolver.Resolve<AddQuestionView>());
        });
        public ICommand AddAnswer_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<AddAnswerView>());
        });
        public ICommand ViewList_Clicked => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<ListMenuView>());
        });

    }
}
