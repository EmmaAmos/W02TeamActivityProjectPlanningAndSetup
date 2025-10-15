// Models/SchedualModel.cs

using System;
using System.ComponentModel.DataAnnotations;

namespace SchedualMe.Models // The namespace that other files reference
{
    public class SchedualModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; 

        public bool IsComplete { get; set; } = false; 

        public string Category { get; set; } = "General"; 

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}