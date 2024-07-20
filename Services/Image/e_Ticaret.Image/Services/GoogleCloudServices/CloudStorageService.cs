using e_Ticaret.Image.DAL.Entities;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Options;

namespace e_Ticaret.Image.Services.GoogleCloudServices;

public class CloudStorageService : ICloudStorageService
{
    private readonly GoogleCloudStorageConfigOptions _options;
    private readonly ILogger<CloudStorageService> _logger;
    private readonly GoogleCredential _googleCredential;

    public CloudStorageService(IOptions<GoogleCloudStorageConfigOptions> options, ILogger<CloudStorageService> logger, GoogleCredential googleCredential)
    {
        _options = options.Value;
        _logger = logger;
        _googleCredential = googleCredential;
    }

    public async Task DeleteFileAsync(string fileNameToDelete)
    {
        try
        {
            using (StorageClient storageClient = StorageClient.Create(_googleCredential))
            {
                await storageClient.DeleteObjectAsync(_options.GoogleCloudStorageBucketName, fileNameToDelete);
            }
            _logger.LogInformation($"File {fileNameToDelete} deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured while deleting file {fileNameToDelete}: {e.Message}");
            throw;
        }
    }

    public async Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30)
    {
        try
        {
            ServiceAccountCredential sac = _googleCredential.UnderlyingCredential as ServiceAccountCredential;
            UrlSigner urlSigner = UrlSigner.FromServiceAccountCredential(sac);
            string signedUrl = await urlSigner.SignAsync(_options.GoogleCloudStorageBucketName, fileNameToRead, TimeSpan.FromMinutes(timeOutInMinutes));
            _logger.LogInformation($"Signed url obtained for file {fileNameToRead}");
            return signedUrl.ToString();
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured while obtained signed url for file {fileNameToRead}: {e.Message}");
            throw;
        }
    }

    public async Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave)
    {
        try
        {
            _logger.LogInformation($"Uploading: file {fileNameToSave} to storage {_options.GoogleCloudStorageBucketName}");
            using (MemoryStream memoryStream = new())
            {
                await fileToUpload.CopyToAsync(memoryStream);
                using (StorageClient storageClient = StorageClient.Create(_googleCredential))
                {
                    var uploadedFile = await storageClient.UploadObjectAsync(_options.GoogleCloudStorageBucketName, fileNameToSave, fileToUpload.ContentType, memoryStream);
                    _logger.LogInformation($"Uploaded: file {fileNameToSave} to storage {_options.GoogleCloudStorageBucketName}");
                    return uploadedFile.MediaLink;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"Error while uploading file {fileNameToSave}: {e.Message}");
            throw;
        }
    }
}
