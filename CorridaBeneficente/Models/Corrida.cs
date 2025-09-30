using System;
using System.Collections.Generic;
using System.Linq;

namespace CorridaBeneficente.Models
{
    public class Corrida
    {
        public string NomeCorrida { get; private set; }
        public DateTime DataCorrida { get; private set; }
        public decimal ValorPadraoInscricao { get; private set; }
        public List<Participante> ListaParticipantes { get; } = new();

        public Corrida(string nomeCorrida, DateTime dataCorrida, decimal valorPadraoInscricao)
        {
            NomeCorrida = string.IsNullOrWhiteSpace(nomeCorrida) ? "Corrida Beneficente" : nomeCorrida.Trim();
            DataCorrida = dataCorrida;
            ValorPadraoInscricao = valorPadraoInscricao >= 0 ? valorPadraoInscricao : 0;
        }

        public void AdicionarParticipante(Participante participante) => ListaParticipantes.Add(participante);

        public bool RemoverParticipante(int numeroInscricao)
        {
            var p = ListaParticipantes.FirstOrDefault(x => x.NumeroInscricao == numeroInscricao);
            return p != null && ListaParticipantes.Remove(p);
        }

        public int ObterTotalParticipantes() => ListaParticipantes.Count;

        public decimal CalcularTotalArrecadado() => ListaParticipantes.Sum(p => p.ValorInscricao);
    }
}
