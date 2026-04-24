namespace CaliforniaHousingML;

public class DataLoader
{
    public static (double[][] X, double[] y) LoadCSV(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var data = new List<double[]>();
        var targets = new List<double>();

        string[] headers = lines[0].Split(',');
        int targetIndex = Array.IndexOf(headers, "median_house_value");

        if (targetIndex == -1)
        {
            throw new Exception("Target column 'median_house_value' not found");
        }

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            var values = lines[i].Split(',');
            var features = new List<double>();

            for (int j = 0; j < values.Length; j++)
            {
                if (j == targetIndex)
                {
                    if (double.TryParse(values[j], out double target))
                    {
                        targets.Add(target);
                    }
                }
                else
                {
                    if (double.TryParse(values[j], out double feature))
                    {
                        features.Add(feature);
                    }
                }
            }

            if (features.Count > 0 && targets.Count == i)
            {
                data.Add(features.ToArray());
            }
        }

        return (data.ToArray(), targets.ToArray());
    }

    public static (double[][] XTrain, double[] yTrain, double[][] XTest, double[] yTest) 
        TrainTestSplit(double[][] X, double[] y, double testRatio = 0.2, int seed = 42)
    {
        var random = new Random(seed);
        int n = X.Length;
        var indices = Enumerable.Range(0, n).OrderBy(x => random.Next()).ToArray();

        int testSize = (int)(n * testRatio);
        int trainSize = n - testSize;

        var XTrain = new double[trainSize][];
        var yTrain = new double[trainSize];
        var XTest = new double[testSize][];
        var yTest = new double[testSize];

        for (int i = 0; i < trainSize; i++)
        {
            XTrain[i] = X[indices[i]];
            yTrain[i] = y[indices[i]];
        }

        for (int i = 0; i < testSize; i++)
        {
            XTest[i] = X[indices[trainSize + i]];
            yTest[i] = y[indices[trainSize + i]];
        }

        return (XTrain, yTrain, XTest, yTest);
    }
}
