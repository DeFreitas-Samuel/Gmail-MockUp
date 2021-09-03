using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_MockUp.Models
{
    public class EmailData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateReceived { get; set; }
        public string From { get; set; }
        public string ImageLocation { get; set; }

        public EmailData(string title, string description, DateTime dateReceived, string from, string imageLocation = "")
        {
            Title = title;
            Description = description;
            DateReceived = dateReceived;
            From = from;
            ImageLocation = imageLocation;

        }
    }
}
