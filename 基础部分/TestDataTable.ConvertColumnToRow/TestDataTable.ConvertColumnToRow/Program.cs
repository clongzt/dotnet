using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataTable.ConvertColumnToRow
{
    class Program
    {
        static void Main(string[] args)
        {
            var columnToRow = new ColumnToRow();
           var result =columnToRow.ConvertTest();
            foreach (var row in result.Rows)
            {
                var dataRow = row as DataRow;
                Console.WriteLine("cl is {0},bgq ={1},bgh={2},cz={3}", dataRow[0], dataRow[1], dataRow[2], dataRow[3]);
            }
            Console.ReadLine();
        }
    }
}
