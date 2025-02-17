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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);
        if (user == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            var newUser = await userService.CreateUser(user);
            return Created(nameof(GetUserById), newUser);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponse { Message = e.Message, StatusCode =  400});
        }
    }
}
