using MediatR;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoApi.Queries;

namespace ToDoApi.Handlers;

public class GetToDOItemByIdHandler : IRequestHandler <GetToDoItemByIDQuery,TodoItem>
{
    
    private readonly IToDoData _toDoData;
    //mapper
    public GetToDOItemByIdHandler(IToDoData toDoData)
    {
        _toDoData = toDoData;
        //mapper
    }
    public async Task<TodoItem> Handle(GetToDoItemByIDQuery request, CancellationToken cancellationToken)
    {
        var toToItem = _toDoData.GetTodoItem(request.Id);

        if (toToItem == null)
        {
            return null;
        }

        return toToItem;
    }
}