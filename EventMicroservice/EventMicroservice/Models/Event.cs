using System;
using System.ComponentModel.DataAnnotations;

namespace EventMicroservice.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        public string Description { get; set; }
    }
}
