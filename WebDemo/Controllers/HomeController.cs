using BLL;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        public ActionResult ConvertExcel()
        {
            // 1、接收文件
            var strFilePathName = GetUploadFilePathName();


            // 2、获取Excel文件对象
            m_iExcelService.DoConvert(strFilePathName);


            // 3、写入数据库
            m_iEntity2DBService.Save2DB(m_iExcelService);


            return View(m_iExcelService as ExcelServerImp);
        }


        string GetUploadFilePathName()
        {
            Stream uploadStream = null;
            FileStream fs = null;
            string strFilePathName = string.Empty;

            try
            {
                HttpPostedFileBase postFileBase = Request.Files["excelFile"];
                uploadStream = postFileBase.InputStream;
                int bufferLen = 1024;
                byte[] buffer = new byte[bufferLen];
                int contentLen = 0;

                string fileName = Path.GetFileName(postFileBase.FileName);
                string baseUrl = Server.MapPath("/");
                string uploadPath = baseUrl + @"App_Data\";
                strFilePathName = Path.Combine(uploadPath, fileName);

                fs = new FileStream(strFilePathName, FileMode.Create, FileAccess.ReadWrite);

                while ((contentLen = uploadStream.Read(buffer, 0, bufferLen)) != 0)
                {
                    fs.Write(buffer, 0, bufferLen);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            finally
            {
                if (null != fs)
                {
                    fs.Close();
                }
                if (null != uploadStream)
                {
                    uploadStream.Close();
                }
            }

            return strFilePathName;
        }



        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
    }
}