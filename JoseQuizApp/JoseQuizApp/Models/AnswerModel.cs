using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.Models
{
    public class AnswerModel : IItemModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Solution { get; set; }
        public string DisplayName { get; set; }
    }
}
