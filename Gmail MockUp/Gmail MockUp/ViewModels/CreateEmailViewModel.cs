using Gmail_MockUp.Models;
using Plugin.LocalNotifications;
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
        private readonly string _dateSended = DateTime.Now.ToString("dd MMM");
        private string _from;
        private string _imageLocation;
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
        public string DateSended
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
        public string ImageLocation
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
            if(string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(From)) 
            {
                await Application.Current.MainPage.DisplayAlert("Please fill all the fields", "", "Ok");
            }
            else 
            {
                int counter = Preferences.Get("counter", 0);
                Emails.Add(new EmailData(Title, Description, DateSended, From, ImageLocation));

                Preferences.Set($"Mail{counter} Title", Title);
                Preferences.Set($"Mail{counter} Description", Description);
                Preferences.Set($"Mail{counter} DateSended", DateSended);
                Preferences.Set($"Mail{counter} From", From);
                Preferences.Set($"Mail{counter} ImageLocation", ImageLocation);
                counter++;
                Preferences.Set("counter", counter);


                await Application.Current.MainPage.DisplayAlert("Email sent succesfully", "", "Ok");
                await Email.ComposeAsync(Title, Description, From);
                CrossLocalNotifications.Current.Show(Title, "Correo Enviado");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void SelectImage()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });
                var stream = await result.OpenReadAsync();

                ImageLocation = result.FullPath;
            }
            catch (PermissionException)
            {
                await Application.Current.MainPage.DisplayAlert("Permissions were not granted", "", "Ok");
            }
            catch (NullReferenceException)
            {
                await Application.Current.MainPage.DisplayAlert("No picture was selected", "", "Ok");
            }

        }

    }
}
