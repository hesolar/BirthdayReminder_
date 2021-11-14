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

        public override string ToString() {
            return this.ID + " " + this.surname + ": " +
                "This:" + daysThisYear() + "---"+
                "Next:" + daysNextYear() +
                "\n";
        }

        public int daysNextYear() {
            return this.birthday.DayOfYear - DateTime.Now.DayOfYear > 0 ?
                 365 + Math.Abs(this.birthday.DayOfYear - DateTime.Now.DayOfYear) :
                 365 - Math.Abs(this.birthday.DayOfYear - DateTime.Now.DayOfYear);
        }
        public int daysThisYear() {
            return this.birthday.DayOfYear - DateTime.Now.DayOfYear;
        }
        public bool IsAlertPerson() {
            int thisd = daysThisYear();
            int next = daysNextYear();
            bool a = daysThisYear() > 0;
            bool b = daysThisYear() < 10;
            bool c = daysNextYear() > 0;
            bool d = daysThisYear() < 10;

            return (daysThisYear() > 0 && daysThisYear() < 10) || ( daysNextYear() > 0 && daysNextYear() < 10);
        }

    }
}
