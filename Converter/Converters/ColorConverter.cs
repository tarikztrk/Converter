using Converter.Entities.ColorConversionEntities;

namespace Converter.Converters
{
   
    public class ColorConverter : IColorConverter {
        public async Task<RGB> ConvertCMYKToRGB(CMYK colorInfo)
        {

            var retVal = new RGB
            {
                Red = CalculateRgbColorCode(colorInfo.Cyan, colorInfo.Black),
                Green = CalculateRgbColorCode(colorInfo.Magenta, colorInfo.Black),
                Blue = CalculateRgbColorCode(colorInfo.Yellow, colorInfo.Black)
            };

            return await Task.FromResult(retVal);
        }

        public async Task<CMYK> ConvertRGBToCMYK(RGB colorInfo)
        {
            colorInfo.Blue = ChangeRangeZeroToOne(colorInfo.Blue);
            colorInfo.Red = ChangeRangeZeroToOne(colorInfo.Red);
            colorInfo.Green = ChangeRangeZeroToOne(colorInfo.Green);

            double black =1 - Math.Max(colorInfo.Blue, Math.Max(colorInfo.Red, colorInfo.Green));

            var retVal = new CMYK
            {
                Black = Math.Round(black * 100),
                Cyan = CalculateCmykColorCode(colorInfo.Red, black),
                Magenta = CalculateCmykColorCode(colorInfo.Green, black),
                Yellow = CalculateCmykColorCode(colorInfo.Blue, black)
            };
            return await Task.FromResult(retVal);

        }

        private double ChangeRangeZeroToOne(double color)
        {
            return color / 255;
        }

        private double CalculateRgbColorCode(double color, double black)
        {
            return Math.Round(255 * (1 - color / 100) * (1 - black / 100));
        }

        private double CalculateCmykColorCode(double color, double black)
        {
            return Math.Round((1 - color - black) / (1 - black) * 100);
        }
    }
}
