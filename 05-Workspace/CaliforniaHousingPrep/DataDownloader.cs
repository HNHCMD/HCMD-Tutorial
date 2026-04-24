namespace CaliforniaHousingPrep;

public class DataDownloader
{
    private readonly HttpClient _httpClient;
    private const string DatasetUrl = "https://raw.githubusercontent.com/ageron/handson-ml2/master/datasets/housing/housing.csv";

    public DataDownloader()
    {
        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromMinutes(2);
    }

    public async Task<string> DownloadDatasetAsync()
    {
        Console.WriteLine("Downloading California Housing dataset...");
        Console.WriteLine($"Source: {DatasetUrl}");

        try
        {
            var response = await _httpClient.GetAsync(DatasetUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"✓ Download complete ({content.Length:N0} characters)");
            return content;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"✗ Network error: {ex.Message}");
            throw new Exception("Failed to download dataset. Please check your internet connection.", ex);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"✗ Download timeout: {ex.Message}");
            throw new Exception("Download timed out. Please try again.", ex);
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}
