using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm
{
    public partial class successfullCandidates : Form
    {
        public successfullCandidates()
        {
            InitializeComponent();
            Database db = new Database();
            SqlCommand resultCmd = db.conn.CreateCommand();
            resultCmd.CommandText = "successfull_candidate";
            resultCmd.CommandType = CommandType.StoredProcedure;
            resultCmd.Parameters.AddWithValue("@status", "passed");
            resultCmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = resultCmd;
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard ds = new AdminDashboard();
            ds.Show();

        }

        private void successfullCandidates_Load(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
          

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
