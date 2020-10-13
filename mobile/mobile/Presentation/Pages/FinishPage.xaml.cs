using System;
using System.Collections.Generic;
using mobile.Entities;
using mobile.ViewModels;
using Xamarin.Forms;

namespace mobile.Presentation.Pages
{
    public partial class FinishPage : ContentPage
    {
        public FinishPage(List<Answer> answers)
        {
            InitializeComponent();
            BindingContext = new FinishViewModel(answers);
        }
    }
}
