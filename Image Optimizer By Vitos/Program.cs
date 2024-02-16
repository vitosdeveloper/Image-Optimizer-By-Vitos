namespace Image_Optimizer_By_Vitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string imageFolder = @"C:/teste/image.jpg";
            //var image = Image.Load(imageFolder);
            //image.SaveAsWebp(@"C:/teste/imageWebp.webp");
            var imagesFolder = ImagesFolders.GetImagePaths();
            Console.WriteLine($"numero de imagens: {imagesFolder.Count()}");
        }
    }
}