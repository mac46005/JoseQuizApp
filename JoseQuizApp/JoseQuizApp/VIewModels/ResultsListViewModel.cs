using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JoseQuizApp.VIewModels
{
    public class ResultsListViewModel : ViewModel
    {
        public QuestionModel Question { get; set; } = new QuestionModel();
        public UserResponse UserResponse { get; set; } = new UserResponse();
    }
}
