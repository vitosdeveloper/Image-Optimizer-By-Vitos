namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ImagesFormater imagesFormater = new();
                imagesFormater.Backup();
                await imagesFormater.FormatAll();
                imagesFormater.RemoveOriginalImages();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}