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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            sign add_sign = new sign();
            add_sign.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_sign us = new update_sign();
            us.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            user_list ls = new user_list();
            ls.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            search_user su = new search_user();
            su.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            successfullCandidates sc = new successfullCandidates();
            sc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm md = new mainForm();
            md.Show();
        }
    }
}
