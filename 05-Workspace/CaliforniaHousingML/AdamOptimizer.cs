namespace CaliforniaHousingML;

public class AdamOptimizer
{
    private readonly double _learningRate;
    private readonly double _beta1;
    private readonly double _beta2;
    private readonly double _epsilon;
    private int _t;

    private List<double[,]> _mWeights;
    private List<double[]> _mBiases;
    private List<double[,]> _vWeights;
    private List<double[]> _vBiases;

    public AdamOptimizer(double learningRate = 0.001, double beta1 = 0.9, double beta2 = 0.999, double epsilon = 1e-8)
    {
        _learningRate = learningRate;
        _beta1 = beta1;
        _beta2 = beta2;
        _epsilon = epsilon;
        _t = 0;

        _mWeights = new List<double[,]>();
        _mBiases = new List<double[]>();
        _vWeights = new List<double[,]>();
        _vBiases = new List<double[]>();
    }

    public void Initialize(List<DenseLayer> layers)
    {
        _mWeights.Clear();
        _mBiases.Clear();
        _vWeights.Clear();
        _vBiases.Clear();

        foreach (var layer in layers)
        {
            int inputSize = layer.Weights.GetLength(0);
            int outputSize = layer.Weights.GetLength(1);

            _mWeights.Add(new double[inputSize, outputSize]);
            _mBiases.Add(new double[outputSize]);
            _vWeights.Add(new double[inputSize, outputSize]);
            _vBiases.Add(new double[outputSize]);
        }
    }

    public void Update(List<DenseLayer> layers)
    {
        _t++;

        for (int l = 0; l < layers.Count; l++)
        {
            var layer = layers[l];
            int inputSize = layer.Weights.GetLength(0);
            int outputSize = layer.Weights.GetLength(1);

            for (int i = 0; i < inputSize; i++)
            {
                for (int j = 0; j < outputSize; j++)
                {
                    double grad = layer.WeightGradients[i, j];

                    _mWeights[l][i, j] = _beta1 * _mWeights[l][i, j] + (1 - _beta1) * grad;
                    _vWeights[l][i, j] = _beta2 * _vWeights[l][i, j] + (1 - _beta2) * grad * grad;

                    double mHat = _mWeights[l][i, j] / (1 - Math.Pow(_beta1, _t));
                    double vHat = _vWeights[l][i, j] / (1 - Math.Pow(_beta2, _t));

                    layer.Weights[i, j] -= _learningRate * mHat / (Math.Sqrt(vHat) + _epsilon);
                }
            }

            for (int j = 0; j < outputSize; j++)
            {
                double grad = layer.BiasGradients[j];

                _mBiases[l][j] = _beta1 * _mBiases[l][j] + (1 - _beta1) * grad;
                _vBiases[l][j] = _beta2 * _vBiases[l][j] + (1 - _beta2) * grad * grad;

                double mHat = _mBiases[l][j] / (1 - Math.Pow(_beta1, _t));
                double vHat = _vBiases[l][j] / (1 - Math.Pow(_beta2, _t));

                layer.Biases[j] -= _learningRate * mHat / (Math.Sqrt(vHat) + _epsilon);
            }
        }
    }
}
