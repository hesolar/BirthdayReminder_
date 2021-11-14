using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication5.Data;

namespace WebApplication5.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context dbContext;

        public EditModel(WebApplication5.Data.WebApplication5Context context)
        {
            dbContext = context;
        }
        [BindProperty]
        public PeopleBirthday PeopleBirthday { get; set; }
        
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PeopleBirthday = await dbContext.PeopleBirthday.FirstOrDefaultAsync(m => m.ID == id);
            if (PeopleBirthday == null)
            {
                return NotFound();
            }
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

            dbContext.Attach(PeopleBirthday).State = EntityState.Modified;

            try
            {
                
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleBirthdayExists(PeopleBirthday.ID))
                {
                    dbContext.PeopleBirthday.Add(PeopleBirthday);
                    await dbContext.SaveChangesAsync();
                    /* return NotFound();*/
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PeopleBirthdayExists(string id)
        {
            return dbContext.PeopleBirthday.Any(e => e.ID == id);
        }
    }
}
