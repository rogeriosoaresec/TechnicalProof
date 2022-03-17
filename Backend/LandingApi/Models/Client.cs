using System;
using LandingApi.Models.Enums;

namespace LandingApi.Models
{
    public class Client
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            private set { id = Guid.NewGuid(); }
        }
        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public ClientTypeEnum ClientType { get; set; }
    }
}