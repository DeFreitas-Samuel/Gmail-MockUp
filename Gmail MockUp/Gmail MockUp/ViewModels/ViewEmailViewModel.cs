using Gmail_MockUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_MockUp.ViewModels
{
    class ViewEmailViewModel
    {

        public EmailData EmailToDisplay { get; set; }


        public ViewEmailViewModel(EmailData email) 
        {
            EmailToDisplay = email;
        }
        

    }
}
