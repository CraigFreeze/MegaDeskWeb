using MegaDeskWeb.Models;

namespace MegaDeskWeb.Services
{
    public class DeskQuoteService
    {
        private readonly decimal basePrice = 200;
        private readonly decimal perDrawerPrice = 50;

        public DeskQuoteService()
        {

        }

        public decimal CalculateDeskQuoteTotal(DeskQuote desk)
        {
            decimal rushOrderPrice = CalculateRushOrderPrice(desk);
            decimal surfaceMaterialPrice = CalculateSurfaceMaterialPrice(desk);
            decimal drawersPrice = CalculateDrawersPrice(desk);
            decimal deskAreaPrice = CalculateDeskAreaPrice(desk);

            decimal total = basePrice + rushOrderPrice + surfaceMaterialPrice + drawersPrice + deskAreaPrice;

            return total;
        }

        public decimal CalculateRushOrderPrice(DeskQuote desk)
        {

            return 5 * desk.RushDays;
        }

        public decimal CalculateDeskAreaPrice(DeskQuote desk)
        {
            // Calculate the desk area
            int deskArea = desk.Width * desk.Depth;

            // If the area is greater than 1000 square inches, add an extra $1 per square inch
            if (deskArea > 1000)
            {
                return deskArea - 1000; // Additional $1 per square inch beyond 1000
            }
            else
            {
                return 0; // No additional cost
            }
        }
        public decimal CalculateSurfaceMaterialPrice(DeskQuote desk)
        {
            // Define a list of tuples to store material prices
            List<(DesktopMaterial, decimal)> surfaceMaterialPrices = new List<(DesktopMaterial, decimal)>()
            {
                (DesktopMaterial.Laminate, 100),
                (DesktopMaterial.Oak, 200),
                (DesktopMaterial.Rosewood, 300),
                (DesktopMaterial.Veneer, 150),
                (DesktopMaterial.Pine, 50)
            };

            // Search for the price of the surface material in the list
            foreach (var materialPrice in surfaceMaterialPrices)
            {
                if (materialPrice.Item1 == desk.Material)
                {
                    return materialPrice.Item2; // Return the price if found
                }
            }

            // If the surface material is not found in the list, throw an exception
            throw new ArgumentException("Unknown surface material.");
        }

        public decimal CalculateDrawersPrice(DeskQuote desk)
        {
            decimal drawersPrice = desk.DrawersNum * perDrawerPrice;
            return drawersPrice;
        }
    }
}
