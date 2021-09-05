using Gmail_MockUp.Models;
using Gmail_MockUp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Gmail_MockUp.ViewModels
{
    class SendedEmailsViewModel:INotifyPropertyChanged
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
                OnPropertyChanged(nameof(SelectedEmail));
                if (_selectedEmail != null)
                {
                    ViewEmailCommand.Execute(_selectedEmail);
                    SelectedEmail = null;
                }
            }
        }
        public ObservableCollection<EmailData> Emails { get; set; } = new ObservableCollection<EmailData>();

        public SendedEmailsViewModel()
        {
            CreateEmailCommand = new Command(OnCreateEmail);
            ViewEmailCommand = new Command<EmailData>(OnViewEmail);
            DeleteEmailCommand = new Command<EmailData>(DeleteEmail);
            int EmailsToRender = Preferences.Get("counter", 0);
            
            for (int i = 0; i < EmailsToRender ; i++)
            {
                
                Emails.Add(new EmailData(Preferences.Get($"Mail{i} Title", ""),
                                         Preferences.Get($"Mail{i} Description", ""),
                                         Preferences.Get($"Mail{i} DateSended", ""),
                                         Preferences.Get($"Mail{i} From", ""),
                                         Preferences.Get($"Mail{i} ImageLocation", "")));
                
            }
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
            SelectedEmail = null;
           
        }

        public ICommand CreateEmailCommand { get; }
        private ICommand ViewEmailCommand { get; }
        public ICommand DeleteEmailCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
