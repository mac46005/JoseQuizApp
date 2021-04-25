using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
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
    }
}
