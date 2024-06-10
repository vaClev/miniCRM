using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    
    public class Contact
    {
        public int Id { get; set; }
        public Partner Parntner { get; set;}
        public Deal? Deal { get; set;}
        public string GoalDescription {  get; set; }
        public string ResultDescription {  get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return ResultDescription;
        }
    }
}
