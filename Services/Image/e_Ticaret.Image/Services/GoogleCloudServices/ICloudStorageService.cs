namespace e_Ticaret.Image.Services.GoogleCloudServices;

public interface ICloudStorageService
{
    Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30);
    Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave);
    Task DeleteFileAsync(string fileNameToDelete);
}
