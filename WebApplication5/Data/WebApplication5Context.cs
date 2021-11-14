using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication5.Data
{
    public class WebApplication5Context : DbContext
    {
        public WebApplication5Context (DbContextOptions<WebApplication5Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.PeopleBirthday> PeopleBirthday { get; set; }
    }
}
