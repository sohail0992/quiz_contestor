using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm
{
    public partial class user_list : Form
    {
        public user_list()
        {
            InitializeComponent();
        }

        private void user_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'midtermDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.midtermDataSet.users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
        }
    }
}
