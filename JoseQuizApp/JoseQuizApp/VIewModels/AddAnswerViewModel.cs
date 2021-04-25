using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class AddAnswerViewModel : ViewModel
    {
        private readonly AnswerRepository _answerRepository;

        public AddAnswerViewModel(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public AnswerModel Answer { get; set; } = Resolver.Resolve<AnswerModel>();

        public ICommand Submit_Clicked => new Command(async () =>
        {
            await _answerRepository.AddOrUpdateItem(Answer);

            await Navigation.PopToRootAsync();
        });
    }
}
