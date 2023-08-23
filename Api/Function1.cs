public static class Function1
{
    [FunctionName("GetCsv")]
    public static async Task<IActionResult> RunGetCsvAsync(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write("hello world!");
        writer.Flush();
        stream.Position = 0;

        return new FileStreamResult(stream, "text/csv")
        {
            FileDownloadName = $"Sample-{DateTime.Today.ToString("yyyy-MM-dd")}.csv",
        };
    }
}
