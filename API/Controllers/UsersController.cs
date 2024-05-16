using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController 
{
    private readonly DataContext _context; // DataContext is injected to interact with the database.

    public UsersController(DataContext context)
    {
        _context = context; // Constructor to initialize DataContext through dependency injection.
    }

    [AllowAnonymous]
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUser() {

        var users = await _context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id) {
        return await _context.Users.FindAsync(id);
    }

}