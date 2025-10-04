// Models/SchdeualModel.cs

using System;
using System.ComponentModel.DataAnnotations;

public class SchdeualModel
{
    // Primary Key
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty; // Optional detail

    public bool IsComplete { get; set; } = false; // Tracks completion status

    // For the future 'Category' feature:
    public string Category { get; set; } = "General"; 

    public DateTime DateCreated { get; set; } = DateTime.Now;
}
