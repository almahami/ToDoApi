using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public class TodoItem
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }
    [Required]
    public bool IsComplete { get; set; }

}