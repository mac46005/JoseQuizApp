using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JoseQuizApp.VIewModels
{
    public class AddQuestionViewModel : ViewModel
    {
        private readonly QuestionRepository _questionRepository;
        private readonly AnswerRepository _answerRepository;

        public AddQuestionViewModel(QuestionRepository questionRepository,AnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            Task.Run(async () => await LoadData());
        }
        public QuestionModel Question { get; set; } = new QuestionModel();
        public ObservableCollection<AnswerModel> AnswerList { get; set; }
        public AnswerModel SelectedAnswer { get; set; }
        private async Task LoadData()
        {
            var aList = await _answerRepository.GetItems();
            AnswerList = new ObservableCollection<AnswerModel>(aList);

        }


        public ICommand Submit_Clicked => new Command(async () =>
        {
            await _questionRepository.AddOrUpdateItem(Question);
            await Navigation.PopToRootAsync();
        });
    }
}
