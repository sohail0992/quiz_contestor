using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace midterm
{

    class Database
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataTable dt;


        public Database()
        {
            conn = new SqlConnection("Data Source=DESKTOP-8QJB55Q;Initial Catalog=midterm;Integrated Security=True");
            conn.Open();
        }

        public void SqlQuery(string query)
        {

            cmd = new SqlCommand(query, conn);
        }

        public DataTable ExQuery()
        {

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public void ExNonQuery()
        { //just to execute query from database

            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            conn.Close();
        }

    }
}
