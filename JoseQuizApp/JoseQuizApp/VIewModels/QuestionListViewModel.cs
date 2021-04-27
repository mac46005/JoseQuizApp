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
        private readonly AnswerRepository _answerRepository;

        public QuestionListViewModel(QuestionRepository questionRepository,AnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            Task.Run(async () => await LoadData());
        }
        public ObservableCollection<QuestionItemViewModel> QuestionList { get; set; }

        public async Task LoadData()
        {
            QuestionList = new ObservableCollection<QuestionItemViewModel>();
            var questionList = await _questionRepository.GetItems();
            questionList.ForEach(i => 
            {
                QuestionList.Add(CreateQuestionItemVM(i));
            });



            var answerList = await _answerRepository.GetItems();
            questionList.ForEach(q => 
            {
                q.Answer = answerList.Find(a => a.Id == q.Answer_Id);
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
