using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Command;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoApi.Queries;

namespace ToDoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{

    private readonly IToDoData _toDoData;
    private readonly IMediator _mediator;

    public TodoController(IToDoData toDoData)
    {
        _toDoData = toDoData;
        //_mediator = mediator;
    }

    [HttpGet]
    public ActionResult GetToDoItems()
    {
        //1
        // var query = new GetAllToDOItemesQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        List<TodoItem> toDoItemsList = _toDoData.GetToDoItems();
        if (toDoItemsList.Any())
        {
            return Ok(toDoItemsList);
        }
        return NotFound("Nothing to do ");
    }

    [HttpGet("id")]
    public ActionResult GetTodoItem(Guid id)
    {
        // var query = new GetToDoItemByIDQuery(id);
        // var result = await _mediator.Send(query);
        // return result != null ? Ok(result) : NotFound("");
        //change below
        var toToItem = _toDoData.GetTodoItem(id);
        if (toToItem !=  null)
        {
            return Ok(toToItem);
        }

        return NotFound($"toDO Item with id: {id} was Not found");
    }

    [HttpPost]
    public ActionResult PostTodoItem(TodoItem todoItem)
    {
        // var command = new AddNewToDoItemCommand();
        // var result = _mediator.Send(command);
        // return Ok(todoItem);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        todoItem.Id= Guid.NewGuid();
        _toDoData.CreateToDoItem(todoItem);
        return CreatedAtAction("GetTodoItem",new{id = todoItem.Id},todoItem);
    }

    [HttpPut]
    public ActionResult EditToDoItem(Guid id, TodoItem todoItem)
    {
        var existingToDoItem = _toDoData.GetTodoItem(id);
        if(existingToDoItem != null)
        {
            todoItem.Id = existingToDoItem.Id;
            existingToDoItem.Name = todoItem.Name;
            existingToDoItem.IsComplete = todoItem.IsComplete;
            _toDoData.EditToDoItem(todoItem.Id, existingToDoItem);
            return Ok(existingToDoItem);
        }
        return NotFound($"The given TODO item was Not Found, Edit Fail");
    }

    [HttpDelete]
    public ActionResult removeToDoitem(Guid id)
    {
        var existingToDoItem = _toDoData.GetTodoItem(id);
        if(existingToDoItem != null)
        {
            _toDoData.RemoveToDoItem(existingToDoItem);
            //return Ok("Delleted ToDO Item was successfully");
            return NoContent();
        }

        return NotFound($"TODO Item was not found, Delete Fail");
    }
}