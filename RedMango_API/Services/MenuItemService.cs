using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace RedMango_API.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<bool> DeleteBlob(string fileName, string folderName)
        {
            string filePath = Path.Combine(folderName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<string> GetBlob(string fileName, string folderName)
        {
            string filePath = Path.Combine(folderName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return filePath;
            }

            return null;
        }

        public async Task<string> UploadBlob(string fileName, string folderName, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception($"No file uploaded.");
            }

            var uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "FoodImages");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }
            var NewfileName = Guid.NewGuid().ToString();
            var filePath = Path.Combine(uploadsFolderPath, NewfileName + file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine("FoodImages", NewfileName + file.FileName);
        }
    }
}
