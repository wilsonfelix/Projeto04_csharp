using Projeto04_csharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04_csharp.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>

    /// <summary>
    /// Interface para definição dos métodos do repositorio de Cliente
    /// </summary>

    {

        List<Cliente> GetByNome(string nome);
        

    }
}
