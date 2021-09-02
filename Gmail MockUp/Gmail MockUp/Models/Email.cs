using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_MockUp.Models
{
    class Email
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime DateReceived { get; }
        public string From { get; }
        public bool HasAttachment { get; }

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
