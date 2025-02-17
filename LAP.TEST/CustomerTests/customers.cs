﻿using LAP.BLL.Abstract;
using LAP.BLL.Concrete;
using LAP.CORE.Enum;
using LAP.DAL.Concrete;
using LAP.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LAP.TEST.CustomerTests
{
  public class customers
    {
        private readonly LapContext _context;
        private ICustomerManager _CustomerManager;
        public customers()
        {
            _context = new LapContext();
            _CustomerManager = new CustomerManager(new Repository<Customer>(_context));
        }

        [Fact]
        public void Initialize()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    var result = _CustomerManager.Add(new Customer { StName = "Hasan SOLA " + i, InStatus = (int)StatusInfo.Active, StDescription = "TEST" });
                    if (!result.Succeeded)
                    {
                        break;
                    }
                }
                var list = _CustomerManager.GetAll();
                Assert.Equal(5, list.ToList().Count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
