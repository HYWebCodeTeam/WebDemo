using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;
using UnityUtility;

namespace WebDemo.BLL
{
    [Compent(RegistByClass = false, Singleton = true)]
    public class ExcelEntity2DBServic : IEntity2DBService
    {
        public bool Save2DB(IExcelServer iExcelServer)
        {
            ExcelServerImp excelServerImp = iExcelServer as ExcelServerImp;

            using (var db = new SchoolDBEntities())
            {
                db.Students.AddRange(excelServerImp.Students);

                db.SaveChanges();
            }

            return true;
        }
    }
}