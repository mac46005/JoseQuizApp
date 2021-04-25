using JoseQuizApp.VIewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JoseQuizApp.Models
{
    public class Quiz
    {
        public ObservableCollection<QuestionItemViewModel> ObservableQuestionsList { get; set; } = new ObservableCollection<QuestionItemViewModel>();
        public ObservableCollection<AnswerItemViewModel> ObservableAnswersList { get; set; } = new ObservableCollection<AnswerItemViewModel>();
        public List<UserResponse> UserResponses { get; set; } = new List<UserResponse>();
    }
}
