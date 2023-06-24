using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public Current Current { get; set; }
        public int CurrentID { get; set; }
        public Staff Staff { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public int  Number { get; set; }
        public decimal  Price { get; set; }
        public decimal  TotalPrice { get; set; }
    
    }
}
