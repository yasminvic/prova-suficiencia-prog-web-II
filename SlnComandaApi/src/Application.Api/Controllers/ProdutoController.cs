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
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
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
                    message = "Erro ao buscar.",
                });

            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            ProdutoDTO produto = new ProdutoDTO();
            try
            {
                produto = await _service.FindById(id);
                if(produto == null)
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
                return StatusCode(404, new ResponseApiDTO
                {
                    status = 404,
                    message = "Não encontrado",
                });
            }

            return Ok(produto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> Post(ProdutoDTO produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            try
            {          
                var result = await _service.Save(produto);
                if (result == 1)
                {
                    return StatusCode(200, new ResponseApiDTO
                    {
                        status = 200,
                        message = "Cadastrado com sucesso.",
                    });
                }
                else
                {
                    return StatusCode(500, new ResponseApiDTO
                    {
                        status = 500,
                        message = "Erro ao cadastrar.",
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> Put(ProdutoDTO produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _service.Save(produto);
                if (result == 1)
                {
                    return StatusCode(200, new ResponseApiDTO
                    {
                        status = 200,
                        message = "Cadastrado com editar.",
                    });
                }
                else
                {
                    return StatusCode(500, new ResponseApiDTO
                    {
                        status = 500,
                        message = "Erro ao editar.",
                    });
                }
            }
            catch
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
                        message = "Erro ao excluir.",
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
