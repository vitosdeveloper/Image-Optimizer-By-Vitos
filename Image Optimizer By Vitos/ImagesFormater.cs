using SixLabors.ImageSharp;

namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFormater
    {
        private readonly string CurrentDirectory;
        private readonly List<string> ImagesFolder;

        public ImagesFormater()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            ImagesFolder = ImagesFolders.GetImagePaths(CurrentDirectory);
        }

        public ImagesFormater Backup()
        {
            foreach (string imageFolder in ImagesFolder)
            {
                string backupPathWithFileName = $"./imageOptimizerBackup{imageFolder.Replace(CurrentDirectory, "")}";
                string? backupPath = Path.GetDirectoryName(backupPathWithFileName);
                if (string.IsNullOrWhiteSpace(backupPath)) break;
                if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);
                if (!File.Exists(backupPathWithFileName)) File.Copy(imageFolder, backupPathWithFileName);
            }
            return this;
        }

        public ImagesFormater FormatAll()
        {
            foreach (string imageFolder in ImagesFolder)
            {
                string fileExtension = Path.GetExtension(imageFolder);
                string newFilePath = imageFolder.Replace(fileExtension, ".webp");
                if (File.Exists(newFilePath))
                {
                    // Add loading count here if implementing a loading bar
                    break;
                };
                Image image = Image.Load(imageFolder);
                image.SaveAsWebp(newFilePath);
            }
            return this;
        }

        public ImagesFormater RemoveOriginalImages()
        {
            foreach (string imageFolder in ImagesFolder)
            {
                if (File.Exists(imageFolder)) File.Delete(imageFolder);
            }
            return this;
        }
    }
}
