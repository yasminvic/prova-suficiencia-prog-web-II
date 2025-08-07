using Domain.DTO;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            UsuarioDTO user = new UsuarioDTO();
            try
            {
                user = await _service.FindById(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Post(UsuarioDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            return new ObjectResult(await _service.Save(user));
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioDTO>> Put(UsuarioDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            return new ObjectResult(await _service.Save(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
