namespace CaliforniaHousingML;

public class DenseLayer
{
    private readonly int _inputSize;
    private readonly int _outputSize;
    private readonly IActivation _activation;
    private readonly Random _random;

    public double[,] Weights { get; private set; }
    public double[] Biases { get; private set; }

    public double[,] WeightGradients { get; private set; }
    public double[] BiasGradients { get; private set; }

    public double[]? LastInput { get; private set; }
    public double[]? LastPreActivation { get; private set; }
    public double[]? LastOutput { get; private set; }

    public DenseLayer(int inputSize, int outputSize, IActivation activation, int seed = 42)
    {
        _inputSize = inputSize;
        _outputSize = outputSize;
        _activation = activation;
        _random = new Random(seed);

        Weights = new double[inputSize, outputSize];
        Biases = new double[outputSize];
        WeightGradients = new double[inputSize, outputSize];
        BiasGradients = new double[outputSize];

        InitializeWeights();
    }

    private void InitializeWeights()
    {
        double limit = Math.Sqrt(6.0 / (_inputSize + _outputSize));
        for (int i = 0; i < _inputSize; i++)
        {
            for (int j = 0; j < _outputSize; j++)
            {
                Weights[i, j] = (_random.NextDouble() * 2 - 1) * limit;
            }
        }

        for (int j = 0; j < _outputSize; j++)
        {
            Biases[j] = 0.0;
        }
    }

    public double[] Forward(double[] input)
    {
        LastInput = input;
        LastPreActivation = new double[_outputSize];
        LastOutput = new double[_outputSize];

        for (int j = 0; j < _outputSize; j++)
        {
            double sum = Biases[j];
            for (int i = 0; i < _inputSize; i++)
            {
                sum += input[i] * Weights[i, j];
            }
            LastPreActivation[j] = sum;
            LastOutput[j] = _activation.Activate(sum);
        }

        return LastOutput;
    }

    public double[] Backward(double[] outputGradient)
    {
        if (LastInput == null || LastPreActivation == null)
            throw new InvalidOperationException("Forward pass must be called before backward");

        double[] inputGradient = new double[_inputSize];

        for (int j = 0; j < _outputSize; j++)
        {
            double activationGrad = _activation.Derivative(LastPreActivation[j]);
            double delta = outputGradient[j] * activationGrad;

            BiasGradients[j] += delta;

            for (int i = 0; i < _inputSize; i++)
            {
                WeightGradients[i, j] += delta * LastInput[i];
                inputGradient[i] += delta * Weights[i, j];
            }
        }

        return inputGradient;
    }

    public void ZeroGradients()
    {
        Array.Clear(WeightGradients, 0, WeightGradients.Length);
        Array.Clear(BiasGradients, 0, BiasGradients.Length);
    }
}
