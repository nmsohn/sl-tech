using Microsoft.AspNetCore.Mvc;

namespace Vanilla.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
public class UserController
{
    
}