using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Protocol
{
    /// <summary>
    /// 对数据库的操作
    /// </summary>
    public class DataOperator
    { 
        //连接数据库的字符串====有点不敢相信我的charset可以用吗？应该是我的密码为空可以这样写吗？
        static string connection = "Data Source=CYH;DataBase=db_MyQQ;User ID=sa;Password=;";
        //
       public  static SqlConnection conn = new SqlConnection(connection);

        ///<summary>
        ///返回查询内容的第一行第一列
        ///</summary>
        ///<param name="sql">传入对数据库操作字符串</param>
        ///<returns>数据库中有相应内容就返回true</returns>
        public static int ESSql(string sql)
        {


            //使用SQL Command对象进行数据库相应查询
            SqlCommand command = new SqlCommand(sql, conn);
            //判断数据库是否打开
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int num = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return num;

        }
        /// <summary>
        /// 对数据库进行增、删、改操作
        /// </summary>
        /// <param name="sql">传入对数据库操作字符串</param>
        public static int ENQSql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        ///<summary>
        ///执行SQL查询语句，并返回DataSet数据集
        ///</summary>
        ///<param name="sql">要执行的SQL语句</param>
        ///<returns>DataSet数据集，存储查询结果</returns>
        public static DataSet GetDataSet(string sql)
        {
            //指定要执行的SQL语句
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, connection);
            //创建数据集对象
            DataSet ds = new DataSet();
            //填充数据集
            sqlda.Fill(ds);
            //返回数据集
            return ds;
        }

        /// <summary>
        /// 执行SQL查询，并返回SqlDataReader
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>SqlDataReader数据集</returns>
        public static SqlDataReader GetDataReader(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);//指定要执行的SQL语句
            if (conn.State == ConnectionState.Open)//如果当前数据连接处于打开状态
                conn.Close();  //关闭数据库连接
            conn.Open();//打开数据库连接
            SqlDataReader datareader = command.ExecuteReader();//生成SqlDataReader
            return datareader;//返回SqlDataReader
        }
    }
}

