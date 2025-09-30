using System;

namespace CorridaBeneficente.Models
{
    public class Participante : Pessoa
    {
        public int NumeroInscricao { get; private set; }

        private decimal _valorInscricao;
        public decimal ValorInscricao
        {
            get => _valorInscricao;
            private set => _valorInscricao = value >= 0 ? value
                : throw new ArgumentException("Valor da inscrição inválido.");
        }

        public Participante(
            int numeroInscricao,
            string nome,
            string cpf,
            string email,
            string telefone,
            decimal valorInscricao
        ) : base(nome, cpf, email, telefone)
        {
            NumeroInscricao = numeroInscricao;
            ValorInscricao = valorInscricao;
        }
    }
}
