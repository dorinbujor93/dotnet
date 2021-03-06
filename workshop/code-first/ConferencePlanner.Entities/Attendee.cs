using System;

namespace ConferencePlanner.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string LastName { get; set; }


        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(256)]
        public virtual string EmailAddress { get; set; }
        

    }
}
