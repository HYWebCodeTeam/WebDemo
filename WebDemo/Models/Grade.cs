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

        public Grade(string strName)
        {
            GradeName = strName;
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



        static public Grade TransformByString(string inputString)
        {
            return new Grade(inputString);
        }
    }
}
