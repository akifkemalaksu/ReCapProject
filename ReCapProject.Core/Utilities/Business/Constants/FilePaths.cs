using System;
using System.IO;

namespace ReCapProject.Core.Utilities.Business.Constants
{
    public static class FilePaths
    {
        public static readonly string wwwroot = "wwwroot";
        public static readonly string MainFolderName = "Uploads";
        public static readonly string CarImageFolderName = "CarImages";
        public static readonly string CarImageDefaultsFolderName = Path.Combine(wwwroot, MainFolderName, CarImageFolderName, "Defaults");
    }
}