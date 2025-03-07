using Calculator.Operazione;

namespace CalculatorSOLID.Operazione
{
    public class Moltiplicazione : OperazioneBase
    {
        public Moltiplicazione() : base("*") { }

        public override double Esegui(double a, double b)
        {
            // Calcola
            return a * b;
        }
    }
}
