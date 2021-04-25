using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.VIewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JoseQuizApp.Logic
{
    public class QuizManager
    {
        //private readonly IConfiguration _config = new ConfigurationBuilder().AddJsonFile(@"E:\C#\GitHub_Repositories\JoseQuizApp_SLN\JoseQuizApp\JoseQuizApp\appsettings.json")
            //.Build();
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        public Quiz Quiz { get; set; }
        public QuizManager(AnswerRepository answerRepository,QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }
        public async Task CreateQuiz()
        {
            int numOfQuestions = 10;//int.Parse(_config.GetSection("Options")["QuestionCount"]);
            Quiz = Resolver.Resolve<Quiz>();
            var listOfQuestions = await _questionRepository.GetItems();
            for (int i = 0; i < numOfQuestions; i++)
            {
                var randNum = new Random().Next(listOfQuestions.Count);
                var vm = Resolver.Resolve<QuestionItemViewModel>();
                vm.Question = listOfQuestions[randNum];
                Quiz.ObservableQuestionsList[i] = vm;
            }
            Quiz.ObservableQuestionsList.ForEach(async q =>
            {
                int count = 0;
                Quiz.ObservableAnswersList[count].Answer = await _answerRepository
                .GetItem_ById(
                    Quiz
                    .ObservableQuestionsList[count]
                    .Question
                    .Answer_Id);
            }
            );
        }
        public void TakeQuiz()
        {

        }
        public ResultsViewModel EvaluateQuiz()
        {
            return Resolver.Resolve<ResultsViewModel>();
        }
    }
}
