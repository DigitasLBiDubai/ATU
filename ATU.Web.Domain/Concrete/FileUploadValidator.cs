using System.IO;
using System.Drawing;
using ATU.Web.Domain.Abstract;

namespace ATU.Web.Domain.Concrete
{
    public class FileUploadValidator : IFileUploadValidator
    {
        public bool IsImage(Stream stream)
        {
            var image = Image.FromStream(stream, true, true);

            stream.Seek(0, SeekOrigin.Begin);

            return image != null;
        }

        public bool IsImageDimensionsValid(Stream stream, int height, int width)
        {
            var image = Image.FromStream(stream, true, true);

            stream.Seek(0, SeekOrigin.Begin);
            
            return image.Height == height && image.Width == width;
        }
    }
}