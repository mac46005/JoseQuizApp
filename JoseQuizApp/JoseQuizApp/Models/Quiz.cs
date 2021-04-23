using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.Models
{
    public class Quiz
    {
        public List<QuestionModel> Questions { get; set; }
        public List<AnswerModel> Answers { get; set; }
        public List<UserResponse> UserResponses { get; set; }
    }
}
