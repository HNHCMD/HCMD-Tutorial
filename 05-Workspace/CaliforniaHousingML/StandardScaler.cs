namespace CaliforniaHousingML;

public class StandardScaler
{
    private double[]? _means;
    private double[]? _stds;
    private double? _mean1D;
    private double? _std1D;

    public void Fit(double[][] data)
    {
        int numSamples = data.Length;
        int numFeatures = data[0].Length;

        _means = new double[numFeatures];
        _stds = new double[numFeatures];

        for (int j = 0; j < numFeatures; j++)
        {
            double sum = 0;
            for (int i = 0; i < numSamples; i++)
            {
                sum += data[i][j];
            }
            _means[j] = sum / numSamples;
        }

        for (int j = 0; j < numFeatures; j++)
        {
            double sumSquaredDiff = 0;
            for (int i = 0; i < numSamples; i++)
            {
                double diff = data[i][j] - _means[j];
                sumSquaredDiff += diff * diff;
            }
            _stds[j] = Math.Sqrt(sumSquaredDiff / numSamples);
            if (_stds[j] < 1e-8)
                _stds[j] = 1.0;
        }
    }

    public void Fit(double[] data)
    {
        int numSamples = data.Length;

        double sum = 0;
        for (int i = 0; i < numSamples; i++)
        {
            sum += data[i];
        }
        _mean1D = sum / numSamples;

        double sumSquaredDiff = 0;
        for (int i = 0; i < numSamples; i++)
        {
            double diff = data[i] - _mean1D.Value;
            sumSquaredDiff += diff * diff;
        }
        _std1D = Math.Sqrt(sumSquaredDiff / numSamples);
        if (_std1D < 1e-8)
            _std1D = 1.0;
    }

    public double[][] Transform(double[][] data)
    {
        if (_means == null || _stds == null)
            throw new InvalidOperationException("Scaler must be fitted before transform");

        int numSamples = data.Length;
        int numFeatures = data[0].Length;
        double[][] scaled = new double[numSamples][];

        for (int i = 0; i < numSamples; i++)
        {
            scaled[i] = new double[numFeatures];
            for (int j = 0; j < numFeatures; j++)
            {
                scaled[i][j] = (data[i][j] - _means[j]) / _stds[j];
            }
        }

        return scaled;
    }

    public double[] Transform(double[] data)
    {
        if (_mean1D == null || _std1D == null)
            throw new InvalidOperationException("Scaler must be fitted before transform");

        int numSamples = data.Length;
        double[] scaled = new double[numSamples];

        for (int i = 0; i < numSamples; i++)
        {
            scaled[i] = (data[i] - _mean1D.Value) / _std1D.Value;
        }

        return scaled;
    }

    public double InverseTransform(double value)
    {
        if (_mean1D == null || _std1D == null)
            throw new InvalidOperationException("Scaler must be fitted before inverse transform");

        return value * _std1D.Value + _mean1D.Value;
    }

    public double[][] FitTransform(double[][] data)
    {
        Fit(data);
        return Transform(data);
    }

    public double[] FitTransform(double[] data)
    {
        Fit(data);
        return Transform(data);
    }
}
