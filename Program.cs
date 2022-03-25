using Projeto04_csharp.Controllers;
using Projeto04_csharp.Entities;
using System;

namespace ProjetoAula04
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteController = new ClienteController();
            clienteController.ManterClientes();
        }
    }
}
