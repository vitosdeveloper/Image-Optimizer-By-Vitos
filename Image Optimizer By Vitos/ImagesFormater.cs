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
            Log log = new("Initializing Backup", ImagesFolder.Count, 0);
            log.ProgressBar();
            foreach (string imageFolder in ImagesFolder)
            {
                log.ProgressByOne();
                log.ProgressBar();
                string backupPathWithFileName = $"./imageOptimizerBackup{imageFolder.Replace(CurrentDirectory, "")}";
                string? backupPath = Path.GetDirectoryName(backupPathWithFileName);
                if (string.IsNullOrWhiteSpace(backupPath)) break;
                if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);
                if (!File.Exists(backupPathWithFileName)) File.Copy(imageFolder, backupPathWithFileName);
            }
            Console.Clear();
            return this;
        }

        public ImagesFormater FormatAll()
        {
            Log log = new("Formating Images", ImagesFolder.Count, 1);
            log.ProgressBar();
            foreach (string imageFolder in ImagesFolder)
            {
                log.ProgressByOne();
                log.ProgressBar();
                string fileExtension = Path.GetExtension(imageFolder);
                string newFilePath = imageFolder.Replace(fileExtension, ".webp");
                if (File.Exists(newFilePath)) break;
                Image image = Image.Load(imageFolder);
                image.SaveAsWebp(newFilePath);
            }
            Console.Clear();
            return this;
        }

        public ImagesFormater RemoveOriginalImages()
        {
            Log log = new("Removing old trash", ImagesFolder.Count, 2);
            log.ProgressBar();
            foreach (string imageFolder in ImagesFolder)
            {
                log.ProgressByOne();
                log.ProgressBar();
                if (File.Exists(imageFolder)) File.Delete(imageFolder);
            }
            Console.Clear();
            Log.ShowCompleted();
            return this;
        }
    }
}
