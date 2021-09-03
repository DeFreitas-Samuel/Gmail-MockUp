using Gmail_MockUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
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
        private ImageSource _imageLocation;
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
        public ImageSource ImageLocation
        {
            get { return _imageLocation; }
            set
            {

                _imageLocation = value;
                OnPropertyChanged(nameof(ImageLocation));

            }
        }
        public ObservableCollection<EmailData> Emails;

        public CreateEmailViewModel(ObservableCollection<EmailData> emails)
        {
            Emails = emails;
            SendEmailCommand = new Command(SendEmail);
            SelectImageCommand = new Command(SelectImage);
        }

        public ICommand SendEmailCommand { get; }
        public ICommand SelectImageCommand { get; }

        private async void SendEmail()
        {
            Emails.Add(new EmailData(Title, Description, DateSended, From, HasAttachment));
            await Application.Current.MainPage.DisplayAlert("Correo enviado de manera existosa", "", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void SelectImage()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            { 
                Title = "Please pick a photo"
            });
            var stream = await result.OpenReadAsync();


            ImageLocation = ImageSource.FromStream(() => stream);

        }

    }
}
