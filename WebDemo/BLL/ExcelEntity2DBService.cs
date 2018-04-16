using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;
using UnityUtility;
using WebDemo.Models;

namespace WebDemo.BLL
{
    [Compent(RegistByClass = false)]
    public class ExcelEntity2DBService : IEntity2DBService
    {
        public List<ArchComponentManifestEFModel> Datas { get; set; }


        public bool Save2DB(IExcelServer iExcelServer)
        {
            ExcelServerImp excelServerImp = iExcelServer as ExcelServerImp;

            Datas = new List<ArchComponentManifestEFModel>();

            using (var db = new SchoolDBEntities())
            {
                foreach (var ormData in excelServerImp.Datas)
                {
                    ArchComponentManifestEFModel data = new ArchComponentManifestEFModel(ormData);

                    db.Datas.Add(data);
                    Datas.Add(data);
                }

                db.SaveChanges();
            }


            return true;
        }
    }
}