using CalculatorSOLID.Operazione;

namespace CalculatorTest
{
    public class OperazioniTest
    {
        [Fact]
        public void Addizione_DeveRestituireUnRisultatoCorreto()
        {
            // Arrange
            Addizione adicao = new Addizione();

            // Act
            double resultado = adicao.Esegui(2, 3);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(5, resultado);
        }


        [Fact]
        public void Sottrazione_DeveRestituireUnRisultatoCorreto()
        {
            // Arrange:
            Sottrazione subtracao = new Sottrazione();

            // Act:
            double resultado = subtracao.Esegui(5, 3);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(2, resultado);
        }


        [Fact]
        public void Moltiplicazione_DeveRestituireUnRisultatoCorreto()
        {
            // Arrange:
            Moltiplicazione multiplicacao = new Moltiplicazione();

            // Act:
            double resultado = multiplicacao.Esegui(4, 5);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(20, resultado);
        }


        [Fact]
        public void Percentuale_DeveRestituireUnRisultatoCorreto()
        {
            // Arrange:
            Percentuale percentuale = new Percentuale();

            // Act:
            double resultado = percentuale.Esegui(50, 1500);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(750, resultado);
        }


        [Fact]
        public void Divisione_DeveRestituireUnRisultatoCorreto()
        {
            // Arrange:
            Divisione divisione = new Divisione();

            // Act:
            double resultado = divisione.Esegui(10, 2);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(5, resultado);
        }
        
        
        [Fact]
        public void Divisione_ErrorePerZeroDovrebbeLanciareUnEccezione()
        {
            // Arrange: Crea e prepara tutte le istanze necessarie per avviare il test 
            Divisione divisione = new Divisione();

            // Act: Esegue l'operazione con i valori proposti
            var exception = Assert.Throws<System.DivideByZeroException>(() => divisione.Esegui(10, 0));

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal("La divisione per zero non è permessa.", exception.Message);
        }


        [Theory]
        [InlineData(typeof(Addizione),       2,  3,  5)]
        [InlineData(typeof(Sottrazione),     5,  3,  2)]
        [InlineData(typeof(Moltiplicazione), 4,  5, 20)]
        [InlineData(typeof(Divisione),      10,  2,  5)]
        [InlineData(typeof(Percentuale),    60,500,300)]
        public void Operazioni_RisultatiDevonoEssereCorretti(Type operazioneType, double a, double b, double risultatoAtteso)
        {
            // Arrange: Crea un'istanza dell'operazione usando la reflection
            IOperazione operazione = (IOperazione)Activator.CreateInstance(operazioneType)!;

            // Act: Esegue l'operazione con i valori forniti
            double risultato = operazione.Esegui(a, b);

            // Assert: Verifica che il risultato sia uguale a quello atteso
            Assert.Equal(risultatoAtteso, risultato);
        }


        [Theory]
        [InlineData(typeof(Addizione), "+")]
        [InlineData(typeof(Sottrazione), "-")]
        [InlineData(typeof(Moltiplicazione), "*")]
        [InlineData(typeof(Divisione), "/")]
        public void GetSymbol_RestituisceTuttiSimboliCorretti(Type operazioneType, string expectedSymbol)
        {
            // Arrange: crea un'istanza dell'operazione usando la reflection
            IOperazione operazione = (IOperazione)Activator.CreateInstance(operazioneType)!;

            // Act: richiama il metodo GetSymbol
            string symbol = operazione.GetSymbol();

            // Assert: Controlla che il simbolo restituito sia quello previsto
            Assert.Equal(expectedSymbol, symbol);
        }
    }
}