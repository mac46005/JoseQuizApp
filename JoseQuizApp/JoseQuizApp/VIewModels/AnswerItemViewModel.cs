using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class AnswerItemViewModel : ViewModel
    {
        public AnswerModel Answer { get; set; }

        public ICommand Options_Clicked => new Command(async () =>
        {
            Answer.DisplayName = $"ID: {Answer.Id}  Value:{Answer.Solution}";
            var v = Resolver.Resolve<ItemOptionsView>();
            var vm = v.BindingContext as ItemOptionsViewModel;
            vm.ItemProp = Answer;
            await Navigation.PushAsync(v);
        });
    }
}
