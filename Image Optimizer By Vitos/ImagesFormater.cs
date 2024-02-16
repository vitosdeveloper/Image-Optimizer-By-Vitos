using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

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
                if (string.IsNullOrWhiteSpace(backupPath)) continue;
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
                if (File.Exists(newFilePath)) continue;
                Image image = Image.Load(imageFolder);
                WebpEncoder encoder = new() { Quality = 75, };
                int maxResolution = 1080;
                if (image.Width > maxResolution || image.Height > maxResolution)
                    image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(maxResolution, maxResolution), Mode = ResizeMode.Max }));
                image.SaveAsWebp(newFilePath, encoder);
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
            Log.ShowCompleted(ImagesFolder.Count);
            return this;
        }
    }
}
