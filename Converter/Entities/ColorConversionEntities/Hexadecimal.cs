using System.ComponentModel.DataAnnotations;

namespace Converter.Entities.ColorConversionEntities
{
    public class Hexadecimal
    {
        [MinLength(6),MaxLength(6)]
        public required string HexValue { get; set; }
    }
}