using System;
using System.Collections.Generic;
using mobile.Entities;
using mobile.ViewModels;
using Xamarin.Forms;

namespace mobile.Presentation.Pages
{
    public partial class QuizPage : ContentPage
    {
        public QuizPage(List<Question> questions)
        {
            InitializeComponent();
            BindingContext = new QuizViewModel(questions);
        }
    }
}
