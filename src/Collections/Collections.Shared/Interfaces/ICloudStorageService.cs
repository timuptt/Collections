using Microsoft.AspNetCore.Http;

namespace Collections.Shared.Interfaces;

public interface ICloudStorageService
{
    public Task DeleteFileAsync(string fileName);
    public Task<(string, string)> UploadImageAsync(IFormFile file);

    public Task<string> GetSignedUrlAsync(string fileName, int timeOut = 30);
}