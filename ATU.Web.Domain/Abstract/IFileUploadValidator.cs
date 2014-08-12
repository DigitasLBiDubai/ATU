using System.IO;

namespace ATU.Web.Domain.Abstract
{
    public interface IFileUploadValidator
    {
        bool IsImage(Stream stream);
        bool IsImageDimensionsValid(Stream stream, int height, int width);
    }
}