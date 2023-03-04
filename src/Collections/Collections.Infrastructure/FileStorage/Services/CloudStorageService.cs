using Collections.Infrastructure.FileStorage.Configuration;
using Collections.Shared.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Collections.Infrastructure.FileStorage.Services;

public class CloudStorageService : ICloudStorageService
{
    private readonly GoogleCredential _googleCredentials;
    private readonly string? _bucketName;

    public CloudStorageService(IOptions<GoogleCloudOptions> options)
    {
        _googleCredentials = GoogleCredential.FromFile(options.Value.GoogleCloudStorageAuthFile);
        _bucketName = options.Value.GoogleCloudStorageBucketName;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        using var storageClient = await StorageClient.CreateAsync(_googleCredentials);
        await storageClient.DeleteObjectAsync(_bucketName, fileName);
    }

    public async Task<(string, string)> UploadImageAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        using var storageClient = await StorageClient.CreateAsync(_googleCredentials);
        var fileName = $"{DateTime.Now.Ticks}{file.FileName}";
        var uploadedFile = await storageClient.UploadObjectAsync(_bucketName,
            fileName, file.ContentType, memoryStream);
        return (uploadedFile.MediaLink, fileName);
    }

    public async Task<string> GetSignedUrlAsync(string fileName, int timeOut = 30)
    {
        var serviceAccountCredential = _googleCredentials.UnderlyingCredential as ServiceAccountCredential;
        var urlSigner = UrlSigner.FromCredential(serviceAccountCredential);
        var signedUrl = await urlSigner.SignAsync(_bucketName, fileName,
            TimeSpan.FromMinutes(timeOut));
        return signedUrl;
    }
}