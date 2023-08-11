using Converter.Entities.ColorConversionEntities;

namespace Converter.Converters
{
    public class ColorConverter : IColorConverter
    {
        public async Task<RGB> ConvertCMYKToRGB(CMYK colorInfo)
        {
            
            var retVal = new RGB
            {
                Red = Math.Round(255 * (1 - colorInfo.Cyan / 100) * (1 - colorInfo.Black / 100)),
                Green = Math.Round(255 * (1 - colorInfo.Magenta / 100) * (1 - colorInfo.Black / 100)),
                Blue = Math.Round(255 * (1 - colorInfo.Yellow / 100) * (1 - colorInfo.Black / 100))
            };

            return await Task.FromResult(retVal);
        }

        //public async Task<CMYK> ConvertRGBToCMYK(RGB colorInfo)
        //{

        //}

        
    }
}
