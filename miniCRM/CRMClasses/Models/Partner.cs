﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    public class Partner: ICloneable
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string INN { get; set; }

        public Partner() 
        {
            //Id = Guid.NewGuid();
            FullName = "";
            ShortName = "";
            INN = "0";
        }
        public object Clone()
        {
            Partner clone = new Partner();
            clone.FullName = this.FullName;
            clone.ShortName = this.ShortName;
            clone.INN = this.INN;
            clone.Id = this.Id;

            return clone;
        }
        public override string ToString()
        {
            return $"{ShortName} ИНН: {INN}";
        }
    }
}
