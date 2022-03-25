using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto04_csharp.Entities;
using Projeto04_csharp.Repositories;

namespace Projeto04_csharp.Controllers
{
    /// <summary>
    /// Classe de controle de aplicação para os eventos de Cliente
    /// </summary>
    public class ClienteController
    {
        /// <summary>
        /// Método para gerar a interface de usuário do projeto
        /// </summary>
        public void ManterClientes()
        {
            try
            {
                Console.WriteLine("\n *** CONTROLE DE CLIENTES *** \n");
                Console.WriteLine("(1) - CADASTRAR CLIENTE");
                Console.WriteLine("(2) - ATUALIZAR CLIENTE");
                Console.WriteLine("(3) - EXCLUIR CLIENTE");
                Console.WriteLine("(4) - CONSULTAR TODOS OS CLIENTES");
                Console.WriteLine("(5) - CONSULTAR CLIENTES POR NOME");
                Console.Write("\n");

                Console.Write("Informe a ação desejada....: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        AtualizarCliente();
                        break;

                    case 3:
                        ExcluirCliente();
                        break;

                    case 4:
                        ConsultarClientes();
                        break;

                    case 5:
                        ConsultarClientesPorNome();
                        break;

                    default:
                        throw new Exception("Opção inválida.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }
            finally
            {
                Console.Write("\nDeseja continuar? (S,N): ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear(); //limpar o console
                    ManterClientes(); //recursividade
                }
                else
                    Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }

        //método privado para fazer o fluxo de cadastro do cliente
        private void CadastrarCliente()
        {
            var cliente = new Cliente();

            Console.WriteLine("\nCADASTRO DE CLIENTE\n");

            Console.Write("ENTRE COM O NOME DO CLIENTE....: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("ENTRE COM O CPF DO CLIENTE.....: ");
            cliente.Cpf = Console.ReadLine();

            Console.Write("ENTRE COM A DATA DE NASCIMENTO.: ");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            var clienteRepository = new ClienteRepository();

            clienteRepository.Create(cliente);
            Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!\n");
        }

        //método privado para fazer o fluxo de atualizar o cliente
        private void AtualizarCliente()
        {
            Console.WriteLine("\nATUALIZAR DE CLIENTE\n");

            Console.Write("ENTRE COM O ID DO CLIENTE......: ");
            var idCliente = Guid.Parse(Console.ReadLine());

            //buscar o cliente no banco de dados com ID informado
            var clienteRepository = new ClienteRepository();
            var cliente = clienteRepository.GetById(idCliente);

            //verificar se o cliente foi encontrado
            if (cliente != null)
            {
                Console.Write("ENTRE COM O NOME DO CLIENTE....: ");
                cliente.Nome = Console.ReadLine();


                Console.Write("ENTRE COM O CPF DO CLIENTE.....: ");
                cliente.Cpf = Console.ReadLine();

                Console.Write("ENTRE COM A DATA DE NASCIMENTO.: ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                clienteRepository.Update(cliente);
                Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO!\n");
            }
            else
            {
                throw new Exception("Cliente não foi encontrado.");
            }
        }

        //método privado para fazer o fluxo de excluir o cliente
        private void ExcluirCliente()
        {
            Console.WriteLine("\nEXCLUSÃO DE CLIENTE\n");

            Console.Write("ENTRE COM O ID DO CLIENTE......: ");
            var idCliente = Guid.Parse(Console.ReadLine());

            //buscar o cliente no banco de dados com ID informado
            var clienteRepository = new ClienteRepository();
            var cliente = clienteRepository.GetById(idCliente);

            //verificar se o cliente foi encontrado
            if (cliente != null)
            {
                clienteRepository.Delete(cliente);
                Console.WriteLine("\nCLIENTE EXCLUÍDO COM SUCESSO!\n");
            }
            else
            {
                throw new Exception("Cliente não foi encontrado.");
            }
        }

        //método privado para fazer o fluxo de consulta dos clientes
        private void ConsultarClientes()
        {
            Console.WriteLine("\nCONSULTA DE CLIENTES\n");

            var clienteRepository = new ClienteRepository();

            foreach (var item in clienteRepository.GetAll())
            {
                Console.WriteLine($"ID.................: {item.IdCliente}");
                Console.WriteLine($"NOME DO CLIENTE....: {item.Nome}");
                Console.WriteLine($"CPF................: {item.Cpf}");
                Console.WriteLine($"DATA DE NASCIMENTO.: {item.DataNascimento.ToString("dd/MM/yyyy")}");
                Console.WriteLine("...");
            }

        }




        //método privado para fazer o fluxo de consulta dos clientes por nome
        private void ConsultarClientesPorNome()
        {
            Console.WriteLine("\nCONSULTA DE CLIENTES POR NOME\n");

            Console.Write("ENTRE COM O NOME DO CLIENTE....: ");
            var nome = Console.ReadLine();

            var clienteRepository = new ClienteRepository();

            foreach (var item in clienteRepository.GetByNome(nome))
            {
                Console.WriteLine($"ID.................: {item.IdCliente}");
                Console.WriteLine($"NOME DO CLIENTE....: {item.Nome}");
                Console.WriteLine($"CPF................: {item.Cpf}");
                Console.WriteLine($"DATA DE NASCIMENTO.: {item.DataNascimento.ToString("dd/MM/yyyy")}");
                Console.WriteLine("...");
            }
        }
    }
}





