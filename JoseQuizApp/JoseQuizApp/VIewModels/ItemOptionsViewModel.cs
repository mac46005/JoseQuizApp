using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using JoseQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class ItemOptionsViewModel : ViewModel
    {
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;

        private string Type { get; set; }
        public IItemModel ItemProp { get; set; }




        public ItemOptionsViewModel(AnswerRepository answerRepository,QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public ICommand Edit_Clicked => new Command(async () =>
        {
            
            if (ItemProp is AnswerModel)
            {
                var v = Resolver.Resolve<AddAnswerView>();
                var vm = v.BindingContext as AddAnswerViewModel;
                vm.Answer = (AnswerModel)ItemProp;
                await Navigation.PushAsync(v);
            }
            else
            {
                var v = Resolver.Resolve<AddQuestionView>();
                var vm = v.BindingContext as AddQuestionViewModel;
                vm.Question = (QuestionModel)ItemProp;
                await Navigation.PushAsync(v);
            }
        });

        public ICommand Delete_Clicked => new Command(async () =>
        {
            if (ItemProp is AnswerModel)
            {
                await _answerRepository.DeleteItem((AnswerModel)ItemProp);
            }
            else
            {
                await _questionRepository.DeleteItem((QuestionModel)ItemProp);
            }
            await Navigation.PopAsync();
        });
    }
}
