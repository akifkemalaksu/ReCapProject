using System;
using System.IO;

namespace ReCapProject.Business.Constants
{
    public static class FilePaths
    {
        public static readonly string MainFolderName = "Uploads";
        public static readonly string CarImageFolderName = "CarImages";
        public static readonly string CarImageDefaultsFolderName = Path.Combine(MainFolderName, CarImageFolderName, "Defaults");
    }
}