using MediatR;
using ToDoApi.Command;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Handlers;

public class AddNewToDoItemHandler:IRequestHandler<AddNewToDoItemCommand,TodoItem>
{
    
    private readonly IToDoData _toDoData;
    //mapper
    public AddNewToDoItemHandler(IToDoData toDoData)
    {
        _toDoData = toDoData;
        //mapper
    }
    public Task<TodoItem> Handle(AddNewToDoItemCommand request, CancellationToken cancellationToken)
    {
        // TodoItem.Id= Guid.NewGuid();
        // _toDoData.CreateToDoItem(request.TodoItem);
        throw new NotImplementedException();
    }
}