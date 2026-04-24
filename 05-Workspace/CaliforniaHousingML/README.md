# California Housing Price Prediction - Deep Learning from Scratch

This C# console application implements a deep learning model from scratch to predict median house values using the California Housing dataset.

## Features

### Model Architecture
- **Multi-Layer Perceptron (MLP)** with 3 layers:
  - Layer 1: Dense(32, tanh activation)
  - Layer 2: Dense(8, tanh activation)
  - Layer 3: Dense(1, linear activation)

### Implementation Details
All components are implemented from scratch without using ML libraries:
- **Dense Layers**: Fully connected layers with forward and backward propagation
- **Activations**: 
  - Tanh activation with derivative for hidden layers
  - Linear activation for output layer
- **Optimizer**: Adam optimizer with momentum and adaptive learning rates
- **Data Preprocessing**: StandardScaler for feature normalization
- **Training Loop**: Mini-batch gradient descent with shuffling

### Training Configuration
- **Loss Function**: Mean Squared Error (MSE)
- **Optimizer**: Adam (learning rate = 0.001, β1 = 0.9, β2 = 0.999)
- **Batch Size**: 64
- **Epochs**: 500
- **Data Split**: 80% training, 20% testing

## Project Structure

```
CaliforniaHousingML/
├── Activations.cs        - Activation functions (Tanh, Linear)
├── AdamOptimizer.cs      - Adam optimization algorithm
├── DataLoader.cs         - CSV loading and train/test split
├── DenseLayer.cs         - Fully connected layer implementation
├── MLP.cs                - Multi-layer perceptron model
├── Program.cs            - Main entry point
├── StandardScaler.cs     - Feature normalization
├── Trainer.cs            - Training loop with mini-batches
└── CaliforniaHousingML.csproj
```

## Requirements

- .NET 8.0 SDK
- Dataset file: `california-housing.csv` (must be in the same directory as the executable)

## Building the Project

```bash
dotnet build CaliforniaHousingML/CaliforniaHousingML.csproj
```

## Running the Application

1. Place `california-housing.csv` in the directory where you'll run the executable
2. Run the application:

```bash
dotnet run --project CaliforniaHousingML/CaliforniaHousingML.csproj
```

## Expected Output

The application will:
1. Load the California Housing dataset
2. Split data into training (80%) and testing (20%) sets
3. Normalize features using StandardScaler
4. Build the MLP model
5. Train for 500 epochs with batch size 64
6. Display training loss every 10 epochs
7. Evaluate and display final test MSE and RMSE

Example output:
```
California Housing Price Prediction - Deep Learning from Scratch
================================================================

Loading dataset...
Dataset loaded: 20640 samples, 8 features

Splitting data into train/test sets (80/20)...
Training samples: 16512
Test samples: 4128

Normalizing features using StandardScaler...
Normalization complete.

Building MLP model:
  Input -> Dense(32, tanh) -> Dense(8, tanh) -> Dense(1, linear)
Model created.

Initializing Adam optimizer (lr=0.001)...
Optimizer initialized.

Training model...
Batch size: 64
Epochs: 500

Epoch 1/500, Loss: 26843156889.4321
Epoch 11/500, Loss: 4567890.1234
...
Epoch 500/500, Loss: 45678.9012

================================================================
Training complete!

Evaluating on test set...
Test MSE: 46234.56
Test RMSE: 215.02

================================================================
Done!
```

## Dataset Format

The CSV file should contain the following columns:
- Features: longitude, latitude, housing_median_age, total_rooms, total_bedrooms, population, households, median_income
- Target: median_house_value

## Implementation Highlights

### Xavier/Glorot Weight Initialization
Weights are initialized using Xavier initialization for better convergence:
```csharp
double limit = Math.Sqrt(6.0 / (inputSize + outputSize));
```

### Adam Optimizer
Implements bias correction for momentum estimates:
```csharp
mHat = m / (1 - β1^t)
vHat = v / (1 - β2^t)
```

### Mini-Batch Training
Data is shuffled each epoch and processed in batches of 64 samples for efficient training.

## Clean Architecture

The code is modular and follows SOLID principles:
- Single Responsibility: Each class has one clear purpose
- Separation of Concerns: Data loading, preprocessing, model, and training are separate
- Extensibility: Easy to add new activation functions or layers
