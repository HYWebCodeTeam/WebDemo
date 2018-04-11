using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnityUtility;

namespace WebDemo.Utility
{
    [Compent(RegistByClass = false)]
    public class UseEFContxtCreater : IEFContextCreater
    {
        public DbContext CreatDbContext()
        {
            return new SchoolDBEntities();
        }
    }
}