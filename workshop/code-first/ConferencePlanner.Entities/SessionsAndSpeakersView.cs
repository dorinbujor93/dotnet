using System;
using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.Entities
{
    public class AllSessionsAndSpeakersView
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        public virtual DateTimeOffset? StartTime { get; set; }
    }
}