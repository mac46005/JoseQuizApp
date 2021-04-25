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

        public ObservableCollection<AnswerItemViewModel> AnswerList { get; set; }
        public AnswerItemViewModel AnswerSelected
        {
            get => null;
            set
            {
                
                Task.Run(async () => await NavigateToItem(value));
                RaisePropertyChanged(nameof(AnswerSelected));
            }
        }
        private async Task LoadData()
        {
            AnswerList = new ObservableCollection<AnswerItemViewModel>();
            var items = await _answerRepository.GetItems();
            items.ForEach(i => 
            {
                AnswerList.Add(CreateAnswerItemVM(i));
            });
        }
        private async Task NavigateToItem(AnswerItemViewModel answerItemVM)
        {
            if (answerItemVM == null)
            {
                return;
            }
            var v = Resolver.Resolve<ItemOptionsView>();
            var vm = v.BindingContext as ItemOptionsViewModel;
            vm.ItemProp = answerItemVM.Answer;
            vm.ItemProp.DisplayName = $"Type:{vm.ItemProp.GetType().Name}Id:{answerItemVM.Answer.Id}    Value:{answerItemVM.Answer.Solution}";
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
