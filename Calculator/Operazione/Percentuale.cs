using Calculator.Operazione;

namespace CalculatorSOLID.Operazione
{
    public class Percentuale : OperazioneBase
    {
        public Percentuale() : base("%") { }

        public override double Esegui(double a, double b)
        {
            // Calcola la percentuale di `a` rispetto a `b`
            return (a * (b/100));
        }
    }
}
