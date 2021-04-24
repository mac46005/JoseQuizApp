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
    public class AnswerListViewModel : ViewModel
    {
        private readonly AnswerRepository _answerRepository;

        public AnswerListViewModel(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;

            Task.Run(async () => await LoadData());
        }

        public ObservableCollection<AnswerItemViewModel> AnswerList { get; set; } = new ObservableCollection<AnswerItemViewModel>();
        public AnswerModel SelectedAnswer  
        {
            get => null;
            set
            {
                Task.Run(async () => await NavigateToItem(value));
                RaisePropertyChanged(nameof(SelectedAnswer));
            }
        }
        private async Task LoadData()
        {
            var items = await _answerRepository.GetItems();
            items.ForEach(i => 
            {
                AnswerList.Add(CreateAnswerItemVM(i));
            });
        }
        private async Task NavigateToItem(AnswerModel answer)
        {
            var v = Resolver.Resolve<AddAnswerView>();
            var vm = Resolver.Resolve<AddAnswerViewModel>();

            vm.Answer = answer;

            await Navigation.PushAsync(v);
        }
        private AnswerItemViewModel CreateAnswerItemVM(AnswerModel answer)
        {
            var vm = Resolver.Resolve<AnswerItemViewModel>();
            vm.Answer = answer;
            return vm;
        }
    }
}
