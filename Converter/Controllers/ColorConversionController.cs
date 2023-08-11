using Converter.Converters;
using Converter.Entities.ColorConversionEntities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Converter.Controllers
{

    [Route("/")]
    [ApiController]
    public class ColorConversionController : ControllerBase
    {
        private readonly ILogger<ColorConversionController> _logger;
        private readonly IColorConverter _converter;

        public ColorConversionController(ILogger<ColorConversionController> logger, IColorConverter converter)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        [HttpGet("CMYK2RGBConversion")]
        public async Task<RGB> ConvertCMYK2RGB([FromQuery] CMYK colorInfo)
        {
            return await _converter.ConvertCMYKToRGB(colorInfo);
        }

        [HttpGet("RGB2CMYKConversion")]
        public async Task<CMYK> ConvertRGB2CMYK([FromQuery] RGB colorInfo)
        {
            return await _converter.ConvertCMYKToRGB(colorInfo);
        }


    }
}
