using SixLabors.ImageSharp;

namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFolders
    {
        public static List<string> GetImagePaths(string currentDirectory)
        {
            string[] imageExtensions = [".jpg", ".jpeg", ".png", ".bmp", ".tiff"];
            List<string> files = Directory.GetFiles(currentDirectory, "*.*", SearchOption.AllDirectories)
            .Where(file => !file.Contains("imageOptimizerBackup", StringComparison.OrdinalIgnoreCase) &&
                   imageExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
            .ToList();
            if (files.Count == 0) throw new Exception($"No image found anywhere inside {currentDirectory}");
            return files;
        }
    }
}
