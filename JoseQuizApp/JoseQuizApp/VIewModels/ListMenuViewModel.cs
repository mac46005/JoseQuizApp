using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class ListMenuViewModel : ViewModel
    {
        public ICommand AnswerList_Clicked => new Command(async () =>
           {
               await Navigation.PushAsync(Resolver.Resolve<AnswerListView>());
           });
    }
}
