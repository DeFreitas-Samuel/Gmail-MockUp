using Gmail_MockUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gmail_MockUp.ViewModels
{
    class CreateEmailViewModel:INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private DateTime _dateSended = DateTime.Now;
        private string _from;
        private bool _hasAttachment = true;
        public string Title
        {
            get { return _title; }
            set
            {

                _title = value;
                OnPropertyChanged(nameof(Title));

            }
        }
        public string Description
        {
            get { return _description; }
            set
            {

                _description = value;
                OnPropertyChanged(nameof(Description));

            }
        }
        public DateTime DateSended
        {
            get { return _dateSended; }

        }
        public string From
        {
            get { return _from; }
            set
            {

                _from = value;
                OnPropertyChanged(nameof(From));

            }
        }
        public bool HasAttachment
        {
            get { return _hasAttachment; }

        }
        public ObservableCollection<Email> Emails;

        public CreateEmailViewModel(ObservableCollection<Email> emails)
        {
            Emails = emails;
            SendEmailCommand = new Command(SendEmail);
        }

        public ICommand SendEmailCommand { get; }

        private async void SendEmail()
        {
            Emails.Add(new Email(Title, Description, DateSended, From, HasAttachment));
            await Application.Current.MainPage.DisplayAlert("Correo enviado de manera existosa", "", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
