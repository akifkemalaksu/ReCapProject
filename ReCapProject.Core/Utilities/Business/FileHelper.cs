using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ReCapProject.Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static void FileUpload(string fileName, string folderPath, IFormFile file)
        {
            string root = Environment.CurrentDirectory;
            string uploadFolderPath = Path.Combine(root, folderPath);

            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            string FullFilePath = Path.Combine(uploadFolderPath, fileName);
            using (var stream = new FileStream(FullFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        public static void FileDelete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}