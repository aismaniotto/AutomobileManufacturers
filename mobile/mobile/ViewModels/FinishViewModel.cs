using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Input;
using mobile.Entities;
using mobile.Presentation.Pages;
using mobile.Services;
using Xamarin.Forms;

namespace mobile.ViewModels
{
    public class FinishViewModel : BaseViewModel
    {
        public ICommand GetResultCommand { get; private set; }
        public ICommand StartBackCommand { get; private set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isSuccess = false;
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { SetProperty(ref _isSuccess, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private float _hits;
        public float Hits
        {
            get { return _hits; }
            set { SetProperty(ref _hits, value); }
        }

        private List<Answer> _answers = new List<Answer>();
        private AutomobileManufacturersService _automobileManufacturersService;

        public FinishViewModel(List<Answer> answers)
        {
            _automobileManufacturersService = new AutomobileManufacturersService();

            _answers = answers;

            GetResultCommand = new Command(GetResultCommandAction);
            StartBackCommand = new Command(StartBackCommandAction);

            GetResultCommandAction();
        }

        private async void GetResultCommandAction()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var result = await _automobileManufacturersService.SubmitAnswers(_answers);
                Hits = result * 100;

                if (Hits < 60)
                {
                    Message = "Try harder next time.";
                } else if (Hits <= 80)
                {
                    Message = "Nice!";
                }
                else
                {
                    Message = "Congrats!!";
                }

                IsSuccess = true;
            }
            catch (WebException e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "No internet",
                    "Not possible to connect on internet. Please try again",
                    "Ok");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Something wrong",
                    "Some unnexpectable error happens.= Please try again",
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void StartBackCommandAction()
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}
