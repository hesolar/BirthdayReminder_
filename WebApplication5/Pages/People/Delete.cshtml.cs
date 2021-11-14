using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication5.Data;

namespace WebApplication5.Pages.People
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public DeleteModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public PeopleBirthday PeopleBirthday { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PeopleBirthday = await _context.PeopleBirthday.FirstOrDefaultAsync(m => m.ID == id);

            if (PeopleBirthday == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PeopleBirthday = await _context.PeopleBirthday.FindAsync(id);

            if (PeopleBirthday != null)
            {
                _context.PeopleBirthday.Remove(PeopleBirthday);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
