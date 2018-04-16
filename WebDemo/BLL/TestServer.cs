using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using Models;
using UnityUtility;

namespace BLL
{
    [Compent(RegistByClass = false)]
    public class TestServer : ITestServer
    {
        public bool TestMethod()
        {
            /*
            var Student1 = new Student
            {
                Name = Guid.NewGuid().ToString(),
                Age = 6,
                ID = 1,
                Grade = new Grade(1),
            };

            var Student2 = new Student
            {
                Name = Guid.NewGuid().ToString(),
                Age = 8,
                ID = 2,
                Grade = new Grade(3)
            };


            using (var db = new SchoolDBEntities())
            {
                var lstGrade = db.Datas.ToList();


                db.Datas.Add(Student1);
                db.Datas.Add(Student2);

                db.SaveChanges();
            }
            */

            return true;
        }
    }
}