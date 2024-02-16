
using SixLabors.ImageSharp;

namespace Image_Optimizer_By_Vitos
{
    internal class ImagesFormater
    {
        public static void Backup(string currentDirectory, List<string> imagesFolder)
        {
            foreach (string imageFolder in imagesFolder)
            {
                string backupPathWithFileName = $"./imageOptimizerBackup{imageFolder.Replace(currentDirectory, "")}";
                string? backupPath = Path.GetDirectoryName(backupPathWithFileName);
                if (string.IsNullOrWhiteSpace(backupPath)) break;
                if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);
                if (!File.Exists(backupPathWithFileName)) File.Copy(imageFolder, backupPathWithFileName);
            }
        }
        public static void FormatAll(List<string> imagesFolder)
        {
            foreach (string imageFolder in imagesFolder)
            {
                string fileExtension = Path.GetExtension(imageFolder);
                string newFilePath = imageFolder.Replace(fileExtension, ".webp");
                if (File.Exists(newFilePath))
                {
                    //adicionar contagem do loading aq, caso implemente barra de load
                    break;
                };
                Image image = Image.Load(imageFolder);
                image.SaveAsWebp(newFilePath);
            }
        }
        public static void RemoveOriginalImages() { }
    }
}
