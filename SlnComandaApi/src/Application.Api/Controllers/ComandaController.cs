using Application.Api.DTO;
using Domain.DTO;
using Domain.Entity;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<ComandaDTO>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseApiDTO
                {
                    status = 500,
                    message = "Erro ao buscar comandas.",
                    details = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ComandaDTO>> GetById(int id)
        {
            ComandaDTO comanda = new ComandaDTO();
            try
            {
                comanda = await _service.FindById(id);
                if (comanda == null)
                {
                    return StatusCode(404, new ResponseApiDTO
                    {
                        status = 404,
                        message = "Não encontrado",
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ComandaDTO>> Post(ComandaDTO comanda)
        {
            if (comanda == null)
            {
                return BadRequest();
            }

            try
            {
                return new ObjectResult(await _service.Save(comanda));
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ComandaDTO>> Put(ComandaDTO comanda)
        {
            if (comanda == null)
            {
                return BadRequest();
            }

            try
            {
                return new ObjectResult(await _service.Save(comanda));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                if (result == 1)
                {
                    return StatusCode(200, new ResponseApiDTO
                    {
                        status = 200,
                        message = "Excluído com sucesso.",
                    });
                }
                else
                {
                    return StatusCode(500, new ResponseApiDTO
                    {
                        status = 500,
                        message = "Erro ao deletar.",
                    });
                }               
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }
    }
}
