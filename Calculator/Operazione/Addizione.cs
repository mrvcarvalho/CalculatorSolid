using Calculator.Operazione;

namespace CalculatorSOLID.Operazione
{
    public class Addizione : OperazioneBase
    {
        public Addizione() : base("+") { }

        public override double Esegui(double a, double b)
        {
            // Calcola
            return a + b;
        }
    }
}
