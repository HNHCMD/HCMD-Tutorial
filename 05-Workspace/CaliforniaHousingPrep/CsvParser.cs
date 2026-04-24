namespace CaliforniaHousingPrep;

public class CsvParser
{
    public List<Dictionary<string, string>> ParseCsv(string csvContent)
    {
        Console.WriteLine("\nParsing CSV data...");

        var lines = csvContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length < 2)
        {
            throw new Exception("CSV file is empty or has no data rows.");
        }

        var headers = ParseCsvLine(lines[0]);
        Console.WriteLine($"✓ Found {headers.Count} columns: {string.Join(", ", headers)}");

        var records = new List<Dictionary<string, string>>();
        int skippedRows = 0;

        for (int i = 1; i < lines.Length; i++)
        {
            try
            {
                var values = ParseCsvLine(lines[i]);

                if (values.Count != headers.Count)
                {
                    skippedRows++;
                    continue;
                }

                var record = new Dictionary<string, string>();
                for (int j = 0; j < headers.Count; j++)
                {
                    record[headers[j]] = values[j].Trim();
                }
                records.Add(record);
            }
            catch
            {
                skippedRows++;
            }
        }

        Console.WriteLine($"✓ Parsed {records.Count:N0} records");
        if (skippedRows > 0)
        {
            Console.WriteLine($"  (Skipped {skippedRows} malformed rows)");
        }

        return records;
    }

    private List<string> ParseCsvLine(string line)
    {
        var fields = new List<string>();
        var currentField = new System.Text.StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField.ToString());
                currentField.Clear();
            }
            else
            {
                currentField.Append(c);
            }
        }

        fields.Add(currentField.ToString());
        return fields;
    }
}
