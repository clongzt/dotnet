using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataTable.ConvertColumnToRow.Data;

namespace TestDataTable.ConvertColumnToRow
{
    public class ColumnToRow
    {

        public DataTable ConvertTest()
        {
            var dt = DataUtil.GetTable1();
            var dt2 = DataUtil.GetTable12();
            var dts = DataUtil.GetResultDataTable();
            var stRow = dt.Rows[0];
            var endRow = dt2.Rows[0];
            foreach (var column in dt.Columns)
            {
                var name = (column as DataColumn).ColumnName;
                if (name.StartsWith("T"))
                {
                    var newRow = dts.Rows.Add();
                    newRow[0] = name;
                    var stValue = double.Parse(stRow[name].ToString());
                    newRow[1] = stValue;
                    var endValue = double.Parse(endRow[name].ToString());
                    newRow[2] = endValue;
                    var cz = endValue - stValue;
                    newRow[3] = Math.Round(cz);
                }
            }

            return dts;
        }
    }
}
