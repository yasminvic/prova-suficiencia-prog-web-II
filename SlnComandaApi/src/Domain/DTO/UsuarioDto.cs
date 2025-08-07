using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public bool ValidaSenha(string senha)
        {
            return this.senha.Equals(senha);
        }

        public Usuario mapToEntity()
        {
            return new Usuario
            {
                Id = id,
                Email = email,
                Senha = senha
            };
        }

        public UsuarioDTO mapToDTO(Usuario user)
        {
            return new UsuarioDTO
            {
                id = user.Id,
                email = user.Email,
                senha = user.Senha
            };
        }
    }
}
