﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public EGender Gender { get; set; }
        [Required]
        public EUserRoles Role { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

    }
}