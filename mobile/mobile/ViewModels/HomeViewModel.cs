﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Input;
using mobile.Entities;
using mobile.Services;
using Xamarin.Forms;

namespace mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand StartCommand { get; private set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        public List<Question> Questions { get; set; }

        private AutomobileManufacturersService _automobileManufacturersService;

        public HomeViewModel()
        {
            _automobileManufacturersService = new AutomobileManufacturersService();
            StartCommand = new Command(StartCommandAction);
        }

        private async void StartCommandAction()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                Questions = await _automobileManufacturersService.GetQuestions();
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
                    "Some unnexpectable error happens :( Please try again",
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
