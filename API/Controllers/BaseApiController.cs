using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // The ApiController attribute is used to denote a web API controller and enables certain
    // behaviors such as automatic model state validation and automatic HTTP 400 responses.
    [ApiController]

    // The Route attribute defines a route template. The "[controller]" placeholder is replaced
    // by the controller's name when constructing the URL. For instance, a "UsersController" 
    // inheriting from BaseApiController will have routes starting with "api/users".
    [Route("api/[controller]")]
    

    public class BaseApiController : ControllerBase
    {

    }
    // BaseApiController serves as a base class for other API controllers in your application.
    // It inherits from ControllerBase, which provides access to several properties and methods
    // useful for handling HTTP requests, such as Ok(), BadRequest(), NotFound(), and more.
    
}