using ExcelORM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Class(RealUseDataStartRowIndex = 1, SheetIndex = 0)]
    [Table("Student")]
    public class Student
    {
        
        [Required()]
        [Column(Order = 0)]
        public int ID { get; set; }


        [Property(ChangeToNextRowWhenReadValue = true,
            UseColumnIndex = 0,
            UseLastValueWhenNull = true)]
        [Column(Order = 1)]
        public string Name { get; set; }


        [Property(ChangeToNextRowWhenReadValue = true,
            UseColumnIndex = 1,
            UseLastValueWhenNull = true)]
        [Column(Order = 3)]
        public int Age { get; set; }


        [Property(ChangeToNextRowWhenReadValue = true,
            UseColumnIndex = 2,
            UseLastValueWhenNull = true, UseTransformerName ="String2Grid")]
        [Column(Order = 2)]
        public Grade Grade { get; set; }


        //[Timestamp]
        //byte[] RowVersion { get; set; }
    }
}
