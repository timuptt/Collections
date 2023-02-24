using Collections.Infrastructure.FileStorage.Configuration;
using Collections.Shared.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Collections.Infrastructure.FileStorage.Services;

public class CloudStorageService : ICloudStorageService
{
    private readonly GCSConfiguration _options;
    private readonly GoogleCredential _googleCredentials;

    public CloudStorageService(IOptions<GCSConfiguration> options)
    {
        _options = options.Value;
        
#if DEBUG
        _googleCredentials = GoogleCredential.FromFile(_options.GCPStorageAuthFile);
#else
        _googleCredantials = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("GOOGLE_CREDENTIALS"))
#endif
    }

    public async Task DeleteFileAsync(string fileName)
    {
        using var storageClient = await StorageClient.CreateAsync(_googleCredentials);
        await storageClient.DeleteObjectAsync(_options.GoogleCloudStorageBucketName, fileName);
    }

    public async Task<(string, string)> UploadImageAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        using var storageClient = await StorageClient.CreateAsync(_googleCredentials);
        var fileName = $"{DateTime.Now.Ticks}{file.FileName}";
        var uploadedFile = await storageClient.UploadObjectAsync(_options.GoogleCloudStorageBucketName,
            fileName, file.ContentType, memoryStream);
        return (uploadedFile.MediaLink, fileName);
    }

    public async Task<string> GetSignedUrlAsync(string fileName, int timeOut = 30)
    {
        var serviceAccountCredential = _googleCredentials.UnderlyingCredential as ServiceAccountCredential;
        var urlSigner = UrlSigner.FromServiceAccountCredential(serviceAccountCredential);
        var signedUrl = await urlSigner.SignAsync(_options.GoogleCloudStorageBucketName, fileName,
            TimeSpan.FromMinutes(timeOut));
        return signedUrl;
    }
}