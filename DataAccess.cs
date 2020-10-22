using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal
{
    class DataAccess:IDisposable
    {
        SqlConnection con;
        SqlCommand command;
        public DataAccess()
        {
            this.con = new SqlConnection(ConfigurationManager.ConnectionStrings["DailyJournal"].ConnectionString);
            this.con.Open();
        }

        ~DataAccess()
        {
            con.Close();
        }

        public void Dispose()
        {
            con.Close();
        }

        public SqlDataReader GetData(string sql)
        {
            command = new SqlCommand(sql, con);
            return command.ExecuteReader();
        }

        public int Execute(string sql)
        {
            command = new SqlCommand(sql, con);
            return command.ExecuteNonQuery();
        }
    }
}
