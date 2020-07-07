using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    namespace Ecio_Admin
    {
        /// <summary>SQL数据库助手类</summary>
        public class SqlHelper
        {
            //Sql连接语句
            /*注意引用System.Configuration
             * <connectionStrings>
             * <add name="YcSqlCon" 
             * connectionString="Data Source=服务器;Initial Catalog=数据库;User ID=登录名;Password=密码" 
             * providerName="System.Data.SqlClient"/>
             * </connectionStrings>
             */
            private string connectionString = "Data Source=微星;Initial Catalog=Erp;Integrated Security=True";
            //private string connectionString = "";
            //public SqlHelper(string sqlPath)
            //{
            //    //实例化对应的数据库链接
            //    connectionString = ConfigurationManager.ConnectionStrings[sqlPath].ConnectionString;
            //}

            /// <summary>执行不带参数的增删改SQL语句或存储过程 ，返回受影响的行数</summary>
            public int ExecuteNonQuery(string cmdText)
            {
                int res = 0;//受影响的行数
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            res = cmd.ExecuteNonQuery();//执行Sql语句并受影响的行数
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return res;
            }

            /// <summary>  执行带参数的增删改SQL语句或存储过程，返回受影响的行数</summary>
            public int ExecuteNonQuery(string cmdText, params object[] paras)
            {
                int res = 0;//受影响的行数
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.Parameters.AddRange(paras);//添加参数数组
                            if (paras != null)
                            {
                                for (int i = 0; i < paras.Length; i++)
                                {
                                    cmd.Parameters.AddWithValue("@" + i, paras[i]);
                                }
                            }
                            res = cmd.ExecuteNonQuery();//执行Sql语句并受影响的行数
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return res;
            }

            /// <summary> 执行不带参数的查询SQL语句或存储过程，返回DataTable对象</summary>
            public DataTable ExecuteQueryDataTable(string cmdText)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                dt.Load(sdr);
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return dt;
            }

            /// <summary> 执行带参数的查询SQL语句或存储过程，返回DataTable对象</summary>
            public DataTable ExecuteQueryDataTable(string cmdText, params object[] paras)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.Parameters.AddRange(paras);
                            if (paras != null)
                            {
                                for (int i = 0; i < paras.Length; i++)
                                {
                                    cmd.Parameters.AddWithValue("@" + i, paras[i]);
                                }
                            }
                            using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                dt.Load(sdr);
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return dt;
            }

            /// <summary> 执行不带参数的查询SQL语句或存储过程，返回DataSet对象</summary>
            public DataSet ExecuteQueryDataSet(string cmdText)
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(ds, "ds");
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return ds;
            }

            /// <summary> 执行带参数的查询SQL语句或存储过程，返回DataSet对象</summary>
            public DataSet ExecuteQueryDataSet(string cmdText, params object[] paras)
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//打开数据库链接
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.Parameters.AddRange(paras);
                            if (paras != null)
                            {
                                for (int i = 0; i < paras.Length; i++)
                                {
                                    cmd.Parameters.AddWithValue("@" + i, paras[i]);
                                }
                            }
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(ds, "ds");
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)//判断连接是否处于打开状态
                        {
                            conn.Close();//关闭与数据库的链接
                        }
                    }
                }
                return ds;
            }

            /// <summary>查询数据是否存在</summary>
            public bool ExecuteDataIsExistByData(string sqlStr)
            {
                bool iss = false;
                DataSet ds = ExecuteQueryDataSet(sqlStr);
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Rows.Count > 0) iss = true;
                }
                return iss;
            }

            /// <summary>查询数据是否存在 </summary>
            public bool ExecuteDataIsExistByData(string sqlStr, params object[] paras)
            {
                bool iss = false;
                DataSet ds = ExecuteQueryDataSet(sqlStr, paras);
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Rows.Count > 0) iss = true;
                }
                return iss;
            }

            /// <summary>查询增删改数据操作是否成功 </summary>
            public bool ExecuteDataIsExistByInt(string sqlStr)
            {
                int ds = ExecuteNonQuery(sqlStr);
                bool iss = ds > 0 ? true : false;
                return iss;
            }

            /// <summary>查询增删改数据操作是否成功 </summary>
            public bool ExecuteDataIsExistByInt(string sqlStr, params object[] paras)
            {
                int ds = ExecuteNonQuery(sqlStr, paras);
                bool iss = ds > 0 ? true : false;
                return iss;
            }
        }
    }
}
