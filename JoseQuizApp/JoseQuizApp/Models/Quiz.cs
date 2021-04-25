using JoseQuizApp.VIewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JoseQuizApp.Models
{
    public class Quiz
    {
        public List<QuestionItemViewModel> QuestionsList { get; set; } = new List<QuestionItemViewModel>();
        public List<AnswerItemViewModel> AnswersList { get; set; } = new List<AnswerItemViewModel>();
        public List<UserResponse> UserResponses { get; set; } = new List<UserResponse>();
    }
}
