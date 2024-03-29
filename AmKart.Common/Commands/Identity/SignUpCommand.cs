﻿using System;

namespace AmKart.Common.Commands.Identity
{
    public class SignUpCommand
    {
        public Guid Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }
        public string Role { get; }

        // technical debt - role = "admin", todo
        public SignUpCommand(string email, string firstName, string lastName, string password, string role = "admin")
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
        }
    }
}