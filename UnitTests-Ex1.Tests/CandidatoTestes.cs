namespace UnitTests_Ex1.Tests
{
    public class CandidatoTestes
    {
        [Fact]
        //TesteQuantidadeDeVotosAoCadastrarCandidato
        public void Construtor_ConstrutorPadrao_CandidatoZeroVotos()
        {
            //Arrange
            var nome = "Fulano";

            //Act
            var candidato = new Candidato("Fulano");

            //Assert
            Assert.Equal(0, candidato.Votos);
        }

        [Fact]
        //TesteVotoAdicionadoCorretamente
        public void Construtor_ConstrutorPadrao_CandidatoUmVoto()
        {
            //Arrange
            var candidato = new Candidato("Fulano");

            //Act
            candidato.AdicionarVoto();

            //Assert
            Assert.Equal(1, candidato.Votos);
        }
        public void Construtor_ConstrutorPadrao_NomeCorreto()
        {
            //Arrange
            var nome = "Fulano";

            //Act
            var candidato = new Candidato(nome);

            //Assert
            Assert.Equal(nome, candidato.Nome);
        }
    }
}