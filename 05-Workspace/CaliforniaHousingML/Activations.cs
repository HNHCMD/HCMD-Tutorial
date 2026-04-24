namespace CaliforniaHousingML;

public interface IActivation
{
    double Activate(double x);
    double Derivative(double x);
}

public class TanhActivation : IActivation
{
    public double Activate(double x)
    {
        return Math.Tanh(x);
    }

    public double Derivative(double x)
    {
        double tanh = Math.Tanh(x);
        return 1 - tanh * tanh;
    }
}

public class LinearActivation : IActivation
{
    public double Activate(double x)
    {
        return x;
    }

    public double Derivative(double x)
    {
        return 1.0;
    }
}
