using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Models;

public class TodoItemContext :DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    
    public string DbPath { get; }
    
    public TodoItemContext(DbContextOptions<TodoItemContext> opt) : base(opt)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ToDoListDB.db");
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");





}