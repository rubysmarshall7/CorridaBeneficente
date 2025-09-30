using System;
using System.Windows;
using CorridaBeneficente.Models;

namespace CorridaBeneficente
{
    public partial class MainWindow : Window
    {
        private readonly GerenciadorInscricoes _gerenciador;

        public MainWindow()
        {
            InitializeComponent();

            // define a corrida e o gerenciador (NUNCA deixe null)
            var corrida = new Corrida(
                nomeCorrida: "Corrida Beneficente",
                dataCorrida: DateTime.Today.AddDays(30),
                valorPadraoInscricao: 50.00m
            );

            _gerenciador = new GerenciadorInscricoes(corrida);

            TxtDataCorrida.Text = corrida.DataCorrida.ToShortDateString();

            AtualizarGrid();
            AtualizarEstatisticas();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _gerenciador.CadastrarParticipante(
                    TxtNome.Text,
                    TxtCPF.Text,
                    TxtEmail.Text,
                    TxtTelefone.Text
                );

                AtualizarGrid();
                AtualizarEstatisticas();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dados inválidos",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e) => LimparCampos();

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (GridParticipantes.SelectedItem is Participante selecionado)
            {
                _gerenciador.RemoverParticipante(selecionado.NumeroInscricao);
                AtualizarGrid();
                AtualizarEstatisticas();
            }
            else
            {
                MessageBox.Show("Selecione um participante para remover.", "Atenção",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LimparCampos()
        {
            TxtNome.Text = "";
            TxtCPF.Text = "";
            TxtEmail.Text = "";
            TxtTelefone.Text = "";
            TxtNome.Focus();
        }

        private void AtualizarGrid()
        {
            GridParticipantes.ItemsSource = null;
            GridParticipantes.ItemsSource = _gerenciador.ListarParticipantes();
        }

        private void AtualizarEstatisticas()
        {
            var (total, arrecadado) = _gerenciador.ObterEstatisticas();
            TxtTotal.Text = total.ToString();
            TxtArrecadado.Text = $"R$ {arrecadado:F2}";
        }
    }
}
