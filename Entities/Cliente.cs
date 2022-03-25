using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Projeto04_csharp.Entities
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }

        private string _nome; //atributo
        public string Nome
        {

            get => _nome; // retorna o valor do atributo
            set //recebe o valor do campo
            {
                //valida se o nome está vazio
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Nome do cliente é obrigatório.");
                //valida se o nome contém números
                else if (Regex.IsMatch(value, @"^[0-9]+$"))
                    throw new ArgumentException("Nome do cliente não pode conter números.");
                else if (Regex.IsMatch(value, @"^[@!#$%&*(){}/[\]\><?º°ª,;|'_""¨+=-]$"))
                    throw new ArgumentException("Nome do cliente não pode conter caracteres especiais.");
                //valida se o nome tem entre 10 e 150 caracteres
                else if (value.Length < 10 || value.Length > 150)
                    throw new ArgumentException("Nome do cliente deve ter de 10 a 150 caracteres.");
                else
                    _nome = value; //armazenando o valor recebido
            }
        }
        private string _cpf; //atributo
        public string Cpf
        {

            get => _cpf; // retorna o valor do atributo
            set //recebe o valor do campo
            {
                //valida se o cpf está vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("CPF é obrigatório.");

                //valida se o cpf tem 14 caracteres contando os pontos e o traço
                //else if (!Regex.IsMatch(value, @"^{14}$"))
                    //throw new ArgumentException("CPF deve ter 11 números separados por (.) e (-). Ex.: 000.000.000-00 .");

                
                //valida se o cpf esta no formato padrão
                else if (!Regex.IsMatch(value, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
                    throw new ArgumentException("CPF deve ser digitado nesse formato. Ex.: 000.000.000-00");
                //valida se o cpf contem caracteres especiais
                else if (Regex.IsMatch(value, @"^[@!#$%&*(){}/[\]\><`´?º°ª,;|'_""¨+=]$"))
                    throw new ArgumentException("CPF deve conter somente números.");
                //valida se o cpf contém somente números
                else if (Regex.IsMatch(value, @"^[aA-zA]$"))
                    throw new ArgumentException("CPF não pode conter letras.");
                else
                    _cpf = value; //armazenando o valor recebido
            }
        }
        private DateTime _dataNascimento;
            public DateTime DataNascimento 
                { 
                    get => _dataNascimento;
                    set
                    {
                        //Não permite clientes menores de idade
                        var idade = DateTime.Now.Year - value.Year;
                        var convertIdade = idade.ToString();
                        if (DateTime.Now.DayOfYear < value.DayOfYear)
                            idade--;

                        if (idade < 18)
                            throw new ArgumentException
                              ("O cliente deve ser maior de idade.");

                        else if (!Regex.IsMatch(convertIdade, @"^\d{2}\/\d{2}\/\d{4}$"))
                            throw new ArgumentException("Data de Nascimento deve ser separado por (/). Ex.: 00/00/0000");

                        else
                            _dataNascimento = value;

            }

        }


    }
}
