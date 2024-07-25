namespace RedMango_API.Services
{
    public interface IMenuItemService
    {
        Task<string> GetBlob(string fileName, string folderName);
        Task<bool> DeleteBlob(string fileName, string folderName);
        Task<string> UploadBlob(string fileName, string folderName, IFormFile file);
    }
}
