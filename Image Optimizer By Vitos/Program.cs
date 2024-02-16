using System.Text;

namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                var imagesFolder = ImagesFolders.GetImagePaths(currentDirectory);
                ImagesFormater.Backup(currentDirectory, imagesFolder);
                ImagesFormater.FormatAll(imagesFolder);
                ImagesFormater.RemoveOriginalImages(imagesFolder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}