using Microsoft.AspNetCore.Mvc;
using Meetzy.Application.UseCases.Users.Commands.CreateUser;
using Meetzy.Application.UseCases.Users.Commands.DeleteUser;
using Meetzy.Application.UseCases.Users.Commands.UpdateUser;
using Meetzy.Application.UseCases.Users.Queries.GetAllUsers;
using Meetzy.Application.UseCases.Users.Queries.GetUserById;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Web.Controllers;

public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _mediator.Send(new GetAllUsersRequest());
        return View(users);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        await _mediator.Send(request);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdRequest(id));
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateUserRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        await _mediator.Send(request);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUserRequest(id));
        return RedirectToAction("Index");
    }
}