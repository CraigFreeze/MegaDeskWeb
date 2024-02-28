using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public enum DesktopMaterial { Laminate, Oak, Pine, Rosewood, Veneer }
    public class DeskQuote
    {
        //Create the contants
        public const int MINWIDTH = 24;

        public const int MAXWIDTH = 96;

        public const int MINDEPTH = 12;

        public const int MAXDEPTH = 48;


        public int Id { get; set; }
        public string? Name { get; set; }
        public int RushDays { get; set; }

        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96 inches")]
        public int Width { get; set; }

        [Range(12, 48, ErrorMessage = "Depth must be between 12 and 48 inches")]
        public int Depth { get; set; }

        [Range(0, 7, ErrorMessage = "Number of drawers must be between 0 and 7")]
        public int DrawersNum { get; set; }
        public DesktopMaterial Material { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        public DeskQuote()
        {

        }
    }
}
