# Quick Start Guide

## Setup

1. **Build the project:**
   ```bash
   dotnet build CaliforniaHousingML/CaliforniaHousingML.csproj
   ```

2. **Obtain the dataset:**
   - Download `california-housing.csv` from Kaggle or use scikit-learn to export it
   - Place the file in the directory where you'll run the application

3. **Run the application:**
   ```bash
   dotnet run --project CaliforniaHousingML/CaliforniaHousingML.csproj
   ```

## What It Does

The application implements a neural network completely from scratch (no ML libraries) to predict California housing prices.

### Architecture
```
Input (8 features)
    ↓
Dense Layer (32 neurons, tanh)
    ↓
Dense Layer (8 neurons, tanh)
    ↓
Dense Layer (1 neuron, linear)
    ↓
Output (predicted house value)
```

### Training Process
1. Loads and splits data (80% train, 20% test)
2. Normalizes features using StandardScaler
3. Trains for 500 epochs with mini-batches of size 64
4. Uses Adam optimizer with MSE loss
5. Reports training loss every 10 epochs
6. Evaluates final model on test set

## Key Features Implemented from Scratch

✅ Dense (Fully Connected) Layers  
✅ Tanh and Linear Activations  
✅ Forward Propagation  
✅ Backward Propagation (Backprop)  
✅ Adam Optimizer with Bias Correction  
✅ StandardScaler (Feature Normalization)  
✅ Mini-Batch Training Loop  
✅ Xavier Weight Initialization  

## Performance Expectations

Training on a modern CPU should complete in a few minutes. Expected test MSE will vary but should be in the range of 40,000-70,000 (RMSE ~200-265), which represents reasonable performance for a simple MLP on this dataset.

## Troubleshooting

**"Dataset file not found"**
- Ensure `california-housing.csv` is in the same directory as where you run the application
- Check the file name is exactly `california-housing.csv`

**Build errors**
- Ensure you have .NET 8.0 SDK installed
- Run `dotnet --version` to verify

## File Overview

| File | Purpose |
|------|---------|
| `Program.cs` | Main entry point, orchestrates the workflow |
| `MLP.cs` | Neural network model with forward/backward passes |
| `DenseLayer.cs` | Fully connected layer implementation |
| `Activations.cs` | Activation functions (Tanh, Linear) |
| `AdamOptimizer.cs` | Adam optimization algorithm |
| `StandardScaler.cs` | Feature normalization |
| `Trainer.cs` | Training loop with mini-batches |
| `DataLoader.cs` | CSV loading and data splitting |

Each file is self-contained and focused on a single responsibility.
