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
                    Name = "Katrina",
                    Width = 25,
                    Depth = 23,
                    DrawersNum = 3,
                    Material = DesktopMaterial.Laminate,
                    QuoteDate = DateTime.Parse("2024-2-07"),
                    RushDays = 3,
                    QuoteTotal = 465
                },

                new DeskQuote
                {
                    Name = "Heather",
                    Width = 35,
                    Depth = 30,
                    DrawersNum = 5,
                    Material = DesktopMaterial.Pine,
                    QuoteDate = DateTime.Parse("2024-2-04"),
                    RushDays = 5,
                    QuoteTotal = 575
                },

                new DeskQuote
                {
                    Name = "Nancy",
                    Width = 45,
                    Depth = 35,
                    DrawersNum = 2,
                    Material = DesktopMaterial.Oak,
                    QuoteDate = DateTime.Parse("2024-2-01"),
                    RushDays = 7,
                    QuoteTotal = 1110
                },

                new DeskQuote
                {
                    Name = "Lyn",
                    Width = 60,
                    Depth = 40,
                    DrawersNum = 7,
                    Material = DesktopMaterial.Rosewood,
                    QuoteDate = DateTime.Parse("2024-2-03"),
                    RushDays = 14,
                    QuoteTotal = 2250
                },
                 new DeskQuote
                 {
                     Name = "Wendy",
                     Width = 85,
                     Depth = 45,
                     DrawersNum = 1,
                     Material = DesktopMaterial.Veneer,
                     QuoteDate = DateTime.Parse("2024-2-25"),
                     RushDays = 3,
                     QuoteTotal = 3240
                 }
            );

            context.SaveChanges();
        }
    }
}
