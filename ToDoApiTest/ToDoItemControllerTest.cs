using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Controllers;
using ToDoApi.Data;
using ToDoApi.Models;
using Xunit;

namespace ToDoApiTest;

public class ToDoItemControllerTest
{
    private readonly ToDoItemsFake _toDoItemsFake;
    private readonly TodoController _controller;
    public ToDoItemControllerTest()
    {
        _toDoItemsFake = new ToDoItemsFake();
        _controller = new TodoController(_toDoItemsFake);
    }

    [Fact]
    public void GetWhenCalledReturnAllItems()
    {
        //act
        var result = _controller.GetToDoItems() as OkObjectResult;
        //assert
        var items = Assert.IsType<List<TodoItem>>(result.Value);
        Assert.Equal(3, items.Count );
    }

    [Fact]
    public void GetWhenCalledReturnsOKResult()
    {
        //arrange 
        var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        //act
        var okResult = _controller.GetTodoItem(testGuid) as OkObjectResult;
        //assert
        Assert.IsType<OkObjectResult>(okResult);
    }
    [Fact]
    public void GetToDoItemByIDReturnNotFoundResult()
    {
        //arrange
        var testGuid = new Guid();
        //act
        var notFoundResult = _controller.GetTodoItem(testGuid);
        //assert
        Assert.IsType<NotFoundObjectResult>(notFoundResult as NotFoundObjectResult);
    }

    [Fact]
    public void GetByIDExistingGuidPassedRetunRightItem()
    {
        //arrange
        var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        //act
        var okResult = _controller.GetTodoItem(testGuid) as OkObjectResult;
        //assert
        Assert.IsType<TodoItem>(okResult.Value);
        Assert.Equal(testGuid,(okResult.Value as TodoItem).Id);
    }

    [Fact]
    public void AddIvaildObjectPassedReturnBadRequest()
    {
        //arrange
        var todoItem = new TodoItem() {Id = new Guid(), IsComplete = true};
        _controller.ModelState.AddModelError("Name","Required");
        //act
        var badResponse = _controller.PostTodoItem(todoItem);
        //assert
        Assert.IsType<BadRequestObjectResult>(badResponse);
    }

    [Fact]
    public void AddVaildObjectPassedReturnCreatedResponse()
    {
        //arrange
        var todoItem = new TodoItem() {Id = new Guid(),Name = "clean office",IsComplete = true};
        //act
        var createdResposne = _controller.PostTodoItem(todoItem);
        //assert
        Assert.IsType<CreatedAtActionResult>(createdResposne);
    }

    [Fact]
    public void AddValidObjectPassedReturnedResponseHasCreatedItem()
    {
        //arange
        var todoItem = new TodoItem() {Id = new Guid(),Name = "make cupe of tee",IsComplete = false};
        //act
        var createdResponse = _controller.PostTodoItem(todoItem) as CreatedAtActionResult;
        var item = createdResponse.Value as TodoItem;
        //assert
        Assert.IsType<TodoItem>(item);
        Assert.Equal("make cupe of tee", item.Name);
    }

    [Fact]
    public void RemoveNotExistingGuidPassedReturnNotFoundResponse()
    {
        //arrange
        var testGuid = new Guid();
        //act
        var badResponse = _controller.removeToDoitem(testGuid) as NotFoundObjectResult;
        //assert
        Assert.IsType<NotFoundObjectResult>(badResponse);
    }

    [Fact]
    public void RemoveExistingGuidPassedRemovesOnItem()
    {
        //arrange
        var existingGuid = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
        //act
        var okResponse = _controller.removeToDoitem(existingGuid) as OkObjectResult;
        //assert
        Assert.Equal(2, _toDoItemsFake.GetToDoItems().Count);
    }
    
    [Fact]
    public void RemoveExistingGuidPassedReturnsNoContentResult()
    {
        // Arrange
        var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        // Act
        var noContentResponse = _controller.removeToDoitem(testGuid);
        // Assert
        Assert.IsType<NoContentResult>(noContentResponse);
    }

    [Fact]
    public void EditNotExistingTODOItemReturnNotFoundResponse()
    {
        //arrange
        var testGuid = new Guid();
        var newTODoItem = new TodoItem() {Id = new Guid(), Name = "answer the phone message ", IsComplete = true};
        //act
        var notFoundResponse = _controller.EditToDoItem(testGuid, newTODoItem) as NotFoundObjectResult;
        //assert
        Assert.IsType<NotFoundObjectResult>(notFoundResponse);
    }

    [Fact]
    public void EditExistingToDoItemReturnEditToDoItem()
    {
        //arrage
        var existingGuid = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
        var newToDoItem = new TodoItem() {Id = new Guid(), Name = "bay headseat", IsComplete = false};
        //act
        var editResponse = _controller.EditToDoItem(existingGuid, newToDoItem) as OkObjectResult;
        var todoitem = editResponse.Value;
        //assert
        Assert.IsType<TodoItem>(todoitem);
       Assert.IsType<OkObjectResult>(editResponse);
        
    }
}