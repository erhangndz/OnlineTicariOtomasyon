using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BillItem
    {
        public int BillItemID { get; set; }
        public string Description { get; set; }
        public int   Number { get; set; }
        public int  UnitPrice { get; set; }
        public int  Price { get; set; }
        public int BillID { get; set; }
        public Bill Bills { get; set; }
    }
}

