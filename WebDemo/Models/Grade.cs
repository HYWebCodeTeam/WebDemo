using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Grade")]
    public class Grade
    {
        public Grade()
        {

        }

        public Grade(int id)
        {
            GradeID = id;
            GradeName = id.ToString() + "Level";
        }


        [Required()]
        public int GradeID { get; set; }


        public string GradeName { get; set; }


        public virtual DbSet<Student> Students { get; set; }
    }
}
