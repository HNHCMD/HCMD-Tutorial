namespace CaliforniaHousingPrep;

public class CsvWriter
{
    public void WriteCsv(List<Dictionary<string, string>> records, string outputPath)
    {
        Console.WriteLine($"\nWriting data to CSV file...");
        Console.WriteLine($"Output: {Path.GetFullPath(outputPath)}");

        if (records.Count == 0)
        {
            throw new Exception("No records to write.");
        }

        var headers = records[0].Keys.ToList();

        using (var writer = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
        {
            writer.WriteLine(string.Join(",", headers.Select(h => EscapeCsvField(h))));

            foreach (var record in records)
            {
                var values = headers.Select(h => EscapeCsvField(record[h]));
                writer.WriteLine(string.Join(",", values));
            }
        }

        var fileInfo = new FileInfo(outputPath);
        Console.WriteLine($"✓ Successfully wrote {records.Count:N0} records");
        Console.WriteLine($"✓ File size: {fileInfo.Length:N0} bytes");
    }

    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field))
        {
            return field;
        }

        if (field.Contains(',') || field.Contains('"') || field.Contains('\n') || field.Contains('\r'))
        {
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }

        return field;
    }

    public void DisplayStatistics(List<Dictionary<string, string>> records)
    {
        Console.WriteLine("\n╔════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              CALIFORNIA HOUSING DATASET SUMMARY                ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");

        Console.WriteLine($"\n📊 Dataset Dimensions");
        Console.WriteLine($"   • Row Count:    {records.Count:N0}");
        Console.WriteLine($"   • Column Count: {records[0].Keys.Count}");

        var numericColumns = new[]
        {
            "longitude", "latitude", "housing_median_age", "total_rooms",
            "total_bedrooms", "population", "households", "median_income",
            "median_house_value"
        };

        Console.WriteLine($"\n📈 Numeric Column Statistics");
        Console.WriteLine("   " + new string('─', 88));
        Console.WriteLine($"   {"Column",-25} {"Min",12} {"Max",12} {"Mean",12} {"Std Dev",12}");
        Console.WriteLine("   " + new string('─', 88));

        foreach (var column in numericColumns)
        {
            var values = records
                .Select(r => double.Parse(r[column]))
                .ToList();

            double min = values.Min();
            double max = values.Max();
            double mean = values.Average();
            double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
            double stdDev = Math.Sqrt(variance);

            Console.WriteLine($"   {column,-25} {min,12:F2} {max,12:F2} {mean,12:F2} {stdDev,12:F2}");
        }
        Console.WriteLine("   " + new string('─', 88));

        var oceanProximityValues = records
            .GroupBy(r => r["ocean_proximity"])
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToList();

        Console.WriteLine($"\n🌊 Categorical Column: ocean_proximity");
        Console.WriteLine("   " + new string('─', 60));
        Console.WriteLine($"   {"Category",-25} {"Count",12} {"Percentage",12}");
        Console.WriteLine("   " + new string('─', 60));

        foreach (var item in oceanProximityValues)
        {
            double percentage = (item.Count * 100.0 / records.Count);
            Console.WriteLine($"   {item.Value,-25} {item.Count,12:N0} {percentage,11:F1}%");
        }
        Console.WriteLine("   " + new string('─', 60));
        Console.WriteLine($"   {"TOTAL",-25} {records.Count,12:N0} {100.0,11:F1}%");
        Console.WriteLine("   " + new string('─', 60));

        Console.WriteLine($"\n✓ Dataset summary complete");
    }
}
