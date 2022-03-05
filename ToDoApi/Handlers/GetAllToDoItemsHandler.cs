using MediatR;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoApi.Queries;

namespace ToDoApi.Handlers;
// IRequestHandler<Query,Response>
public class GetAllToDoItemsHandler :IRequestHandler<GetAllToDOItemesQuery,List<TodoItem>>
{
    private readonly IToDoData _toDoData;
    //mapper
    public GetAllToDoItemsHandler(IToDoData toDoData)
    {
        _toDoData = toDoData;
        //mapper
    }

    public async Task<List<TodoItem>> Handle(GetAllToDOItemesQuery request, CancellationToken cancellationToken)
    {
        List<TodoItem> toDoItemsList = _toDoData.GetToDoItems();
        //return mapper
        return toDoItemsList;
    }
}