using api_safe_trade.Application.Interfaces;
using api_safe_trade.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_safe_trade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] Usuario input)
        {
            if (input is null)
                return BadRequest("Usuário inválido");

            await _userService.CreateUserAsync(input);

            return CreatedAtAction(nameof(input), new { id = input.Id }, input);
        }
    }
}
