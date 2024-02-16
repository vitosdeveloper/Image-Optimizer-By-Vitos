namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFolders
    {
        public static List<string> GetImagePaths(string currentDirectory)
        {
            List<string> imagePaths = [];
            string[] files = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string extension = Path.GetExtension(file);
                if (!IsBackupFolder(file) && !IsWebpExtension(extension) && IsImageExtension(extension))
                    imagePaths.Add(file);
            }
            if (imagePaths.Count == 0) throw new Exception($"No image found anywhere inside {currentDirectory}");
            return imagePaths;
        }

        private static bool IsBackupFolder(string file) => file.Contains("imageOptimizerBackup");


        private static bool IsImageExtension(string extension)
        {
            string[] imageExtensions = [".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff"];
            return Array.IndexOf(imageExtensions, extension) != -1;
        }

        private static bool IsWebpExtension(string extension) => extension == ".webp";

    }
}
