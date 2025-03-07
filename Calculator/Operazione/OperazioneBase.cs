using CalculatorSOLID.Operazione;

namespace Calculator.Operazione
{
    public abstract class OperazioneBase : IOperazione
    {
        private readonly string _symbol;

        protected OperazioneBase(string symbol)
        {
            _symbol = symbol;
        }

        public abstract double Esegui(double a, double b);

        public string GetSymbol()
        {
            return _symbol;
        }

        protected static void ControllaDivisionePerZero(double b)
        {
            if (b == 0)
                throw new DivideByZeroException("La divisione per zero non è permessa.");
        }
    }
}
