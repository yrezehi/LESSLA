﻿using Core.Authentication;
using Core.Models.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("users")]
    public class User : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("authentication_type")]
        public AuthenticationType AuthenticationType { get; set; } = AuthenticationType.ActiveDirectory;

        public virtual ICollection<Application> Applications { get; set; }
        
        public User(string username) =>
            (Username, Email) = (username, User.StripUsername(username));

        private static string StripUsername(string email) =>
            email.Contains('@') ? email.Split('@')[0] : email;
    }
}
