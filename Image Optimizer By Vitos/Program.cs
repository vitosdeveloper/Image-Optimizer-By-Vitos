using System.Diagnostics;

namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                new ImagesFormater()
                .AskResolution()
                .Backup()
                .FormatAll().Result
                .RemoveOriginalImages();
                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.Elapsed.Minutes} min and {stopwatch.Elapsed.Seconds} sec");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}