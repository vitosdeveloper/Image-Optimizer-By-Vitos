using System.Diagnostics;

namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new ImagesFormater()
                .AskResolution()
                .Backup()
                .FormatAll()
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