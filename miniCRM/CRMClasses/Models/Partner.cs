using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    public class Partner
    {
        public int Id { get;}
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string INN { get; set; }

        public override string ToString()
        {
            return $"{ShortName} ИНН: {INN}";
        }
    }
}
