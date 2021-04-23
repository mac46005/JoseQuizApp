using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.Models
{
    public class QuestionModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Query { get; set; }
        public int Answer_Id { get; set; }
        [Ignore]
        public AnswerModel Answer { get; set; }
    }
}
