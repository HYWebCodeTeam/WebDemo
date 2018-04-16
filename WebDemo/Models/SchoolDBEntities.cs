using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.ExcelOrmModels;
using WebDemo.Models;

namespace Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SchoolDBEntities : DbContext
    {
        public SchoolDBEntities() : 
            base("name=WebDemoDBConn")
        {
            
        }



        public DbSet<ArchComponentManifestEFModel> Datas { get; set; }
    }
}
