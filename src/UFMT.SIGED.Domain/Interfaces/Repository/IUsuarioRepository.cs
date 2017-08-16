using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository :
            IRepository<Usuario>
    {
        Usuario Autenticar(string email, string senha);
    }
}
