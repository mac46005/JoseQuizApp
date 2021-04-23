using JoseQuizApp.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JoseQuizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionListView : ContentPage
    {
        public QuestionListView(QuestionListViewModel vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}