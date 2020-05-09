﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDeskLine_ToPlant
{
    public class RxTypeList
    {
        /// <summary>
        /// CadLine数据
        /// </summary>
       public class AcadLine
        {
            public virtual string Name { get; set; }
            public virtual string ID { get; set; }
            public virtual double[] StartPoint { get; set; }
            public virtual double[] EndPoint { get; set; }
            public virtual double FwAngle { get; set; }
        }
        /// <summary>
        /// 圆角类
        /// </summary>
        public class AcDbArc
        {
            public virtual string Name { get; set; }
            public virtual string ID { get; set; }
            /// <summary>
            /// 弧中心
            /// </summary>
            public virtual double[] Center { get; set; }
            /// <summary>
            /// 弧起始点
            /// </summary>
            public virtual double[] StartPoint { get; set; }
            /// <summary>
            /// 弧结束点
            /// </summary>
            public virtual double[] EndPoint { get; set; }
            /// <summary>
            /// 弧起始角
            /// </summary>
            public virtual double StartAngle { get; set; }
            /// <summary>
            /// 弧结束角
            /// </summary>
            public virtual double EndAngle { get; set; }
            /// <summary>
            /// 弧半径
            /// </summary>
            public virtual double Radius { get; set; }
            public virtual double[] Normal { get; set; }
        }
        /// <summary>
        /// 暂不使用
        /// </summary>
        public  class AcDbRec
        {
            public virtual string Name { get; set; }
            public virtual string ID { get; set; }
            public virtual double[] StartPoint { get; set; }
            public virtual double[] EndPoint { get; set; }
            public virtual double[] StartAngle { get; set; }
            public virtual double[] EndAngle { get; set; }
            public virtual double[] Radius { get; set; }
        }
        /// <summary>
        /// Plant Simulation 成员变量集合
        /// </summary>
    }
    public class PlantValue
    {
        public virtual string ModelPath { get; set; }
        public virtual bool ModelOppend { get; set; }
    }

}
