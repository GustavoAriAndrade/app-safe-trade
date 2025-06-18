using api_safe_trade.Application.Interfaces;
using api_safe_trade.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_safe_trade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        ICameraService _cameraService;
        IVideoCaptureService _videoCaptureService;

        public CameraController(ICameraService cameraService,
                                IVideoCaptureService videoCaptureService)
        {
            _cameraService = cameraService;
            _videoCaptureService = videoCaptureService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Camera input)
        {
            if (input is null)
                return BadRequest("Câmera inválido");

            await _cameraService.CreateAsync(input);

            return CreatedAtAction(nameof(input), new { id = input.Id }, input);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetListAsync()
        {
            var cameras = await _cameraService.GetListAsync();

            return Ok(cameras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetByIdAsync(int id)
        {
            var camera = await _cameraService.GetByIdAsync(id);

            if (camera is null)
                return NotFound();

            return Ok(camera);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Camera input)
        {
            if (input is null || id != input.Id)
                return BadRequest("Dados inválidos.");

            await _cameraService.UpdateAsync(input);

            return Ok();
        }

        [HttpPost("start-capture/{id}")]
        public IActionResult StartCapture(int id)
        {
            var camera = _cameraService.GetById(id);

            if (camera is null) 
                return NotFound();

            _videoCaptureService.StartCapture(camera.IpAddress);

            return Ok("Captura iniciada.");
        }
    }
}