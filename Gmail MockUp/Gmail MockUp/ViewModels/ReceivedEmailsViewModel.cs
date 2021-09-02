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
        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>();

        public ReceivedEmailsViewModel()
        {
            Emails.Add(new Email("Saludos", "Le estamos escribiendo para informarle", DateTime.Today, "Banco", true));
            Emails.Add(new Email("Bendiciones", "Le estamos escribiendo para bendecirle", DateTime.Today, "Papa", true));
            Emails.Add(new Email("Estudie", "Le estamos escribiendo para que estudie", DateTime.Today, "Profesor", true));
            CreateEmailCommand = new Command(CreateEmail);
        } 

        private async void CreateEmail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateEmailPage());
        }

        public ICommand CreateEmailCommand { get; }

    }
}
