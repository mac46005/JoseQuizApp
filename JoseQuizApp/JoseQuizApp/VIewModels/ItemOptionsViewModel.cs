using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoseQuizApp.VIewModels
{
    public class ItemOptionsViewModel<T> : ViewModel
    {
        private string Type { get; set; }
        public T ItemProp { get; set; }


    }
}
