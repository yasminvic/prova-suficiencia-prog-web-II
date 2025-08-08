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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
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
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            UsuarioDTO user = new UsuarioDTO();
            try
            {
                user = await _service.FindById(id);
                if (user == null)
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

            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> Post(UsuarioDTO user)
        {
            if (user == null)
            {
                return StatusCode(404, new ResponseApiDTO
                {
                    status = 404,
                    message = "Não encontrado",
                });
            }

            try
            {
                var result = await _service.Save(user);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> Put(UsuarioDTO user)
        {
            if (user == null)
            {
                return StatusCode(404, new ResponseApiDTO
                {
                    status = 404,
                    message = "Não encontrado",
                });
            }

            try
            {
                var result = await _service.Save(user);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
            
        }
    }
}
