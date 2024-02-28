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
        public string Name { get; set; }
        public int RushDays { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int DrawersNum { get; set; }
        public DesktopMaterial Material { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        public DeskQuote()
        {

        }
    }
}
