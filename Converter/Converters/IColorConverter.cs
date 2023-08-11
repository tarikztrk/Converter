using Converter.Entities.ColorConversionEntities;

namespace Converter.Converters
{
    public interface IColorConverter
    {
        Task<RGB> ConvertCMYKToRGB(CMYK colorInfo);
    }
}