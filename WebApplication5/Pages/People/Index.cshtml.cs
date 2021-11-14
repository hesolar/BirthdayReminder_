using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication5.Data;

namespace WebApplication5.Pages.People
{
    public class IndexModel : PageModel
    {
        
        public IList<PeopleBirthday> PeopleBirthday { get;set; }
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public IndexModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        

        public async Task OnGetAsync()
        {
           
            PeopleBirthday = await _context.PeopleBirthday.ToListAsync();
            PeopleBirthday = PeopleBirthday.OrderBy(z => (z.birthday.DayOfYear - DateTime.Now.DayOfYear)).ToList();
            sendEmailWithTop10Birthdays();
        }
        public void sendEmailWithTop10Birthdays() {
            String notAlertPerson = "";
            PeopleBirthday.Take(10).ToList().ForEach(x =>
                notAlertPerson += x.ToString());
           
            List<PeopleBirthday> personas = PeopleBirthday.Where(x => x.IsAlertPerson()).ToList();
            String AlertPerson;
            if( personas.Any() ) {
                AlertPerson = "----ALERT----\n";
                personas.ForEach(x => AlertPerson += x.ToString());
                AlertPerson += "-------------\n";
            }
            else AlertPerson = "No birthdays near.\n";

            Sender.Email(AlertPerson + notAlertPerson);
        }
       

        List<PeopleBirthday> AlertPersons=new();
    }
}
