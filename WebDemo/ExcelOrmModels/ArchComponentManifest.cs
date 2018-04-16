using ExcelORM;
using System.Collections;
using System.Collections.Generic;

namespace WebDemo.ExcelOrmModels
{
    /// <summary>
    /// 建筑构件清单
    /// </summary>
    [Class(RealUseDataStartRowIndex = 3, SheetName = "01建筑")]
    public class ArchComponentManifest
    {
        /// <summary>
        /// 一级构件分类
        /// </summary>
        [Property(ChangeToNextRowWhenReadValue = true,
            UseLastValueWhenNull = true,
            UseColumnIndex = 0)]
        public string CategoryFirstName { get; set; }


        /// <summary>
        /// 二级构件分类
        /// </summary>
        [Property(ChangeToNextRowWhenReadValue = true,
            UseLastValueWhenNull = true,
            UseColumnIndex = 2)]
        public string CategorySecondName { get; set; }


        /// <summary>
        /// 三级构件分类
        /// </summary>
        [Property(ChangeToNextRowWhenReadValue = true,
            UseLastValueWhenNull = true,
            UseColumnIndex = 4)]
        public string CategoryThirdName { get; set; }


        /// <summary>
        /// 四级构件分类
        /// </summary>
        [Property(ChangeToNextRowWhenReadValue = false,
            UseLastValueWhenNull = true,
            UseColumnIndex = 6)]
        public string CategoryFourthName { get; set; }


        /// <summary>
        /// 构件名称
        /// </summary>
        [Property(UseColumnIndex = 8)]
        public string Name { get; set; }


        /// <summary>
        /// 构件名称规则
        /// </summary>
        [Property(UseColumnIndex = 9)]
        public string RuleName { get; set; }


        /// <summary>
        /// 构件编号
        /// </summary>
        [Property(UseColumnIndex = 10)]
        public string Index { get; set; }


        /// <summary>
        /// 构件分类编码
        /// </summary>
        [Property(UseColumnIndex = 11)]
        public string Coding { get; set; }


        /// <summary>
        /// 构件分类编码中文名称
        /// </summary>
        [Property(UseColumnIndex = 12)]
        public string CodingChiness { get; set; }


        /// <summary>
        /// 族名称
        /// </summary>
        [Property(UseColumnIndex = 13)]
        public string FamilyName { get; set; }


        /// <summary>
        /// 族类型名称
        /// </summary>
        [Property(UseColumnIndex = 14)]
        public string FamilySymbolName { get; set; }


        /// <summary>
        /// 属性项名称
        /// </summary>
        [Property(UseColumnIndex = 15)]
        public List<string> ArrayPropertyName { get; set; }


        /// <summary>
        /// 属性项值
        /// </summary>
        [Property(UseColumnIndex = 16)]
        public List<string> ArrayPropertyValue { get; set; }


        /// <summary>
        /// 属性值单位
        /// </summary>
        [Property(UseColumnIndex = 17)]
        public string PropertyUnit { get; set; }


        /// <summary>
        /// 属性值类型 S/T
        /// </summary>
        [Property(UseColumnIndex = 18)]
        public string PropertyType { get; set; }
    }
}