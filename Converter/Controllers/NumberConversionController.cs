using Converter.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Converter.Controllers
{

    [Route("/")]
    [ApiController]
    public class NumberConversionController : ControllerBase
    {
        private readonly ILogger<NumberConversionController> _logger;
        private readonly IBinaryDecimalConverter _converter;

        public NumberConversionController(ILogger<NumberConversionController> logger, IBinaryDecimalConverter converter)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        [HttpGet("ConvertBinaryToDecimal")]
        public async Task<int> ConvertBinaryToDecimal(string binary)
        {
            return await _converter.ConvertBinaryToDecimal(binary);
        }

        [HttpGet("ConvertDecimalToBinary")]
        public async Task<string?> ConvertDecimalToBinary(int decimalValue)
        {
            return await _converter.ConvertDecimalToBinary(decimalValue);
        }
    }
}
