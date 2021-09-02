using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_MockUp.Models
{
    class Email
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateReceived { get; set; }
        public string From { get; set; }
        public bool HasAttachment { get; set; }

        public Email(string title, string description, DateTime dateReceived, string from, bool hasAttachment)
        {
            Title = title;
            Description = description;
            DateReceived = dateReceived;
            From = from;
            HasAttachment = hasAttachment;
        }
    }
}
