using Converter.Entities.ColorConversionEntities;

namespace Converter.Converters
{
  

    public class ColorConverter : IColorConverter
    {
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

            double black = 1 - Math.Max(colorInfo.Blue, Math.Max(colorInfo.Red, colorInfo.Green));

            var retVal = new CMYK
            {
                Black = Math.Round(black * 100),
                Cyan = CalculateCmykColorCode(colorInfo.Red, black),
                Magenta = CalculateCmykColorCode(colorInfo.Green, black),
                Yellow = CalculateCmykColorCode(colorInfo.Blue, black)
            };
            return await Task.FromResult(retVal);

        }

        public async Task<RGB> ConvertHexadecimalToRgb(Hexadecimal hexadecimal)
        {
            List<char[]> hexList = hexadecimal.HexValue.Chunk(2).ToList();

            var retVal = new RGB
            {
                Red = ChangeBaseToTen(hexList[0].Reverse().ToList()),
                Green = ChangeBaseToTen(hexList[1].Reverse().ToList()),
                Blue = ChangeBaseToTen(hexList[2].Reverse().ToList())
            };

            return await Task.FromResult(retVal);
        }

        private double ChangeBaseToTen(List<char> list)
        {
            double decimalValue = 0;
            for (int i = 0; i < list.Count; i++)
            {
                decimalValue += GetHexValue(list[i]) * Math.Pow(16, i);
            }
            return decimalValue;
        }

        private static int GetHexValue(char hex) => hex switch
        {
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'A' => 10,
            'B' => 11,
            'C' => 12,
            'D' => 13,
            'E' => 14,
            'F' => 15,
            _ => throw new NotImplementedException()

        };



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
