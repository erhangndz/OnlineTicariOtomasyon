﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTransactionDal : GenericRepository<Transaction>, ITransactionDal
    {
        public List<Transaction> GetAll()
        {
            using var c = new Context();
            return c.Transactions.Include(x=>x.Staff).Include(x=>x.Current).Include(x=>x.Product).ToList();
        }
    }
}
