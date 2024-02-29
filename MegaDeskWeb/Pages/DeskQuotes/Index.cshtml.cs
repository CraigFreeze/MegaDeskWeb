using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;
       

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? NameSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<DeskQuote> quotes = from q in _context.DeskQuote
                                            orderby q.Name
                                            select q;


            if (!string.IsNullOrEmpty(SearchString) )
            {
                quotes = quotes.Where(q => q.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NameSort))
            {
                quotes = quotes.OrderByDescending(q => q.Name);
            }

            if (!string.IsNullOrEmpty(DateSort))
            {
                quotes = quotes.OrderByDescending(q => q.QuoteDate);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(q => q.Name);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(q => q.QuoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(q => q.QuoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(q => q.Name);
                    break;
            }

            DeskQuote = await quotes.ToListAsync();
        }
    }
}
