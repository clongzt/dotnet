using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataTable.ConvertColumnToRow.Data
{
    class DataUtil
    {
        public static DataTable GetTable1()
        {
            var dt = InitDataTable();
            InitDataRow(dt);
            return dt;
        }

        public static DataTable GetTable12()
        {
            var dt = InitDataTable();
            InitDataRow2(dt);
            return dt;
        }

        public static DataTable GetResultDataTable()
        {
            //创建一个名为"Table_New"的空表
            DataTable dt = new DataTable("Table_New");

            //1.创建空列
            //DataColumn dc = new DataColumn();
            //dt.Columns.Add(dc);
            //2.创建带列名和类型名的列(两种方式任选其一)
            dt.Columns.Add("dlbm", System.Type.GetType("System.String"));
            //  dt.Columns.Add("column0", typeof(String));
            //3.通过列架构添加列
            DataColumn mjdc = new DataColumn("bgq", typeof(double));
            DataColumn mjdc2 = new DataColumn("bgh", typeof(double));
            DataColumn mjdc3 = new DataColumn("cz", typeof(double));
            dt.Columns.Add(mjdc);
            dt.Columns.Add(mjdc2);
            dt.Columns.Add(mjdc3);
            return dt;
        }

        public static DataTable InitDataTable()
        {
          
            //创建一个名为"Table_New"的空表
            DataTable dt = new DataTable("Table_New");

            //1.创建空列
            //DataColumn dc = new DataColumn();
            //dt.Columns.Add(dc);
            //2.创建带列名和类型名的列(两种方式任选其一)
            dt.Columns.Add("Xzq", System.Type.GetType("System.String"));
          //  dt.Columns.Add("column0", typeof(String));
            //3.通过列架构添加列
            DataColumn mjdc = new DataColumn("T0101", typeof(double));
            DataColumn mjdc2 = new DataColumn("T0102", typeof(double));
            dt.Columns.Add(mjdc);
            dt.Columns.Add(mjdc2);
            return dt;
        }

        private static void InitDataRow(DataTable dt)
        {
            var row = dt.NewRow();
            row[0] = "430509123456";
            row[1] = 12.33;
            row[2] = 25.44;
            dt.Rows.Add(row);
        }

        private static void InitDataRow2(DataTable dt)
        {
            var row = dt.NewRow();
            row[0] = "430509123456";
            row[1] = 12.35;
            row[2] = 25.46;
            dt.Rows.Add(row);
        }


    }

    
}
