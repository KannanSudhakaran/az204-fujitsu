using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
     // await CaseStudy1();
      await  CaseStudy2();
    }

    private static async Task CaseStudy2()
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=day4storageks2025;AccountKey=HEGmwhkXbPuzpZU42VNqSkUQb8V+YOGEu/rYzTv+waTMLm6eDfb/d7PaugxOmzh4/oygbBQWD/c/+AStcHmp6Q==;EndpointSuffix=core.windows.net";
        string containerName = "fujitsubucket";
        string blobName = "mydata.log";

        // Get a reference to a container
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        // Get a reference to an append blob
        AppendBlobClient appendBlob = container.GetAppendBlobClient(blobName);

        // Ensure the append blob exists
        if (!await appendBlob.ExistsAsync())
        {
            Console.WriteLine("The specified append blob does not exist.");
            return;
        }

        // Append more text to the blob
        string additionalTextToAppend = "Additional text to append. Fujitsu again";
        await appendBlob.AppendBlockAsync(new MemoryStream(Encoding.UTF8.GetBytes(additionalTextToAppend)));

        Console.WriteLine("Additional text appended to the blob successfully.");
    }

    private static async Task CaseStudy1()
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=day4storageks2025;AccountKey=HEGmwhkXbPuzpZU42VNqSkUQb8V+YOGEu/rYzTv+waTMLm6eDfb/d7PaugxOmzh4/oygbBQWD/c/+AStcHmp6Q==;EndpointSuffix=core.windows.net";
        string containerName = "fujitsubucket";
        string blobName = "mydata.log";

        // Get a reference to a container
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        // Create the container if it does not exist.
        await container.CreateIfNotExistsAsync();

        // Get a reference to an append blob
        AppendBlobClient appendBlob = container.GetAppendBlobClient(blobName);

        // Create the append blob if it does not exist
        await appendBlob.CreateIfNotExistsAsync();

        // Append text to the blob
        string textToAppend = "Hello, team Fujitsu this is append blob!\n";
        await appendBlob.AppendBlockAsync(new MemoryStream(Encoding.UTF8.GetBytes(textToAppend)));

        Console.WriteLine("Text appended to the blob successfully.");
    }
}