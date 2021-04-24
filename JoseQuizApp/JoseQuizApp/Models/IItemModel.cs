using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.Models
{
    public interface IItemModel
    {
        int Id { get; set; }
        string DisplayName { get; set; }
    }
}
