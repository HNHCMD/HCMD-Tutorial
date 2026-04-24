using CaliforniaHousingML;
using System.Diagnostics;

Console.WriteLine("California Housing Price Prediction - Deep Learning from Scratch");
Console.WriteLine("================================================================\n");

string dataPath = "california-housing.csv";

if (!File.Exists(dataPath))
{
    Console.WriteLine($"Error: Dataset file '{dataPath}' not found.");
    Console.WriteLine("Please ensure 'california-housing.csv' is in the same directory as the executable.");
    return;
}

Console.WriteLine("Loading dataset...");
var (X, y) = DataLoader.LoadCSV(dataPath);
Console.WriteLine($"Dataset loaded: {X.Length} samples, {X[0].Length} features\n");

Console.WriteLine("Splitting data into train/test sets (80/20)...");
var (XTrain, yTrain, XTest, yTest) = DataLoader.TrainTestSplit(X, y, testRatio: 0.2, seed: 42);
Console.WriteLine($"Training samples: {XTrain.Length}");
Console.WriteLine($"Test samples: {XTest.Length}\n");

Console.WriteLine("Normalizing features using StandardScaler...");
var featureScaler = new StandardScaler();
XTrain = featureScaler.FitTransform(XTrain);
XTest = featureScaler.Transform(XTest);
Console.WriteLine("Feature normalization complete.\n");

Console.WriteLine("Normalizing target values using StandardScaler...");
var targetScaler = new StandardScaler();
yTrain = targetScaler.FitTransform(yTrain);
yTest = targetScaler.Transform(yTest);
Console.WriteLine("Target normalization complete.\n");

Console.WriteLine("================================================================");
Console.WriteLine("OPTIMIZED MODEL TRAINING - 500 EPOCHS");
Console.WriteLine("================================================================\n");

Console.WriteLine("Configuration:");
Console.WriteLine("  - Learning Rate: 0.005");
Console.WriteLine("  - Batch Size: 64");
Console.WriteLine("  - Epochs: 500");
Console.WriteLine("  - Reporting: Every 25 epochs");
Console.WriteLine("  - Metrics: Unscaled (original dollar values)\n");

Console.WriteLine("Building MLP model:");
Console.WriteLine("  Input -> Dense(32, tanh) -> Dense(8, tanh) -> Dense(1, linear)");
var model = new MLP();
model.AddLayer(new DenseLayer(XTrain[0].Length, 32, new TanhActivation(), seed: 42));
model.AddLayer(new DenseLayer(32, 8, new TanhActivation(), seed: 43));
model.AddLayer(new DenseLayer(8, 1, new LinearActivation(), seed: 44));
Console.WriteLine("Model created.\n");

Console.WriteLine("Initializing Adam optimizer (lr=0.005)...");
var optimizer = new AdamOptimizer(learningRate: 0.005);
Console.WriteLine("Optimizer initialized.\n");

Console.WriteLine("================================================================");
Console.WriteLine("Starting training...");
Console.WriteLine("================================================================\n");

var stopwatch = Stopwatch.StartNew();
var trainer = new Trainer(model, optimizer, batchSize: 64, epochs: 500, seed: 42);
trainer.Train(XTrain, yTrain, targetScaler);
stopwatch.Stop();

double trainingTime = stopwatch.Elapsed.TotalSeconds;

Console.WriteLine("\n================================================================");
Console.WriteLine("Training complete!");
Console.WriteLine("================================================================\n");

Console.WriteLine($"Total training time: {trainingTime:F2} seconds");
Console.WriteLine($"Average time per epoch: {trainingTime/500:F3} seconds\n");

Console.WriteLine("================================================================");
Console.WriteLine("FINAL EVALUATION ON TEST SET");
Console.WriteLine("================================================================\n");

double testMSE = model.ComputeMSE(XTest, yTest);
double testRMSE = Math.Sqrt(testMSE);
double testMSEUnscaled = model.ComputeMSE(XTest, yTest, targetScaler);
double testRMSEUnscaled = Math.Sqrt(testMSEUnscaled);

Console.WriteLine("Normalized Metrics:");
Console.WriteLine($"  Test MSE:  {testMSE:F4}");
Console.WriteLine($"  Test RMSE: {testRMSE:F4}\n");

Console.WriteLine("Unscaled Metrics (Original Dollar Values):");
Console.WriteLine($"  Test MSE:  {testMSEUnscaled:F2}");
Console.WriteLine($"  Test RMSE: ${testRMSEUnscaled:F2}\n");

double trainLoss = model.ComputeMSE(XTrain, yTrain);
double trainLossUnscaled = model.ComputeMSE(XTrain, yTrain, targetScaler);
double trainRMSEUnscaled = Math.Sqrt(trainLossUnscaled);

Console.WriteLine("Training Set Performance:");
Console.WriteLine($"  Train Loss (normalized): {trainLoss:F4}");
Console.WriteLine($"  Train MSE (unscaled): {trainLossUnscaled:F2}");
Console.WriteLine($"  Train RMSE (unscaled): ${trainRMSEUnscaled:F2}\n");

double generalizationGap = testMSE - trainLoss;
Console.WriteLine("Generalization Analysis:");
Console.WriteLine($"  Train-Test Gap (normalized): {generalizationGap:F4}");
Console.WriteLine($"  Overfitting Status: {(generalizationGap > 0.02 ? "Slight overfitting" : "Good generalization")}\n");

Console.WriteLine("================================================================");
Console.WriteLine("PERFORMANCE ANALYSIS");
Console.WriteLine("================================================================\n");

Console.WriteLine("Model Accuracy by House Price Range:");
Console.WriteLine("-------------------------------------");
Console.WriteLine($"For a $100,000 house:");
Console.WriteLine($"  Expected prediction range: ${100000 - testRMSEUnscaled:F0} - ${100000 + testRMSEUnscaled:F0}");
Console.WriteLine($"  Error margin: ±{(testRMSEUnscaled/100000)*100:F1}%\n");

Console.WriteLine($"For a $200,000 house:");
Console.WriteLine($"  Expected prediction range: ${200000 - testRMSEUnscaled:F0} - ${200000 + testRMSEUnscaled:F0}");
Console.WriteLine($"  Error margin: ±{(testRMSEUnscaled/200000)*100:F1}%\n");

Console.WriteLine($"For a $350,000 house:");
Console.WriteLine($"  Expected prediction range: ${350000 - testRMSEUnscaled:F0} - ${350000 + testRMSEUnscaled:F0}");
Console.WriteLine($"  Error margin: ±{(testRMSEUnscaled/350000)*100:F1}%\n");

Console.WriteLine($"For a $500,000 house:");
Console.WriteLine($"  Expected prediction range: ${500000 - testRMSEUnscaled:F0} - ${500000 + testRMSEUnscaled:F0}");
Console.WriteLine($"  Error margin: ±{(testRMSEUnscaled/500000)*100:F1}%\n");

Console.WriteLine("================================================================");
Console.WriteLine("TRAINING SUMMARY");
Console.WriteLine("================================================================\n");

Console.WriteLine("Configuration:");
Console.WriteLine($"  Architecture: Input(8) -> Dense(32,tanh) -> Dense(8,tanh) -> Dense(1,linear)");
Console.WriteLine($"  Total Parameters: 561");
Console.WriteLine($"  Learning Rate: 0.005");
Console.WriteLine($"  Batch Size: 64");
Console.WriteLine($"  Epochs: 500");
Console.WriteLine($"  Optimizer: Adam (beta1=0.9, beta2=0.999)\n");

Console.WriteLine("Dataset:");
Console.WriteLine($"  Total Samples: {X.Length}");
Console.WriteLine($"  Training Samples: {XTrain.Length}");
Console.WriteLine($"  Test Samples: {XTest.Length}");
Console.WriteLine($"  Features: {XTrain[0].Length}\n");

Console.WriteLine("Training Efficiency:");
Console.WriteLine($"  Total Time: {trainingTime:F2} seconds");
Console.WriteLine($"  Time per Epoch: {trainingTime/500:F3} seconds");
Console.WriteLine($"  Samples per Second: {(XTrain.Length * 500) / trainingTime:F0}\n");

Console.WriteLine("Final Results:");
Console.WriteLine($"  Test RMSE: ${testRMSEUnscaled:F2}");
Console.WriteLine($"  Train RMSE: ${trainRMSEUnscaled:F2}");
Console.WriteLine($"  Performance Level: {(testRMSEUnscaled < 50000 ? "Excellent" : testRMSEUnscaled < 55000 ? "Very Good" : testRMSEUnscaled < 60000 ? "Good" : "Acceptable")}\n");

Console.WriteLine("================================================================");
Console.WriteLine("Done!");
Console.WriteLine("================================================================");

