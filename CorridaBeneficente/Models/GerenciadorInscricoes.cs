using System;
using System.Collections.Generic;

namespace CorridaBeneficente.Models
{
    public class GerenciadorInscricoes
    {
        private int _contadorInscricao = 1;
        public Corrida CorridaAtual { get; private set; }

        public GerenciadorInscricoes(Corrida corrida)
        {
            CorridaAtual = corrida ?? throw new ArgumentNullException(nameof(corrida));
        }

        public Participante CadastrarParticipante(string nome, string cpf, string email, string telefone)
        {
            var participante = new Participante(
                _contadorInscricao++,
                nome, cpf, email, telefone,
                CorridaAtual.ValorPadraoInscricao
            );
            CorridaAtual.AdicionarParticipante(participante);
            return participante;
        }

        public List<Participante> ListarParticipantes() => CorridaAtual.ListaParticipantes;

        public bool RemoverParticipante(int numeroInscricao) => CorridaAtual.RemoverParticipante(numeroInscricao);

        public (int total, decimal arrecadado) ObterEstatisticas()
            => (CorridaAtual.ObterTotalParticipantes(), CorridaAtual.CalcularTotalArrecadado());
    }
}
