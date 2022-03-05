using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Data;

public class SqlToDOItemData:IToDoData
{
    private readonly TodoItemContext _todoItemContext;

    public SqlToDOItemData(TodoItemContext todoItemContext)
    {
        _todoItemContext = todoItemContext;
    }

    public List<TodoItem> GetToDoItems()
    {
        List<TodoItem> todoItemsList = _todoItemContext.TodoItems.ToList();
        return todoItemsList;
    }

    public TodoItem GetTodoItem(Guid id)
    {
        var existingTodoItem = _todoItemContext.TodoItems.SingleOrDefault(todo => todo.Id == id);
        return existingTodoItem;
    }

    public TodoItem CreateToDoItem(TodoItem todoItem)
    {
        _todoItemContext.TodoItems.Add(todoItem);
        _todoItemContext.SaveChangesAsync();
        return todoItem;
    }

    public TodoItem EditToDoItem(Guid id, TodoItem todoItem)
    {
         var existingTodoItem = _todoItemContext.TodoItems.SingleOrDefault(todo => todo.Id == id);
         _todoItemContext.TodoItems.Update(existingTodoItem);
         _todoItemContext.SaveChangesAsync();
         return existingTodoItem;
    }

    public void RemoveToDoItem(TodoItem todoItem)
    {
            _todoItemContext.TodoItems.Remove(todoItem);
            _todoItemContext.SaveChangesAsync();
    }
    
}