using Gmail_MockUp.Models;
using Gmail_MockUp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gmail_MockUp.ViewModels
{
    class ReceivedEmailsViewModel
    {
        private EmailData _selectedEmail;
        public EmailData SelectedEmail 
        {
            get 
            { 
                return _selectedEmail; 
            }
            set 
            {
                _selectedEmail = value;
                if (_selectedEmail != null)
                {
                    ViewEmailCommand.Execute(_selectedEmail);
                }
            }
        }
        public ObservableCollection<EmailData> Emails { get; set; } = new ObservableCollection<EmailData>();

        public ReceivedEmailsViewModel()
        {
            CreateEmailCommand = new Command(OnCreateEmail);
            ViewEmailCommand = new Command<EmailData>(OnViewEmail);
            DeleteEmailCommand = new Command<EmailData>(DeleteEmail);
        }

        private void DeleteEmail(EmailData email)
        {
            Emails.Remove(email);
        }

        private async void OnCreateEmail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateEmailPage(Emails));
        }

        private async void OnViewEmail(EmailData email)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewEmailPage(_selectedEmail));
        }

        public ICommand CreateEmailCommand { get; }
        public ICommand ViewEmailCommand { get; }
        public ICommand DeleteEmailCommand { get; }

    }
}
