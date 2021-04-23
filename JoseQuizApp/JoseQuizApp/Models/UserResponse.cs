using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public bool IsCorrect { get; set; }
    }
}
