using CaliforniaHousingPrep;

Console.WriteLine("========================================");
Console.WriteLine("California Housing Dataset Preparation");
Console.WriteLine("========================================");

const string outputFileName = "california-housing.csv";

try
{
    var downloader = new DataDownloader();
    var csvContent = await downloader.DownloadDatasetAsync();
    downloader.Dispose();

    var parser = new CsvParser();
    var records = parser.ParseCsv(csvContent);

    var cleaner = new DataCleaner();
    records = cleaner.CleanData(records);

    var writer = new CsvWriter();
    writer.WriteCsv(records, outputFileName);
    writer.DisplayStatistics(records);

    Console.WriteLine("\n========================================");
    Console.WriteLine("✓ Dataset preparation completed successfully!");
    Console.WriteLine($"✓ Output file: {Path.GetFullPath(outputFileName)}");
    Console.WriteLine("========================================");
}
catch (Exception ex)
{
    Console.WriteLine("\n========================================");
    Console.WriteLine($"✗ Error: {ex.Message}");
    Console.WriteLine("========================================");
    return 1;
}

return 0;
