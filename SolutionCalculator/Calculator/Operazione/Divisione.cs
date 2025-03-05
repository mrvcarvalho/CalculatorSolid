using Calculator.Operazione;

namespace CalculatorSOLID.Operazione
{
    public class Divisione : OperazioneBase
    {
        public Divisione() : base("/") { }

        public override double Esegui(double a, double b)
        {
            ControllaDivisionePerZero(b);
            return a / b;
        }
    }
}
