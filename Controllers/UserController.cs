using Microsoft.AspNetCore.Mvc;
using AztroWebApplication.Models;
using AztroWebApplication.Services;
using AztroWebApplication.Data;

namespace AztroWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(ApplicationDbContext context)
    {
        userService = new UserService(context);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(users);
    }
}
