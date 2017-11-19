using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace midterm
{
    public partial class Admin : Form
    {
        Database db;
        validation v = new validation();
        public Admin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = admin_name.Text;
            string pass = admin_pass.Text;
            if (name != "" && pass != "")
            {
                    db = new Database();
                    int status = 0;
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "admin_login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@admin_name", name);
                    cmd.Parameters.AddWithValue("@admin_pass", pass);
                    try
                    {
                        status = Convert.ToInt16(cmd.ExecuteScalar());
                    }
                    catch (NotFiniteNumberException)
                    {
                        status = 0;
                    }
                    if (status == 1)
                    {
                        db.Close();
                        this.Close();
                        AdminDashboard ad = new AdminDashboard();
                        ad.Show();
                    }
                   else
                    {
                        MessageBox.Show("Invalid Username or password");
                        admin_name.Text = "";
                        admin_pass.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Fields should not be empty");
                }


            }
        }
    }
