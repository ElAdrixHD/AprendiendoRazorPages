using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AprendiendoRazorPages.Models;

namespace AprendiendoRazorPages.Pages.Peliculas
{
    public class CreateModel : PageModel
    {
        private readonly AprendiendoRazorPages.Models.ApplicationDbContext _context;

        public CreateModel(AprendiendoRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Peliculas.Add(Pelicula);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}