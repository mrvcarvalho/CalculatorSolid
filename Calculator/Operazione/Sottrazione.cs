using Calculator.Operazione;

namespace CalculatorSOLID.Operazione
{
    public class Sottrazione : OperazioneBase
    {
        public Sottrazione() : base("-") { }

        public override double Esegui(double a, double b)
        {
            // Calcola
            return a - b;
        }
    }
}
