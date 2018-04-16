using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using UnityUtility;
using WebDemo.ExcelOrmModels;

namespace WebDemo.BLL
{
    [Compent(RegistByClass = false)]
    public class ExcelServerImp:IExcelServer
    {
        public ExcelServerImp()
        {
            // 创建ExcelORM单元格数据内容转换器
            //Dictionary<string, ExcelORM.ChageValueDelegate> mapTrans = 
            //    new Dictionary<string, ExcelORM.ChageValueDelegate>();
            //mapTrans.Add("String2Grid", new ExcelORM.ChageValueDelegate(Grade.TransformByString));

            //useManger = new ExcelORM.ExcelORMManger(mapTrans);

            useManger = new ExcelORM.ExcelORMManger();
        }


        /// <summary>
        /// 将一个Excel文件通过ORM转为ORM对象
        /// </summary>
        /// <param name="strFilePathName"></param>
        /// <returns></returns>
        public bool DoConvert(string strFilePathName)
        {
            return useManger.TryRead(strFilePathName, out m_lstData);
        }


        /// <summary>
        /// 注入ExcelManger
        /// </summary>
        [Dependency]
        public ExcelORM.ExcelORMManger useManger { set; get; }


        List<ArchComponentManifest> m_lstData;


        public List<ArchComponentManifest> Datas
        {
            get
            {
                return m_lstData;
            }
        }
    }
}
