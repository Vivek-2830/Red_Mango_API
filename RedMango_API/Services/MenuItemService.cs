using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace RedMango_API.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IWebHostEnvironment _environment;

        public MenuItemService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        //public async Task<bool> DeleteBlob(string fileName, string folderName)
        //{
        //    if (string.IsNullOrEmpty(fileName))
        //    {
        //        throw new Exception("File name is not provided.");
        //    }

        //    var uploadsFolderPath = Path.Combine(_environment.WebRootPath, folderName);

        //    //if (Directory.Exists(uploadsFolderPath))
        //    //{
        //    //    throw new Exception("Directory does not exist.");
        //    //}

        //    var filePath = Path.Combine(uploadsFolderPath, fileName);

        //    if (File.Exists(filePath))
        //    {
        //        throw new Exception("File does not exist.");
        //    }

        //    File.Delete(filePath);

        //    return true;
        //}

        //public async Task<bool> DeleteBlob(string fileName, string Folder)
        //{
        //    var filePath = Path.Combine(_environment.WebRootPath, "FoodImages", fileName);

        //    if (!File.Exists(filePath))
        //    {
        //        throw new Exception($"No file uploaded.");
        //    }   

        //    File.Delete(filePath);

        //    throw new Exception($"File deleted successfully." );
        //}

        public Task<string> GetBlob(string fileName, string folderName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadBlob(string fileName, string folderName, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception($"No file uploaded.");
            }

            var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "FoodImages");

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
