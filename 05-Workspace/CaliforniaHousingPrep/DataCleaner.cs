namespace CaliforniaHousingPrep;

public class DataCleaner
{
    private readonly string[] _expectedColumns = new[]
    {
        "longitude", "latitude", "housing_median_age", "total_rooms",
        "total_bedrooms", "population", "households", "median_income",
        "median_house_value", "ocean_proximity"
    };

    public List<Dictionary<string, string>> CleanData(List<Dictionary<string, string>> records)
    {
        Console.WriteLine("\nCleaning and validating data...");

        ValidateSchema(records);
        HandleMissingValues(records);
        ValidateDataTypes(records);

        Console.WriteLine($"✓ Data cleaning complete");
        return records;
    }

    private void ValidateSchema(List<Dictionary<string, string>> records)
    {
        if (records.Count == 0)
        {
            throw new Exception("No records to process.");
        }

        var actualColumns = records[0].Keys.ToArray();
        var missingColumns = _expectedColumns.Except(actualColumns).ToList();
        var extraColumns = actualColumns.Except(_expectedColumns).ToList();

        if (missingColumns.Any())
        {
            throw new Exception($"Missing required columns: {string.Join(", ", missingColumns)}");
        }

        if (extraColumns.Any())
        {
            Console.WriteLine($"  Warning: Extra columns found: {string.Join(", ", extraColumns)}");
        }

        Console.WriteLine($"✓ Schema validation passed");
    }

    private void HandleMissingValues(List<Dictionary<string, string>> records)
    {
        var numericColumns = new[]
        {
            "longitude", "latitude", "housing_median_age", "total_rooms",
            "total_bedrooms", "population", "households", "median_income",
            "median_house_value"
        };

        foreach (var column in numericColumns)
        {
            var missingCount = records.Count(r => string.IsNullOrWhiteSpace(r[column]));

            if (missingCount > 0)
            {
                Console.WriteLine($"  Found {missingCount} missing values in '{column}'");

                var validValues = records
                    .Where(r => !string.IsNullOrWhiteSpace(r[column]) && double.TryParse(r[column], out _))
                    .Select(r => double.Parse(r[column]))
                    .OrderBy(v => v)
                    .ToList();

                if (validValues.Any())
                {
                    double median = validValues[validValues.Count / 2];

                    foreach (var record in records)
                    {
                        if (string.IsNullOrWhiteSpace(record[column]))
                        {
                            record[column] = median.ToString("F1");
                        }
                    }

                    Console.WriteLine($"  ✓ Filled missing values with median: {median:F1}");
                }
            }
        }
    }

    private void ValidateDataTypes(List<Dictionary<string, string>> records)
    {
        var numericColumns = new[]
        {
            "longitude", "latitude", "housing_median_age", "total_rooms",
            "total_bedrooms", "population", "households", "median_income",
            "median_house_value"
        };

        int invalidCount = 0;
        var recordsToRemove = new List<Dictionary<string, string>>();

        foreach (var record in records)
        {
            bool isValid = true;

            foreach (var column in numericColumns)
            {
                if (!double.TryParse(record[column], out double value))
                {
                    isValid = false;
                    break;
                }

                if (value < 0 && column != "longitude" && column != "latitude")
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                recordsToRemove.Add(record);
                invalidCount++;
            }
        }

        foreach (var record in recordsToRemove)
        {
            records.Remove(record);
        }

        if (invalidCount > 0)
        {
            Console.WriteLine($"  Removed {invalidCount} records with invalid data types");
        }

        Console.WriteLine($"✓ Data type validation passed ({records.Count:N0} valid records)");
    }
}
