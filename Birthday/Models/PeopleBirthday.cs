using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1 {
    [Table("Birthdays")]
    public class PeopleBirthday {
        public PeopleBirthday() {
                
        }

        public PeopleBirthday( string iD,string surname,DateTime birthday ) {
            ID = iD;
            this.surname = surname;
            this.birthday = birthday;
        }

        public string ID { get; set; }
        public string surname { get; set; }
        public DateTime birthday { get; set; }
    }
}
