using System.ComponentModel.DataAnnotations;

namespace Converter.Entities.ColorConversionEntities
{
    public class RGB
    {
        [Range(0,255), Required]
        public double Red { get; set; }
        [Range(0, 255), Required]
        public double Green { get; set; }
        [Range(0, 255), Required]
        public double Blue { get; set; }

    }
}