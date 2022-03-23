using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto04_csharp.Entities;
using Projeto04_csharp.Interfaces;
using System.Data.SqlClient;
using Dapper;

namespace Projeto04_csharp.Repositories
{
    /// <summary>
    /// Classe para implementar o repositorio de Clientes
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        //atributo
        private readonly string _connectionString = @"Data Source=SRVSQLSERVER;Initial Catalog=DBProjeto04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Create(Cliente obj)
        {
            //conectando na base através da connectionString
            using (var connection = new SqlConnection(_connectionString))
            {
                //esxecuta a procedure para cadastro de cliente
                connection.Execute("SP_INSERIRCLIENTE", new
                {
                    @NOME = obj.Nome,
                    @CPF = obj.Cpf,
                    @DATANASCIMENTO = obj.DataNascimento
                },
                commandType: System.Data.CommandType.StoredProcedure);


            }
        }

        public void Delete(Cliente obj)
        {
            //conectando na base através da connectionString
            using (var connection = new SqlConnection(_connectionString))
            {
                //esxecuta a procedure para excluir cliente
                connection.Execute("SP_EXCLUIRCLIENTE", new
                {
                    @IDCLIENTE = obj.IdCliente
                },
                commandType: System.Data.CommandType.StoredProcedure);


            }
        }

        public List<Cliente> GetAll()
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    ORDER BY NOME ASC
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Cliente>(sql)
                    .ToList();
            }

        }

        public Cliente GetById(Guid id)
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    WHERE IDCLIENTE = @PARAM
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(sql, new { @PARAM = id }).FirstOrDefault();
            }

        }

        public List<Cliente> GetByNome(string nome)
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    WHERE NOME LIKE @PARAM
                    ORDER BY NOME ASC
                ";


            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Cliente>(sql, new { @PARAM = $"%{nome}%" })
                    .ToList();
            }

        }

        public void Update(Cliente obj)
        {
            //conectando na base através da connectionString
            using (var connection = new SqlConnection(_connectionString))
            {
                //esxecuta a procedure para atualizar cliente
                connection.Execute("SP_ATUALIZARCLIENTE", new
                {
                    @IDCLIENTE = obj.IdCliente,
                    @NOME = obj.Nome,
                    @CPF = obj.Cpf,
                    @DATANASCIMENTO = obj.DataNascimento
                },
                commandType: System.Data.CommandType.StoredProcedure);


            }
        }
    }
}
