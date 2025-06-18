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
        public async Task<ActionResult> CreateAsync([FromBody] Usuario input)
        {
            if (input is null)
                return BadRequest("Usuário inválido");

            await _userService.CreateAsync(input);

            return CreatedAtAction(nameof(input), new { id = input.Id }, input);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetListAsync()
        {
            var usuarios = await _userService.GetListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int id)
        {
            var usuario = await _userService.GetByIdAsync(id);

            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Usuario input)
        {
            if (input is null || id != input.Id)
                return BadRequest("Dados inválidos.");

            await _userService.UpdateAsync(input);

            return Ok();
        }
    }
}
