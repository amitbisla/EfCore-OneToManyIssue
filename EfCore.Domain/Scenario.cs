using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Domain
{
   public class Scenario
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string EntityCode { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Detail> Details { get; set; }

    }
}
