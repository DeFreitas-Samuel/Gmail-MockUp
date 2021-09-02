using Gmail_MockUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gmail_MockUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceivedEmailsPage : ContentPage
    {
        public ReceivedEmailsPage()
        {
            InitializeComponent();
            BindingContext = new ReceivedEmailsViewModel();
        }
    }
}