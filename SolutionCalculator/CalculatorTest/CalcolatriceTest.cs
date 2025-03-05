using Calculator.UserScreen;
using CalculatorSOLID.Calculator;

namespace CalculatorTest
{
    public class CalcolatriceTest
    {
        [Theory]
        [InlineData("+",  4, 6, 10)]
        [InlineData("-", 10, 4,  6)]
        [InlineData("*",  3, 3,  9)]
        [InlineData("/", 20, 5,  4)]
        public void CalcolatriceDeveEseguireOperazioniCorrettamente(string operazione, double a, double b, double risultatoAtteso)
        {
            // Arrange
            var calcolatrice = new Calcolatrice();

            // Act
            double risultato = calcolatrice.Calcola(operazione, a, b);

            // Assert
            Assert.Equal(risultatoAtteso, risultato);
        }

        [Theory]
        [InlineData("a",  4, 6)]
        [InlineData("b", 10, 4)]
        [InlineData(" ",  3, 3)]
        [InlineData("",  20, 5)]
        public void CalcolatriceOpezazioneInvalidaDeveAvviareException(string operazione, double a, double b)
        {
            // Arrange
            var calcolatrice = new Calcolatrice();

            // Act
            var exception = Assert.Throws<ArgumentException>(() => calcolatrice.Calcola(operazione, a, b));

            // Assert
            Assert.Equal("Operazione non valida!", exception.Message);
        }

        [Fact]
        public void CalcolatriceDivisionePerZeroDovrebbeAvviareException()
        {
            // Arrange
            var calcolatrice = new Calcolatrice();

            // Act
            var exception = Assert.Throws<DivideByZeroException>(() => calcolatrice.Calcola("/", 11, 0));

            // Assert
            Assert.Equal("La divisione per zero non è permessa.", exception.Message);
        }

        [Fact]
        public void GetOperazioniRitornaTutteLeOperazioniDisponibili()
        {
            // Arrange
            var calcolatrice = new Calcolatrice();

            // Act
            string operazioni = calcolatrice.GetMenuOperazioni();

            // Assert
            // Verifica che tutte le operazioni siano presenti nella stringa resultante
            Assert.Contains("+", operazioni);
            Assert.Contains("-", operazioni);
            Assert.Contains("*", operazioni);
            Assert.Contains("/", operazioni);
        }

        [Theory]
        [InlineData("+", true)]
        [InlineData("-", true)]
        [InlineData("*", true)]
        [InlineData("/", true)]
        public void IsOperazioneValidValidaCorrettamenteLOperazione(string op, bool expected)
        {
            // Arrange
            var calcolatrice = new Calcolatrice();

            // Act
            bool result = calcolatrice.IsOperazioneValid(op);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc\n",   "+\n",   "1\n", "Errore: Il primo numero non è valido.")]
        [InlineData(   "\n",   "+\n",   "1\n", "Errore: Il primo numero non è valido.")]
        [InlineData(  "1\n", "abc\n",   "1\n", "Errore: L'operazione 'abc' non è valida.")]
        [InlineData(  "1\n",    "\n",   "1",   "Errore: L'operazione non può essere nulla o vuota.")]
        [InlineData(  "1\n",   "+\n", "abc\n", "Errore: Il secondo numero non è valido.")]
        [InlineData(  "1\n",   "+\n",    "\n", "Errore: Il secondo numero non è valido.")]
        [InlineData("333\n",   "*\n",   "3\n", "Risultato: 999")]
        [InlineData("333\n",   "/\n",   "0\n", "La divisione per zero non è permessa.")]
        public void RunIteration_PrimoSecondoTerzoInputInvalido_StampaMessaggioErrore(string input1, string input2, string input3, string result)
        {
            // Arrange: simula un primo numero non valido e alcuni input successivi
            // In questo esempio, dopo il messaggio di errore, l'iterazione termina.
            // Consideriamo che venga eseguita una sola iterazione.
            string simulatedInput = input1 + input2 + input3;
            // Gli altri input non sono necessari, in quanto l'esecuzione fallirà già quando il primo numero verrà validato
            using var input = new StringReader(simulatedInput);
            using var output = new StringWriter();

            var runner = new CalculatorRunner();

            // Act: esegue un'iterazione
            runner.RunIteration(input, output);

            // Assert: controlla se il messaggio di errore è stato scritto sull'output
            string consoleOutput = output.ToString();
            Assert.Contains(result, consoleOutput);
        }
    }
}