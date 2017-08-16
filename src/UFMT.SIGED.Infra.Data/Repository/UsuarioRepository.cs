using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Domain.Interfaces.Repository;
using UFMT.SIGED.Infra.Data.Context;

namespace UFMT.SIGED.Infra.Data.Repository
{
    public class UsuarioRepository
           : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SIGEDContext context)
            : base(context)
        {
        }

        public Usuario Autenticar(string email, string senha)
        {
            return DbSet
                .Where(u =>
                        u.Email.ToLower() == email.ToLower()
                        && u.Senha.ToLower() == senha.ToLower()
                       ).FirstOrDefault();
        }
    }
}
