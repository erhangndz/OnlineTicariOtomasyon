using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Current
    {
        public int CurrentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
