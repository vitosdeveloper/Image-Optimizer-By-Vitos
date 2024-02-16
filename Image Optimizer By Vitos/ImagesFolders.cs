namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFolders
    {
        public static List<string> GetImagePaths()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            List<string> imagePaths = [];
            try
            {
                string[] files = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (!IsWebpExtension(extension) && IsImageExtension(extension))
                    {
                        imagePaths.Add(file);
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to get image folders: {ex.Message}");
            }

            return imagePaths;
        }

        private static bool IsImageExtension(string extension)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
            return Array.IndexOf(imageExtensions, extension) != -1;
        }

        private static bool IsWebpExtension(string extension)
        {
            return extension == ".webp";
        }
    }
}
