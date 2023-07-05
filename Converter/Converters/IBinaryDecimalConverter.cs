namespace Converter.Converters
{
    public interface IBinaryDecimalConverter
    {
        Task<int> ConvertBinaryToDecimal(string binaryValue);
        Task<string?> ConvertDecimalToBinary(decimal decimalValue);
    }
}