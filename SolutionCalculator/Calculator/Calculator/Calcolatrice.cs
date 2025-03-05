using CalculatorSOLID.Operazione;

namespace CalculatorSOLID.Calculator
{
    public class Calcolatrice
    {
        private readonly IDictionary<string, IOperazione> _operazioni = new Dictionary<string, IOperazione>(StringComparer.OrdinalIgnoreCase);

        public Calcolatrice()
        {
            // Elenco delle operazioni disponibili
            IOperazione[] operazioniDisponibili =
            [
                new Addizione(),
                new Sottrazione(),
                new Moltiplicazione(),
                new Divisione(),
                new Percentuale(),
            ];

            // Aggiungiamo ogni operazione al dizionario utilizzando il simbolo restituito da GetSymbol()
            foreach (var operazione in operazioniDisponibili)
            {
                _operazioni.Add(operazione.GetSymbol(), operazione);
            }
        }
        public double Calcola(string operazione, double a, double b)
        {
            if (!_operazioni.TryGetValue(operazione, out IOperazione? value))
                throw new ArgumentException("Operazione non valida!");

            return value.Esegui(a, b);
        }

        public string GetMenuOperazioni()
        {
            return string.Join(" ", _operazioni.Keys);
        }

        public bool IsOperazioneValid(string op)
        {
            return _operazioni.ContainsKey(op);
        }
    }
}
