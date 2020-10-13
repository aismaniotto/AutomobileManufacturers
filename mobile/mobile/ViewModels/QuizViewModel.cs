using System;
using System.Collections.Generic;
using mobile.Entities;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace mobile.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        public ICommand ButtonCommand { get; private set; }

        private string _pageTitle = "Question 1";
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private string _buttonLabel = "Next";
        public string ButtonLabel
        {
            get { return _buttonLabel; }
            set { SetProperty(ref _buttonLabel, value); }
        }

        private List<Question> _questions;
        public List<Question> Questions
        {
            get { return _questions; }
            set { SetProperty(ref _questions, value); }
        }

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set { SetProperty(ref _currentQuestion, value); }
        }

        private string _currentChoice;
        public string CurrentChoice
        {
            get { return _currentChoice; }
            set { SetProperty(ref _currentChoice, value); }
        }

        private List<Answer> _answers = new List<Answer>();

        public QuizViewModel(List<Question> questions)
        {
            var rnd = new Random();
            Questions = new List<Question>(questions.OrderBy(item => rnd.Next()));

            CurrentQuestion = Questions[0];

            ButtonCommand = new Command(ButtonCommandAction);
        }

        private async void ButtonCommandAction()
        {
            var currentIndex = Questions.FindIndex(question => question == CurrentQuestion);

            _answers.Add(new Answer { Title = CurrentQuestion.Title, Choice = CurrentChoice });

            currentIndex++;

            if (currentIndex >= Questions.Count())
            {
                var a = "";
                var b = "";
                //end
                // navigate to Finish page
            }
            else
            {
                CurrentQuestion = Questions[currentIndex];
                CurrentChoice = "";
                PageTitle = $"Question {currentIndex + 1}";
            }

            if (currentIndex + 1 == Questions.Count())
            {
                ButtonLabel = "Finish";
            }
        }
    }
}
