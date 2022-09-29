using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests_Ex1.Tests
{
    public class UrnaTestes
    {

        [Fact]
        //TesteConstrutorAdicionandoDadosCorretos
        public void Construtor_ConstrutorVazio_DadosCorretos()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var vencedorEleicao = urna.VencedorEleicao;
            var votosVencedor = urna.VotosVencedor;
            var candidatos = urna.Candidatos;
            var eleicaoAtiva = urna.EleicaoAtiva;

            //Assert
            Assert.Equal("", vencedorEleicao);
            Assert.Equal(0, votosVencedor);
            Assert.Empty(candidatos);
            Assert.False(eleicaoAtiva);
        }

        [Fact]
        //TesteVotacaoIniciando
        public void IniciarEncerrarEleicao_IniciarEncerrarEleicao_RetornaVerdadeiro()
        {
            //Arrange
            var urna = new Urna();

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            Assert.True(urna.EleicaoAtiva);
        }

        [Fact]
        //TesteVotacaoEncerrando
        public void IniciarEncerrarEleicao_IniciarEncerrarEleicao_RetornaFalso()
        {
            //Arrange
            var urna = new Urna();

            //Act
            urna.IniciarEncerrarEleicao();
            urna.IniciarEncerrarEleicao();

            //Assert
            Assert.False(urna.EleicaoAtiva);
        }

        [Fact]
        //TesteCandidatoCadastradoEUltimoDaLista
        public void CadastrarCandidato_AdicionaCandidato_RetornaNomeDoUltimoCandidato()
        {
            //Arrange
            var urna = new Urna();
            var nome1 = "Fulano da Silva";
            var nome2 = "Ciclado de Souza";

            //Act
            urna.CadastrarCandidato(nome1);
            urna.CadastrarCandidato(nome2);
            var candidato = urna.Candidatos.Last();

            //Assert
            Assert.Equal(nome2, candidato.Nome);
        }

        [Fact]
        //TesteVotacaoCandidatoNaoCadastrado
        public void Votar_CandidatoNaoCadastrado_RetornaFalso()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var votoBemSucedido = urna.Votar("Fulano da Silva");


            //Assert
            Assert.False(votoBemSucedido);
        }

        [Fact]
        //TesteVotacaoCandidatoCadastrado
        public void Votar_CandidatoCadastrado_RetornaVerdadeiro()
        {
            //Arrange
            var urna = new Urna();
            var name = "Fulano da Silva";

            //Act
            urna.CadastrarCandidato(name);
            var votoBemSucedido = urna.Votar(name);

            //Assert
            Assert.True(votoBemSucedido);
        }

        [Fact]
        public void MostrarResultadoEleicao_MostrarResultadoEleicao_RetornaString()
        {
            //Arrange
            var urna = new Urna();
            var nome1 = "Fulano da Silva";
            var nome2 = "Ciclano Moreira";
            var resultadoEsperado = $"Nome vencedor: {nome2}. Votos: 2";

            //Act
            urna.CadastrarCandidato(nome1);
            urna.CadastrarCandidato(nome2);

            urna.Votar(nome1);
            urna.Votar(nome2);
            urna.Votar(nome2);

            var resultado = urna.MostrarResultadoEleicao();

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
