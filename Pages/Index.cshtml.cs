using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailDemo.Pages {
    public class IndexModel :PageModel {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel( ILogger<IndexModel> logger ) {
            _logger = logger;
        }

        public void OnGet() {
            Task.Factory.StartNew(main);
        }

        public async Task main(){
            var sender = new SmtpSender(() => new SmtpClient("localhost") {
                EnableSsl = false,
                //DeliveryMethod= SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //PickupDirectoryLocation=@"C:\Demos"
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            }) ;
            Email.DefaultSender = sender;
            var email = await Email.From("hectorsolar99@gmail.com")
                .To("hectorsolar99@gmail.com","Hector")
                .Subject("Thanks")
                .Body("Thanks!")
                .SendAsync();

        }
        
    }
}
