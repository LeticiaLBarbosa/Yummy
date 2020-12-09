using System.Windows.Media.Imaging;
using System.IO;

namespace YummyApp
{
    public class MediaData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BitmapImage ImageData { get; set; }
        public BitmapImage ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    }
}
