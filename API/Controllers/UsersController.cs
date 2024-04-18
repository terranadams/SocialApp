using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // this will work when user hit hostname.com/api/users
public class UsersController : ControllerBase {
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet] 
    public ActionResult<IEnumerable<AppUser>> GetUser() {

        var users = _context.Users.ToList();

        return users;
    }

    [HttpGet("{id}")] // /api/users/3
    public ActionResult<AppUser> GetUser(int id) {
        return _context.Users.Find(id);
    }

}