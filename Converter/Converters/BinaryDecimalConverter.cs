
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Converter.Converters
{
    public class BinaryDecimalConverter : IBinaryDecimalConverter
    {
        public async Task<int> ConvertBinaryToDecimal(string binaryValue)
        {
            ValidateBinaryValue(binaryValue);

            List<int> splittedBinaryList = binaryValue.ToCharArray().Select(x => x.ToString()).Select(x => int.Parse(x)).Reverse().ToList();
            int result = 0;

            for (int i = 0; i < splittedBinaryList.Count; i++)
            {
                result += splittedBinaryList[i] * (int)Math.Pow(2, i);
            }

            return await Task.FromResult(result);

        }

        public async Task<string?> ConvertDecimalToBinary(decimal decimalValue)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while ((int)decimalValue > 0)
            {
                var remainder = (int)decimalValue % 2;
                decimalValue /= 2;
                stringBuilder.Append(remainder);
            }
            return await Task.FromResult(new string(stringBuilder.ToString().Reverse().ToArray()));

        }

        private void ValidateBinaryValue(string binaryValue)
        {
            if (string.IsNullOrEmpty(binaryValue))
            {
                throw new ArgumentNullException(nameof(binaryValue), "Binary value can not be empty");
            }
            Regex regex = new Regex("01", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(binaryValue))
            {
                throw new InvalidDataException("Binary value cannot contains other than 0 or 1");
            }

            if (binaryValue.Length > 32)
            {
                throw new ArgumentOutOfRangeException(nameof(binaryValue), binaryValue.Length, "The specified binary string can not be longer than 32 characters.");
            }

        }
    }
}
