namespace e_Ticaret.Image.Services;

public static class GenerateFileNameToSaveService
{
    public static string GenerateFileNameToSave(string incomingFileName)
    {
        string fileName = Path.GetFileNameWithoutExtension(incomingFileName);
        string extension = Path.GetExtension(incomingFileName);
        return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("dd-MM-yyyy-HH-mm")}{extension}";
    }
}
