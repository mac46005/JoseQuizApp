using JoseQuizApp.Models;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.VIewModels
{
    public class ItemOptionsViewModel : ViewModel
    {
        private string Type { get; set; }
        public IItemModel ItemProp { get; set; }


    }
}
