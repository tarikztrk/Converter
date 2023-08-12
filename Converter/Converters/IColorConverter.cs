using Converter.Entities.ColorConversionEntities;

namespace Converter.Converters
{
    public interface IColorConverter
    {

        Task<RGB> ConvertCMYKToRGB(CMYK colorInfo);
        Task<RGB> ConvertHexadecimalToRgb(Hexadecimal hexadecimal);
        Task<CMYK> ConvertRGBToCMYK(RGB colorInfo);
    }
}