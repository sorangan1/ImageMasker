namespace ImageMasker;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

class Program
{
    static void Main(string[] args)
    {
        var maskPath = @"assets/mask.png";
        
        Image<Rgba32> render = new Image<Rgba32>(400,400);
        Image<Rgba32> pfp = Image.Load<Rgba32>(@"assets/furra.jpeg");

        if (pfp.Width < 400)
        {
            pfp.Mutate(x => x.Resize(400, 400));
        }
        Rgba32 pixelColor;
        Rgba32 pfppixelColor;
        //MASK
        using (Image<Rgba32> image = Image.Load<Rgba32>(maskPath))
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    pixelColor = image[i, j];
                    pfppixelColor = pfp[i,j];
                    //Console.WriteLine($"{pixelColor}");
                    if (pixelColor.A != 0)
                    {
                        render[i,j] = pfppixelColor;
                    }
                }
            }
        }
        render.Save("assets/render.png");
    }
}
