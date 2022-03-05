using ToDoApi.Models;

namespace ToDoApi.Data;

public class ToDoItemsFake : IToDoData
{
    private readonly List<TodoItem> toDoItemsList;
   
    public ToDoItemsFake()
    {
        toDoItemsList = new List<TodoItem>()
        {
            new TodoItem() {Id =  new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Name = "read a book ", IsComplete = true},
            new TodoItem() {Id =  new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Name = "go for a walk ", IsComplete = false},
            new TodoItem() {Id =  new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"), Name = "cooking", IsComplete = false}
        };

    }
    public List<TodoItem> GetToDoItems()
    {
        return toDoItemsList; 
    }

    public TodoItem GetTodoItem(Guid id)
    {
        return toDoItemsList.SingleOrDefault(toDoItem => toDoItem.Id == id);
    }

    public TodoItem CreateToDoItem(TodoItem todoItem)
    {
        todoItem.Id = Guid.NewGuid();
        toDoItemsList.Add(todoItem);
        return todoItem;
    }

    public TodoItem EditToDoItem(Guid id, TodoItem todoItem)
    {
        var existingToDoItem = GetTodoItem(id);
        existingToDoItem.Name = todoItem.Name;
        existingToDoItem.IsComplete = todoItem.IsComplete;
        return existingToDoItem;
    }

    public void RemoveToDoItem(TodoItem todoItem)
    {
        toDoItemsList.Remove(todoItem);
    }
}