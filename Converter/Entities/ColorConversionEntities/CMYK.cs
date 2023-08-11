using System.ComponentModel.DataAnnotations;

namespace Converter.Entities.ColorConversionEntities
{
    public class CMYK
    {
        [Range(0, 100),Required]
        public double Cyan { get; set; }
        [Range(0, 100), Required]
        public double Magenta { get; set; }
        [Range(0, 100), Required]
        public double Yellow { get; set; }
        [Range(0, 100), Required]
        public double Black { get; set; }
    }
}