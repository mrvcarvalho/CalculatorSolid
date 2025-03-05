using CalculatorSOLID.Calculator;

namespace Calculator.UserScreen
{
    public class CalculatorRunner
    {
        private readonly Calcolatrice _calcolatrice;

        public CalculatorRunner()
        {
            _calcolatrice = new Calcolatrice();
        }

        // Esegue una singola iterazione dell'esecuzione, restituendo false se non ci sono più input
        public bool RunIteration(TextReader input, TextWriter output)
        {
            output.WriteLine("\n----------\nCalcolatrice (Ctrl+C per uscire)\n");

            // Valida il primo numero
            output.Write("Inserisci il primo numero: ");
            string? input1 = input.ReadLine();
            if (string.IsNullOrEmpty(input1) || !double.TryParse(input1, out double num1))
            {
                output.WriteLine("Errore: Il primo numero non è valido.");
                return true; // Continue para nova iteração
            }

            // Valida l'operazione
            output.Write($"Inserisci l'operazione \n( {_calcolatrice.GetMenuOperazioni()} ): ");
            string? operazione = input.ReadLine();
            if (string.IsNullOrEmpty(operazione))
            {
                output.WriteLine("Errore: L'operazione non può essere nulla o vuota.");
                return true;
            }
            if (!_calcolatrice.IsOperazioneValid(operazione))
            {
                output.WriteLine($"Errore: L'operazione '{operazione}' non è valida.");
                return true;
            }

            // Valida il secondo numero
            output.Write("Inserisci il secondo numero: ");
            string? input2 = input.ReadLine();
            if (string.IsNullOrEmpty(input2) || !double.TryParse(input2, out double num2))
            {
                output.WriteLine("Errore: Il secondo numero non è valido.");
                return true;
            }

            try
            {
                double risultato = _calcolatrice.Calcola(operazione, num1, num2);
                output.WriteLine($"Risultato: {risultato}");
            }
            catch (Exception ex)
            {
                output.WriteLine($"Errore: {ex.Message}");
            }

            return true;
        }
    }
}
