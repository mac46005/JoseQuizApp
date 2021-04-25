using JoseQuizApp.Logic;
using JoseQuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.VIewModels
{
    public class QuizViewModel
    {
        public string QuestionCount { get; set; }
        public QuestionItemViewModel Question { get; set; }
        public UserResponse YourResponse { get; set; }
    }
}
