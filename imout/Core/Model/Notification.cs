using System;
using System.Collections.Generic;

namespace imout.Core.Model
{
    public class Notification
    {
        private string name;
        private int triggerLevel;
        private string message;
        
        public List<Contact> Contacts { get; set; }
        public Guid Id { get; private set; }
        public Int64 lastSent { get; set; }
        public bool Active { get; set; }
        public string Name
        {
            get => name;
            set
                {
                    if (value.Length > 40) throw new ArgumentOutOfRangeException("Name cannot be longer than 40 characters");
                    if (value.Length < 1) throw new ArgumentOutOfRangeException("Name cannot be empty");

                    name = value;
                }

        }
        public int TriggerLevel
        {
            get => triggerLevel;
            set
            {
                if (value > 20 || value < 2) throw new ArgumentOutOfRangeException("The battery level must be between 2-20%");
                triggerLevel = value;
            }
        }
        public string Message
        {
            get => message;
            set
            {
                if (value.Length > 100 || value.Length < 1) throw new ArgumentOutOfRangeException("Message must be between 1-100 characters");

                message = value;
            }
        }

        public Notification(Guid id)
        {
            Id = id;
        }
    }
}
