using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ToolCode;
using WebDemo.ExcelOrmModels;
using WebDemo.Utility;

namespace WebDemo.Models
{
    [Table("ArchComponentManifest")]
    public class ArchComponentManifestEFModel
    {
        public ArchComponentManifestEFModel(ArchComponentManifest data)
        {
            CategoryFirstName = data.CategoryFirstName;
            CategorySecondName = data.CategorySecondName;
            CategoryThirdName = data.CategoryThirdName;
            CategoryFourthName = data.CategoryFourthName;

            Name = data.Name;
            RuleName = data.RuleName;

            Index = data.Index;
            Coding = data.Coding;
            CodingChiness = data.CodingChiness;

            FamilyName = data.FamilyName;
            FamilySymbolName = data.FamilySymbolName;

            PropertyName = data.ArrayPropertyName == null ? string.Empty : StrEscapeTool.EscapeAndMerge(data.ArrayPropertyName);
            PropertyValue = data.ArrayPropertyValue == null ? string.Empty : StrEscapeTool.EscapeAndMerge(data.ArrayPropertyValue);

            PropertyType = data.PropertyType;
            PropertyUnit = data.PropertyUnit;
        }


        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 一级构件分类
        /// </summary>
        public string CategoryFirstName { get; set; }


        /// <summary>
        /// 二级构件分类
        /// </summary>
        public string CategorySecondName { get; set; }


        /// <summary>
        /// 三级构件分类
        /// </summary>
        public string CategoryThirdName { get; set; }


        /// <summary>
        /// 四级构件分类
        /// </summary>
        public string CategoryFourthName { get; set; }


        /// <summary>
        /// 构件名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 构件名称规则
        /// </summary>
        public string RuleName { get; set; }


        /// <summary>
        /// 构件编号
        /// </summary>
        public string Index { get; set; }


        /// <summary>
        /// 构件分类编码
        /// </summary>
        public string Coding { get; set; }


        /// <summary>
        /// 构件分类编码中文名称
        /// </summary>
        public string CodingChiness { get; set; }


        /// <summary>
        /// 族名称
        /// </summary>
        public string FamilyName { get; set; }


        /// <summary>
        /// 族类型名称
        /// </summary>
        public string FamilySymbolName { get; set; }


        /// <summary>
        /// 属性项名称
        /// </summary>
        public string PropertyName { get; set; }


        /// <summary>
        /// 属性项值
        /// </summary>
        public string PropertyValue { get; set; }


        /// <summary>
        /// 属性值单位
        /// </summary>
        public string PropertyUnit { get; set; }


        /// <summary>
        /// 属性值类型 S/T
        /// </summary>
        public string PropertyType { get; set; }
    }
}