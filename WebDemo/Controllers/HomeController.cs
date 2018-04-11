using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public ITestServer m_iServer { get; set; }


        // GET: Home
        public ActionResult Index()
        {
            m_iServer.TestMethod();

            return View();
        }
    }
}