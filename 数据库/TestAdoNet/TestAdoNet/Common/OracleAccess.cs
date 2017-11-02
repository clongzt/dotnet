using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdoNet.Common
{
    public class OracleAccess
    {

        private readonly string _userName;

        public OracleConnection Connection { get; private set; }

        public OracleTransaction Transaction { get; private set; }
        public OracleAccess(string userName, string password, string instance, string server, int port)
        {
            _userName = userName;
            var connectionString = string.Format("Data Source={0}/{1};User ID={2};Password={3};", server + ":" + port, instance, userName, password);
            Connection = new OracleConnection(connectionString);
        }
        public OracleAccess(string connectionString)
        {
            Connection = new OracleConnection(connectionString);
        }
        public OracleAccess()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ToString();
            Connection = new OracleConnection(connectionString);
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
        }
        /// <summary>
        /// 打开连接池。
        /// </summary>
        public void Open()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        /// <summary>
        /// 关闭连接池。
        /// </summary>
        public void Close()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// 获取当前用户下所有表名称.
        /// </summary>
        /// <returns>表名称集合</returns>
        public IList<string> GetAllTableNames()
        {
            string sql = "SELECT table_name FROM user_tables";
            var command = new OracleCommand(sql, Connection);
            var dataAdapter = new OracleDataAdapter(command);
            var dataSet = new DataSet();
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "table_name");
            var table = dataSet.Tables["table_name"];
            return (from DataRow row in table.Rows select row["TABLE_NAME"].ToString()).ToList();
        }

        public DataRow GetColumn(string tableName, string columnName)
        {
            try
            {
                string sql = string.Format("select * from user_tab_columns where table_name=upper('{0}')  and COLUMN_NAME ='{1}' ", tableName, columnName);
                var command = new OracleCommand(sql, Connection);
                var dataAdapter = new OracleDataAdapter(command);
                var dataSet = new DataSet();
                dataSet.Clear();
                dataAdapter.Fill(dataSet, tableName);
                var table = dataSet.Tables[tableName];
                return table.Rows[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetColums(string tableName)
        {
            try
            {
                /**
                 * 2016-11-21
                 * 
                 *修改为'select * from user_tab_columns where table_name=upper('jiangyu_150300_100900_2016')'
                 * user_tab_columns不许要dba权限.
                 * 
                 *string sql = string.Format("select * from dba_tab_columns where owner=upper('{0}') and table_name=upper('{1}')", _userName, tableName);
                 * 
                 **/
                string sql = string.Format("select * from user_tab_columns where table_name=upper('{0}')", tableName);
                var command = new OracleCommand(sql, Connection);
                var dataAdapter = new OracleDataAdapter(command);
                var dataSet = new DataSet();
                dataSet.Clear();
                dataAdapter.Fill(dataSet, tableName);
                var table = dataSet.Tables[tableName];
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetConstructTable(string sourceTableName, string targetTableName)
        {
            //DataTable dataTable = GetColums(sourceTableName);
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("create table " + targetTableName + "(");
            //for (int index = 0; index < dataTable.Rows.Count; index++)
            //{
            //    DataRow dataRow = dataTable.Rows[index];
            //    stringBuilder.Append(OracleUtil.GetCreateSql(dataRow["COLUMN_NAME"].ToString(), dataRow["DATA_TYPE"].ToString(), dataRow["DATA_PRECISION"].ToString(), dataRow["DATA_SCALE"].ToString(), dataRow["DATA_LENGTH"].ToString(), dataRow["CHAR_LENGTH"].ToString()));
            //    if (index < dataTable.Rows.Count - 1)
            //    {
            //        stringBuilder.Append(",");
            //    }
            //}
            //return stringBuilder.Append(")").ToString();
            return "";
        }

        /// <summary>
        /// 获取创建表命令。
        /// </summary>
        /// <param name="sourceTableName">源表名称</param>
        /// <param name="targetTableName">目标表名称</param>
        /// <returns></returns>
        public OracleCommand GetCreateCommand(string sourceTableName, string targetTableName)
        {
            return new OracleCommand
            {
                ArrayBindCount = GetCount(sourceTableName),
                BindByName = true,
                CommandType = CommandType.Text,
                CommandText = GetConstructTable(sourceTableName, targetTableName)
            };
        }

      

        public DataTable GetColumnData(string sourceTableName, string columnName)
        {
            try
            {
                string sql = string.Format("SELECT {0} FROM {1} ", columnName, sourceTableName);
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, sourceTableName);
                    DataTable table = dataSet.Tables[sourceTableName];
                    return table;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// 
        /// 执行SQL语句，返回记录总数
        /// 
        /// sql语句
        /// 返回记录总条数
        public int GetCount(string tableName, string whereClause = "")
        {
            OracleCommand command = new OracleCommand(string.Format("select count(*)  from {0} {1}", tableName, whereClause), Connection);
            int count = Convert.ToInt32(command.ExecuteScalar().ToString());
            return count;
        }


        /// <summary>
        /// 查看某张表是否存在。
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <returns>是否存在</returns>
        public bool CheckTableExist(string tableName)
        {
            try
            {
                string sql = string.Format("select count(*) from tabs where table_name =upper('{0}')", tableName);
                OracleCommand command = new OracleCommand(sql, Connection);
                object result = command.ExecuteScalar();
                return result.ToString() != "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPage(string sql, int pageSize, int currPageIndex)
        {
            DataSet ds = new DataSet();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(sql, Connection);
                adapter.Fill(ds, pageSize * (currPageIndex - 1), pageSize, ds.DataSetName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public void ExcuteSQL(string sql)
        {
            try
            {
                OracleCommand command = new OracleCommand(sql, Connection) { CommandType = CommandType.Text };
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL出错，详细信息：{0}", ex));
            }
        }

        /// <summary>
        /// Delete table form tableName。
        /// </summary>
        /// <param name="tableName">tableName</param>
        public void DeleteTable(string tableName)
        {
            try
            {
                if (CheckTableExist(tableName))
                {
                    string sql = string.Format("DROP  TABLE {0} ", tableName);
                    OracleCommand command = new OracleCommand(sql, Connection) { CommandType = CommandType.Text };
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("删除表出错，详细信息：{0}", ex));
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                OracleCommand command = new OracleCommand(sql, Connection) { CommandType = CommandType.Text };
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL出错，详细信息：{0}", ex));
            }
        }

        /// <summary>
        /// 清空表数据。
        /// </summary>
        /// <param name="tableName"></param>
        public void ClearTable(string tableName)
        {
            try
            {
                string sql = string.Format("delete  from {0} ", tableName.ToUpper());
                OracleCommand command = new OracleCommand(sql, Connection) { CommandType = CommandType.Text };
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("清空表数据出错，详细信息：{0}", ex));
            }
        }


        public object ExecuteScalar(string sql)
        {
            try
            {
                OracleCommand command = new OracleCommand(sql, Connection) { CommandType = CommandType.Text };
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL出错，详细信息：{0}", ex));
            }
        }

        public DataTable ExecuteTable(string sql)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL出错，详细信息：{0}", ex));
            }
        }

        public Boolean ExcuteProcedure(string commandText, IDataParameter[] cmdParams)
        {
            var exec = true;
            try
            {
                OracleCommand command = Connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandText;
                foreach (var item in cmdParams)
                {
                    command.Parameters.Add(item);
                }
                command.ExecuteNonQuery();
                var flag = command.Parameters[cmdParams[cmdParams.Length - 1].ParameterName].Value.ToString();
                if (flag != "1") exec = false;
            }
            catch (Exception ex)
            {
                exec = false;
                throw;
            }
            return exec;
        }

    }
}
