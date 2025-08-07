using Domain.DTO;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : Controller
    {
        private readonly IComandaService _service;

        public ComandaController(IComandaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComandaDTO>>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComandaDTO>> GetById(int id)
        {
            ComandaDTO comanda = new ComandaDTO();
            try
            {
                comanda = await _service.FindById(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        [HttpPost]
        public async Task<ActionResult<ComandaDTO>> Post(ComandaDTO comanda)
        {
            if (comanda == null)
            {
                return BadRequest();
            }
            return new ObjectResult(await _service.Save(comanda));
        }

        [HttpPut]
        public async Task<ActionResult<ComandaDTO>> Put(ComandaDTO comanda)
        {
            if (comanda == null)
            {
                return BadRequest();
            }

            return new ObjectResult(await _service.Save(comanda));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
