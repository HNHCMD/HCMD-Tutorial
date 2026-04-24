namespace CaliforniaHousingML;

public class MLP
{
    private readonly List<DenseLayer> _layers;

    public MLP()
    {
        _layers = new List<DenseLayer>();
    }

    public void AddLayer(DenseLayer layer)
    {
        _layers.Add(layer);
    }

    public double[] Forward(double[] input)
    {
        double[] output = input;
        foreach (var layer in _layers)
        {
            output = layer.Forward(output);
        }
        return output;
    }

    public void Backward(double[] lossGradient)
    {
        double[] gradient = lossGradient;
        for (int i = _layers.Count - 1; i >= 0; i--)
        {
            gradient = _layers[i].Backward(gradient);
        }
    }

    public void ZeroGradients()
    {
        foreach (var layer in _layers)
        {
            layer.ZeroGradients();
        }
    }

    public List<DenseLayer> GetLayers()
    {
        return _layers;
    }

    public double ComputeMSE(double[][] X, double[] y)
    {
        double totalError = 0;
        for (int i = 0; i < X.Length; i++)
        {
            double[] prediction = Forward(X[i]);
            double error = prediction[0] - y[i];
            totalError += error * error;
        }
        return totalError / X.Length;
    }

    public double ComputeMSE(double[][] X, double[] y, StandardScaler scaler)
    {
        double totalError = 0;
        for (int i = 0; i < X.Length; i++)
        {
            double[] prediction = Forward(X[i]);
            double predUnscaled = scaler.InverseTransform(prediction[0]);
            double actualUnscaled = scaler.InverseTransform(y[i]);
            double error = predUnscaled - actualUnscaled;
            totalError += error * error;
        }
        return totalError / X.Length;
    }
}
