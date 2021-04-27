using JoseQuizApp.Logic;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class ResultsViewModel : ViewModel
    {
        public ObservableCollection<ResultsListViewModel> ObsList_RLVM { get; set; } = new ObservableCollection<ResultsListViewModel>();
        public int CorrectQuestions { get; set; } = 0;
        public int TotalQuestions { get; set; } = 0;
        public string Accuracy { get; set; }


        public ICommand Done_Clicked => new Command(async () =>
        {
            await Navigation.PopToRootAsync();
        });
    }
}
