using MediatR;
using ToDoApi.Models;

namespace ToDoApi.Queries;

// 2_becuse it is return a< ist< of toDOItem
public class GetAllToDOItemesQuery:IRequest<List<TodoItem>>
{

}