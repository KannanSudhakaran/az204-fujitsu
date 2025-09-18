using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DocumentUploadHandlerFunctionApp;

public class DocsListener
{
    private readonly ILogger<DocsListener> _logger;

    public DocsListener(ILogger<DocsListener> logger)
    {
        _logger = logger;
    }

    [Function(nameof(DocsListener))]
    public async Task Run([BlobTrigger("mydocsbucket/{name}", Connection = "mydocsbucketConnectionString")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}", name, content);
    }
}