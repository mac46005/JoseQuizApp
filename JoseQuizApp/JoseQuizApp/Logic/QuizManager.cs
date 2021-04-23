using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.VIewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.Logic
{
    public class QuizManager
    {
        private readonly IConfiguration _config;
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        public Quiz Quiz { get; set; }
        public QuizManager(IConfiguration _config,AnswerRepository answerRepository,QuestionRepository questionRepository)
        {
            this._config = _config;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }
        public async Task CreateQuiz()
        {
            int numOfQuestions = int.Parse(_config.GetSection("Options")["QuestionCount"]);
            Quiz = Resolver.Resolve<Quiz>();
            var listOfQuestions = await _questionRepository.GetItems();
            for (int i = 0; i < numOfQuestions; i++)
            {
                var randNum = new Random().Next(listOfQuestions.Count);
                Quiz.Questions.Add(listOfQuestions[randNum]);
            }
            Quiz.Questions.ForEach(q => { Quiz.Answers.Add(new AnswerModel { Id = q.Answer_Id }); });
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
