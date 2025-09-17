using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

class Program
{
    static void Main()
    {

        string folderImagePath = @"/Users/pranaykalgutkar/Repos/Input_Images/macos-folder-blue512x512.png"; // Replace with the actual filename
        string gitImagePath = @"/Users/pranaykalgutkar/Repos/Input_Images/couple.png"; // Replace with the actual filename
        string outputImagePath = @"/Users/pranaykalgutkar/Repos/Output_Images/folder-with-couple-icon_24.png";

        // Load the images
        using (Image folderImage = Image.Load(folderImagePath))
        using (Image gitImage = Image.Load(gitImagePath))
        {
            // Resize the Git image to fit better in the center of the folder
            //gitImage.Mutate(x => x.Resize(folderImage.Width / 3, folderImage.Height / 3));
            //gitImage.Mutate(x => x.Resize((int)(folderImage.Width / (2.5)), (int)(folderImage.Height / (2.5)))); // Git icon
            //gitImage.Mutate(x => x.Resize((int)(folderImage.Width / (2)), (int)(folderImage.Height / (2)))); // Web Development icon
            gitImage.Mutate(x => x.Resize((int)(folderImage.Width / (2.4)), (int)(folderImage.Height / (2.4)))); // Web Development icon

            // Calculate the position to center the Git image on the folder image
            int centerX = (folderImage.Width - gitImage.Width) / 2;
            //int centerY = (folderImage.Height - gitImage.Height) / 2;
            int centerY = (folderImage.Height - gitImage.Height) / 2 + 25; // 50 pixels lower
            //int centerY = (folderImage.Height - gitImage.Height) / 2 + 35; // 50 pixels lower


            // Draw the Git image onto the folder image at the calculated position
            folderImage.Mutate(x => x.DrawImage(gitImage, new Point(centerX, centerY), 1f));

            // Save the resulting image to the output path
            folderImage.Save(outputImagePath, new PngEncoder());
        }

        Console.WriteLine("Image saved to: " + outputImagePath);
    }
}
