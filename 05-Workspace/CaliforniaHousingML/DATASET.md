# California Housing Dataset

This file documents the expected format for the `california-housing.csv` dataset.

## Dataset Source

The California Housing dataset can be obtained from:
- Kaggle: https://www.kaggle.com/datasets/camnugent/california-housing-prices
- Scikit-learn: Can be exported from sklearn.datasets.fetch_california_housing()
- UCI Machine Learning Repository

## Expected CSV Format

The CSV file should have a header row followed by data rows.

### Required Columns

| Column Name | Description | Type |
|-------------|-------------|------|
| longitude | Longitude coordinate | float |
| latitude | Latitude coordinate | float |
| housing_median_age | Median age of houses in block | float |
| total_rooms | Total number of rooms in block | float |
| total_bedrooms | Total number of bedrooms in block | float |
| population | Population in block | float |
| households | Number of households in block | float |
| median_income | Median income of households | float |
| median_house_value | **Target variable** - Median house value | float |

### Example CSV Structure

```csv
longitude,latitude,housing_median_age,total_rooms,total_bedrooms,population,households,median_income,median_house_value
-122.23,37.88,41.0,880.0,129.0,322.0,126.0,8.3252,452600.0
-122.22,37.86,21.0,7099.0,1106.0,2401.0,1138.0,8.3014,358500.0
-122.24,37.85,52.0,1467.0,190.0,496.0,177.0,7.2574,352100.0
```

## Dataset Statistics

- **Total Samples**: ~20,640
- **Features**: 8
- **Target**: 1 (median_house_value)
- **Task**: Regression

## Creating the Dataset from Python

If you have scikit-learn installed, you can create the CSV file:

```python
from sklearn.datasets import fetch_california_housing
import pandas as pd

# Load dataset
california = fetch_california_housing(as_frame=True)
df = california.frame

# Save to CSV
df.to_csv('california-housing.csv', index=False)
```

## Note

The application expects the file to be named exactly `california-housing.csv` and located in the same directory as the executable when running the application.
