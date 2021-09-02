using Gmail_MockUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_MockUp.ViewModels
{
    class ViewEmailViewModel
    {

        public Email EmailToDisplay { get; set; }


        public ViewEmailViewModel(Email email) 
        {
            EmailToDisplay = email;
        }
        

    }
}
