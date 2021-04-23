using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.VIewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void CreateQuiz()
        {
            int numOfQuestions = int.Parse(_config.GetSection("Options")["QuestionCount"]);
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
