// using Microsoft.AspNetCore.Mvc;
// using Vanilla.Application.Features.User;
// using Vanilla.Dtos.Requests.User;
//
// namespace Vanilla.API.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// [Produces("application/json")]
// [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
// public class UserController(IUserRepository repository) : ControllerBase
// {
//     [HttpPost]
//     public async Task<ActionResult<CreateUserRequestDto>> CreateUserAsync([FromBody] CreateUserRequestDto createUserRequestDto)
//     {
//         var user = await repository.CreateAsync(createUserRequestDto);
//
//         if (user == null)
//         {
//             return NotFound(new Exception());
//         }
//
//         return Created(
//             $"{nameof(UserController).Replace(nameof(Controller), "")}/{user.Id}",
//             user);
//     }
// }