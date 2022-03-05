using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Data;

public interface IToDoData
{
    List<TodoItem>GetToDoItems();
    TodoItem GetTodoItem(Guid id);
    TodoItem CreateToDoItem(TodoItem todoItem);
    TodoItem EditToDoItem(Guid id, TodoItem todoItem);
    void RemoveToDoItem(TodoItem todoItem);
    
    

}