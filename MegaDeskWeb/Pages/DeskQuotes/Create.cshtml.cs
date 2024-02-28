using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using MegaDeskWeb.Services;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly DeskQuoteService _deskQuoteService;
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public CreateModel(DeskQuoteService deskQuoteService, MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _deskQuoteService = deskQuoteService;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } = default!;

        public decimal QuoteTotal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            QuoteTotal = _deskQuoteService.CalculateDeskQuoteTotal(DeskQuote);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("/DisplayQuote", new { customerName = DeskQuote.Name, width = DeskQuote.Width, depth = DeskQuote.Width, drawers = DeskQuote.DrawersNum, desktopMaterial = DeskQuote.Material, rush = DeskQuote.RushDays, date = DeskQuote.QuoteDate, quoteTotal = QuoteTotal });
        }
    }
}
