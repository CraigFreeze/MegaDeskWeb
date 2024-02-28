namespace MegaDeskWeb.Models
{
    public class DeskQuote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RushDays { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int DrawersNum { get; set; }
        public string Material { get; set; }
        public DateTime QuoteDate { get; set; }
    }
}
