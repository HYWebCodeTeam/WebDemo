using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SchoolDBEntities : DbContext
    {
        public SchoolDBEntities() : 
            base("name=WebDemoDBConn")
        {
            
        }



        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
