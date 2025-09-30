using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CorridaBeneficente.Models
{
    public abstract class Pessoa
    {
        private string _nome = "";
        private string _cpf = "";     // guardamos só dígitos aqui
        private string _email = "";
        private string _telefone = "";

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome é obrigatório.");
                _nome = value.Trim();
            }
        }

        public string CPF
        {
            // exibe formatado 000.000.000-00
            get => Convert.ToUInt64(_cpf).ToString(@"000\.000\.000\-00");
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CPF é obrigatório.");

                var digits = Regex.Replace(value, "[^0-9]", "");
                if (digits.Length != 11)
                    throw new ArgumentException("CPF deve ter 11 dígitos numéricos.");
                _cpf = digits;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email é obrigatório.");
                try
                {
                    _ = new MailAddress(value);
                    _email = value.Trim();
                }
                catch { throw new ArgumentException("Email inválido."); }
            }
        }

        public string Telefone
        {
            get => _telefone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Telefone é obrigatório.");
                _telefone = value.Trim();
            }
        }

        protected Pessoa(string nome, string cpf, string email, string telefone)
        {
            Nome = nome; CPF = cpf; Email = email; Telefone = telefone;
        }
    }
}
