namespace CaliforniaHousingML;

public class Trainer
{
    private readonly MLP _model;
    private readonly AdamOptimizer _optimizer;
    private readonly int _batchSize;
    private readonly int _epochs;
    private readonly Random _random;

    public Trainer(MLP model, AdamOptimizer optimizer, int batchSize = 64, int epochs = 500, int seed = 42)
    {
        _model = model;
        _optimizer = optimizer;
        _batchSize = batchSize;
        _epochs = epochs;
        _random = new Random(seed);
    }

    public void Train(double[][] XTrain, double[] yTrain)
    {
        Train(XTrain, yTrain, null);
    }

    public void Train(double[][] XTrain, double[] yTrain, StandardScaler? targetScaler)
    {
        _optimizer.Initialize(_model.GetLayers());

        for (int epoch = 0; epoch < _epochs; epoch++)
        {
            var indices = Enumerable.Range(0, XTrain.Length).OrderBy(x => _random.Next()).ToArray();

            double epochLoss = 0;
            double epochLossUnscaled = 0;
            int numBatches = 0;

            for (int batchStart = 0; batchStart < XTrain.Length; batchStart += _batchSize)
            {
                int batchEnd = Math.Min(batchStart + _batchSize, XTrain.Length);
                int currentBatchSize = batchEnd - batchStart;

                _model.ZeroGradients();
                double batchLoss = 0;
                double batchLossUnscaled = 0;

                for (int i = batchStart; i < batchEnd; i++)
                {
                    int idx = indices[i];
                    double[] input = XTrain[idx];
                    double target = yTrain[idx];

                    double[] prediction = _model.Forward(input);
                    double error = prediction[0] - target;
                    batchLoss += error * error;

                    if (targetScaler != null)
                    {
                        double predUnscaled = targetScaler.InverseTransform(prediction[0]);
                        double targetUnscaled = targetScaler.InverseTransform(target);
                        double errorUnscaled = predUnscaled - targetUnscaled;
                        batchLossUnscaled += errorUnscaled * errorUnscaled;
                    }

                    double[] lossGradient = new double[] { 2 * error / currentBatchSize };
                    _model.Backward(lossGradient);
                }

                _optimizer.Update(_model.GetLayers());

                epochLoss += batchLoss;
                epochLossUnscaled += batchLossUnscaled;
                numBatches++;
            }

            epochLoss /= XTrain.Length;
            epochLossUnscaled /= XTrain.Length;

            if (epoch % 25 == 0 || epoch == _epochs - 1)
            {
                if (targetScaler != null)
                {
                    Console.WriteLine($"Epoch {epoch + 1}/{_epochs}, Loss: {epochLoss:F4}, Loss (unscaled): {epochLossUnscaled:F2}");
                }
                else
                {
                    Console.WriteLine($"Epoch {epoch + 1}/{_epochs}, Loss: {epochLoss:F4}");
                }
            }
        }
    }
}
