using Domain.DTO;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            ProdutoDTO produto = new ProdutoDTO();
            try
            {
                produto = await _service.FindById(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post(ProdutoDTO produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }
            return new ObjectResult(await _service.Save(produto));
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDTO>> Put(ProdutoDTO produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            return new ObjectResult(await _service.Save(produto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
