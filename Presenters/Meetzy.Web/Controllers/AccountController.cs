using Meetzy.Application.UseCases.Users.Commands.CreateUser;
using Meetzy.Application.UseCases.Users.Commands.LoginUser;
using Meetzy.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;
// Importa el Mediator de tu proyecto

public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        try
        {
            var result = await _mediator.Send(request);
            // Guardar sesión (HttpContext.Session o Claims)
            HttpContext.Session.SetString("UserName", result.Name);
            HttpContext.Session.SetString("UserRole", result.Role);
            HttpContext.Session.SetString("UserId", result.UserId.ToString());
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(request);
        }
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        await _mediator.Send(request);
        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}