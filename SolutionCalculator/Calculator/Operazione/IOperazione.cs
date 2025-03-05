namespace CalculatorSOLID.Operazione
{
    public interface IOperazione
    {
        double Esegui(double a, double b);

        string GetSymbol();
    }
}