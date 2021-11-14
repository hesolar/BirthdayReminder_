using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1;
using WebApplication5.Data;

namespace WebApplication5.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public CreateModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PeopleBirthday PeopleBirthday { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PeopleBirthday.Add(PeopleBirthday);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
