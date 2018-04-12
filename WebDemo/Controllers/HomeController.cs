using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;
using WebDemo.BLL;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        //[Dependency]
        //public ITestServer m_iServer { get; set; }



        /// <summary>
        /// excel orm
        /// </summary>
        [Dependency]
        public IExcelServer m_iExcelService { get; set; }


        /// <summary>
        /// excel data -> DB
        /// </summary>
        [Dependency]
        public IEntity2DBService m_iEntity2DBService { get; set; }




        // GET: Home
        public ActionResult Index()
        {
            //m_iServer.TestMethod();

            return View();
        }



        /// <summary>
        /// 请求转换一个Excel文件
        /// </summary>
        /// <returns></returns>
        public ActionResult ConvertExcel()
        {
            // 1、获取Excel文件对象
            const string strFilePathName = @"E:\1.xlsx";
            m_iExcelService.DoConvert(strFilePathName);


            // 2、写入数据库
            m_iEntity2DBService.Save2DB(m_iExcelService);


            return View();
        }
    }
}