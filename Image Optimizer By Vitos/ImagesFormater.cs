using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFormater
    {
        private readonly string CurrentDirectory;
        private readonly List<string> ImagesFolder;
        private int MaxResolution;
        readonly Stopwatch Timer = new();
        public ImagesFormater()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            ImagesFolder = ImagesFolders.GetImagePaths(CurrentDirectory);
        }

        public ImagesFormater Backup()
        {
            Timer.Start();
            Log log = new("Initializing Backup", ImagesFolder.Count, 0);
            foreach (string imageFolder in ImagesFolder)
            {
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

        public ImagesFormater AskResolution()
        {
            char resizeValue = Log.ShowResizeOptions();
            MaxResolution = resizeValue switch
            {
                '2' => 480,
                '3' => 720,
                '4' => 1080,
                '5' => 1440,
                '6' => 2160,
                _ => 0,
            };
            return this;
        }

        public ImagesFormater FormatAll()
        {
            Log log = new("Formating Images", ImagesFolder.Count, 1);
            Parallel.ForEach(ImagesFolder, imageFolder => ProcessImage(imageFolder, log));
            Console.Clear();
            return this;
        }

        private void ProcessImage(string imageFolder, Log log)
        {
            string fileExtension = Path.GetExtension(imageFolder);
            string newFilePath = imageFolder.Replace(fileExtension, ".webp");
            if (File.Exists(newFilePath)) return;
            using (Image image = Image.Load(imageFolder))
            {
                WebpEncoder encoder = new() { Quality = 75 };
                if (MaxResolution != 0 && (image.Width > MaxResolution || image.Height > MaxResolution))
                {
                    image.Mutate(x =>
                   {
                       x.Resize(new ResizeOptions { Size = new Size(MaxResolution, MaxResolution), Mode = ResizeMode.Max });
                       x.AutoOrient();
                   });
                }
                image.SaveAsWebp(newFilePath, encoder);
                log.ProgressBar();
            }
        }

        public ImagesFormater RemoveOriginalImages()
        {
            Log log = new("Removing old trash", ImagesFolder.Count, 2);
            foreach (string imageFolder in ImagesFolder)
            {
                log.ProgressBar();
                if (File.Exists(imageFolder)) File.Delete(imageFolder);
            }
            Timer.Stop();
            Log.ShowCompleted(ImagesFolder.Count, Timer);
            return this;
        }
    }
}