// Models/SchedualModel.cs

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity; // Needed for the IdentityUser navigation property

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

        // ===========================================
        // NEW: Properties for User Linkage (Authorization)
        // ===========================================
        
        // 1. Foreign Key: Stores the unique ID of the user who owns this task
        [Required] // Tasks must belong to a user
        public string UserId { get; set; } = string.Empty; 

        // 2. Navigation Property (Optional but helpful):
        // Allows Entity Framework to load the entire user object if needed.
        // public IdentityUser User { get; set; } 
    }
}