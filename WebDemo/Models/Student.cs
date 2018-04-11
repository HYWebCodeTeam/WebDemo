using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Student")]
    public class Student
    {
        [Required()]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order = 1)]
        public string Name { get; set; }

        [Column(Order = 3)]
        public int Age { get; set; }

        [Column(Order = 2)]
        public Grade Grade { get; set; }


        //[Timestamp]
        //byte[] RowVersion { get; set; }
    }
}
