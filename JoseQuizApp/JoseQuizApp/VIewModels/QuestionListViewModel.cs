using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.VIewModels
{
    public class QuestionListViewModel : ViewModel
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionListViewModel(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
            Task.Run(async () => await LoadData());
        }
        public ObservableCollection<QuestionItemViewModel> QuestionList { get; set; }

        public async Task LoadData()
        {
            QuestionList = new ObservableCollection<QuestionItemViewModel>();
            var items = await _questionRepository.GetItems();
            items.ForEach(i => 
            {
                QuestionList.Add(CreateQuestionItemVM(i));
            });
        }

        private QuestionItemViewModel CreateQuestionItemVM(QuestionModel question)
        {
            var vm = Resolver.Resolve<QuestionItemViewModel>();
            vm.Question = question;
            return vm;
        }

        public QuestionItemViewModel QuestionSelected 
        {
            get => null;
            set
            {
                Task.Run(async () => await NavigateToItem(value));
                RaisePropertyChanged(nameof(QuestionSelected));
            }
        }

        private async Task NavigateToItem(QuestionItemViewModel qIVM)
        {
            if (qIVM == null)
            {
                return;
            }
            var v = Resolver.Resolve<ItemOptionsView>();
            var vm = v.BindingContext as ItemOptionsViewModel;
            vm.ItemProp = qIVM.Question;
            vm.ItemProp.DisplayName = $"Id: {qIVM.Question.Id} Question:{qIVM.Question.Query}";
            await Navigation.PushAsync(v);
        }
    }
}
