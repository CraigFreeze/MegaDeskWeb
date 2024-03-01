using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using MegaDeskWeb.Services;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly DeskQuoteService _deskQuoteService;
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public EditModel(DeskQuoteService deskQuoteService, MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _deskQuoteService = deskQuoteService;
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } = default!;

        [BindProperty]
        public decimal QuoteTotal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deskquote =  await _context.DeskQuote.FirstOrDefaultAsync(m => m.Id == id);
            if (deskquote == null)
            {
                return NotFound();
            }
            DeskQuote = deskquote;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            QuoteTotal = _deskQuoteService.CalculateDeskQuoteTotal(DeskQuote);
            DeskQuote.QuoteTotal = QuoteTotal;
            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.Id == id);
        }
    }
}
