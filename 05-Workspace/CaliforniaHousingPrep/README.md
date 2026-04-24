# California Housing Dataset Preparation

## Overview

A .NET 10.0 console application that downloads, cleans, and prepares the California Housing dataset for deep learning applications. Built entirely with .NET BCL—no external ML or CSV libraries.

## Project Structure

```
CaliforniaHousingPrep/
├── Program.cs              # Main entry point and orchestration
├── DataDownloader.cs       # HTTP dataset download
├── CsvParser.cs            # Manual CSV parsing (handles quotes, commas)
├── DataCleaner.cs          # Missing value imputation and validation
├── CsvWriter.cs            # CSV output generation and statistics
└── CaliforniaHousingPrep.csproj
```

## Features

✅ **No External Dependencies** - Pure .NET 10.0 BCL only  
✅ **Automatic Download** - Fetches dataset from GitHub repository  
✅ **Data Cleaning** - Handles 207 missing values in `total_bedrooms` using median imputation  
✅ **Validation** - Schema validation, data type checking, and range validation  
✅ **Statistics** - Displays comprehensive dataset statistics and distributions  
✅ **Error Handling** - Graceful handling of network, parsing, and I/O errors  

## Dataset Information

- **Source:** [Ageron's Hands-On Machine Learning Repository](https://github.com/ageron/handson-ml2)
- **Records:** 20,640 housing districts in California (1990 census)
- **Features:** 10 columns
  - **Numeric (9):** longitude, latitude, housing_median_age, total_rooms, total_bedrooms, population, households, median_income, median_house_value
  - **Categorical (1):** ocean_proximity (5 categories)

## Output

- **File:** `california-housing.csv` (1.4 MB)
- **Format:** UTF-8 encoded CSV with header row
- **Location:** Solution root directory
- **Completeness:** All 20,640 records with no missing values

## Usage

### Build the Project

```bash
dotnet build CaliforniaHousingPrep/CaliforniaHousingPrep.csproj
```

### Run the Application

```bash
dotnet run --project CaliforniaHousingPrep/CaliforniaHousingPrep.csproj
```

### Expected Output

```
========================================
California Housing Dataset Preparation
========================================
Downloading California Housing dataset...
Source: https://raw.githubusercontent.com/ageron/handson-ml2/master/datasets/housing/housing.csv
✓ Download complete (1,423,529 characters)

Parsing CSV data...
✓ Found 10 columns: longitude, latitude, housing_median_age, total_rooms, total_bedrooms, population, households, median_income, median_house_value, ocean_proximity
✓ Parsed 20,640 records

Cleaning and validating data...
✓ Schema validation passed
  Found 207 missing values in 'total_bedrooms'
  ✓ Filled missing values with median: 435.0
✓ Data type validation passed (20,640 valid records)
✓ Data cleaning complete

Writing data to CSV file...
Output: S:\GitHub\HCMD-Tutorial\05-Workspace\california-housing.csv
✓ Successfully wrote 20,640 records
✓ File size: 1,445,208 bytes

╔════════════════════════════════════════════════════════════════╗
║              CALIFORNIA HOUSING DATASET SUMMARY                ║
╚════════════════════════════════════════════════════════════════╝

📊 Dataset Dimensions
   • Row Count:    20,640
   • Column Count: 10

📈 Numeric Column Statistics
   ────────────────────────────────────────────────────────────────────────────────────────
   Column                             Min          Max         Mean      Std Dev
   ────────────────────────────────────────────────────────────────────────────────────────
   longitude                      -124.35      -114.31      -119.57         2.00
   latitude                         32.54        41.95        35.63         2.14
   housing_median_age                1.00        52.00        28.64        12.59
   total_rooms                       2.00     39320.00      2635.76      2181.56
   total_bedrooms                    1.00      6445.00       536.84       419.38
   population                        3.00     35682.00      1425.48      1132.43
   households                        1.00      6082.00       499.54       382.32
   median_income                     0.50        15.00         3.87         1.90
   median_house_value            14999.00    500001.00    206855.82    115392.82
   ────────────────────────────────────────────────────────────────────────────────────────

🌊 Categorical Column: ocean_proximity
   ────────────────────────────────────────────────────────────
   Category                         Count   Percentage
   ────────────────────────────────────────────────────────────
   <1H OCEAN                        9,136        44.3%
   INLAND                           6,551        31.7%
   NEAR OCEAN                       2,658        12.9%
   NEAR BAY                         2,290        11.1%
   ISLAND                               5         0.0%
   ────────────────────────────────────────────────────────────
   TOTAL                           20,640       100.0%
   ────────────────────────────────────────────────────────────

✓ Dataset summary complete

========================================
✓ Dataset preparation completed successfully!
✓ Output file: S:\GitHub\HCMD-Tutorial\05-Workspace\california-housing.csv
========================================
```

## Data Processing Pipeline

1. **Download** - HTTP GET request to GitHub raw content
2. **Parse** - Manual CSV parsing with quote/comma handling
3. **Validate Schema** - Verify all 10 expected columns exist
4. **Handle Missing Values** - Median imputation for `total_bedrooms`
5. **Validate Data Types** - Ensure numeric columns are parseable and in valid ranges
6. **Write Output** - Generate clean CSV file
7. **Display Summary** - Comprehensive statistics for all columns (min, max, mean, std dev) and category distributions

## Technical Details

### Missing Value Strategy

- **Column:** `total_bedrooms` (207 missing values = 1% of data)
- **Method:** Median imputation (median = 435.0)
- **Rationale:** Preserves distribution, robust to outliers

### CSV Parsing

- Handles quoted fields containing commas
- Supports multi-line fields (though not present in this dataset)
- Trims whitespace from all fields
- Validates field count per row

### Data Validation

- Schema validation (column presence)
- Numeric type validation (parseable as double)
- Range validation (non-negative for most columns, except lat/lon)
- Removes malformed rows (if any)

## Requirements

- .NET 10.0 SDK
- Internet connection (for initial download)

## Output File Sample

```csv
longitude,latitude,housing_median_age,total_rooms,total_bedrooms,population,households,median_income,median_house_value,ocean_proximity
-122.23,37.88,41.0,880.0,129.0,322.0,126.0,8.3252,452600.0,NEAR BAY
-122.22,37.86,21.0,7099.0,1106.0,2401.0,1138.0,8.3014,358500.0,NEAR BAY
-122.24,37.85,52.0,1467.0,190.0,496.0,177.0,7.2574,352100.0,NEAR BAY
...
```

## License

Dataset sourced from Aurélien Géron's "Hands-On Machine Learning" repository.  
Code implementation: Educational purposes.