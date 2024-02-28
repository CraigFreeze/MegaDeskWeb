using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;




namespace MegaDeskWeb.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MegaDeskWebContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MegaDeskWebContext>>());
            if (context == null || context.DeskQuote == null)
            {
                throw new ArgumentNullException("Null MegaDeskWebPContext");
            }

            // Look for any quotes.
            if (context.DeskQuote.Any())
            {
                return;   // DB has been seeded
            }

            context.DeskQuote.AddRange(
                new DeskQuote
                {
                    Name = "Test Customer",
                    Width = 25,
                    Depth = 23,
                    DrawersNum = 3,
                    Material = DesktopMaterial.Laminate,
                    QuoteDate = DateTime.Parse("2024-2-07"),
                    RushDays = 3
                },

                new DeskQuote
                {
                    Name = "Test Customer",
                    Width = 35,
                    Depth = 30,
                    DrawersNum = 5,
                    Material = DesktopMaterial.Pine,
                    QuoteDate = DateTime.Parse("2024-2-04"),
                    RushDays = 5,
                },

                new DeskQuote
                {
                    Name = "Test Customer",
                    Width = 45,
                    Depth = 35,
                    DrawersNum = 2,
                    Material = DesktopMaterial.Oak,
                    QuoteDate = DateTime.Parse("2024-2-01"),
                    RushDays = 7,
                },

                new DeskQuote
                {
                    Name = "Test Customer",
                    Width = 60,
                    Depth = 40,
                    DrawersNum = 7,
                    Material = DesktopMaterial.Rosewood,
                    QuoteDate = DateTime.Parse("2024-2-03"),
                    RushDays = 14,
                },
                 new DeskQuote
                 {
                     Name = "Test Customer",
                     Width = 85,
                     Depth = 45,
                     DrawersNum = 1,
                     Material = DesktopMaterial.Veneer,
                     QuoteDate = DateTime.Parse("2024-2-25"),
                     RushDays = 3,
                 }
            );

            context.SaveChanges();
        }
    }
}
