﻿namespace Mercure.User.Application.Commands.Models
{
    public class UserCommandModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
