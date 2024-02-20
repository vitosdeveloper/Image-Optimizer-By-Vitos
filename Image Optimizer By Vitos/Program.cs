namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var imageFormater = new ImagesFormater()
                .AskResolution()
                .Backup()
                .FormatAll().Result
                .RemoveOriginalImages();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}