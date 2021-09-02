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
        public ObservableCollection<Email> Mails { get; } = new ObservableCollection<Email>()
        {
            new Email("Hello", "At least I can say that I've tried", DateTime.Parse("08/18/2018"), "From the other side", true)

        };

        public ReceivedEmailsViewModel()
        {
            CreateEmailCommand = new Command(CreateEmail);
        } 

        private async void CreateEmail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateEmailPage());
        }

        public ICommand CreateEmailCommand { get; }

    }
}
