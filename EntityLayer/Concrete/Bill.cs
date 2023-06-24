using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Bill
    {
        public int BillID { get; set; }
        public string SerialNumber { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public DateTime Time { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public bool Status { get; set; }
        public List<BillItem> BillItems { get; set; }
    }
}
