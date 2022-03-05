using MediatR;
using ToDoApi.Models;

namespace ToDoApi.Queries;

public class GetToDoItemByIDQuery: IRequest<TodoItem>
{
    public  Guid Id { get; }

    public GetToDoItemByIDQuery(Guid id)
    {
        this.Id = id;
    }
}