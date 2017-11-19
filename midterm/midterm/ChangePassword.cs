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
    public partial class ChangePassword : Form
    {
        validation vs = new validation();
        Database db;
        String oldPassword;
        private long cnic_num;
        public ChangePassword()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cnic_create_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newpass.Text != "" && confirmpass.Text!="")
            {
                string newPassword = newpass.Text;
                string confirmPassword = confirmpass.Text;
                if (System.Text.ASCIIEncoding.ASCII.GetByteCount(newPassword) >= 8)
                {
                    if (newPassword.Equals(confirmPassword))
                    {
                        db = new Database();
                        int is_locked = 0;
                        SqlCommand altercmd = db.conn.CreateCommand();
                        altercmd.CommandText = "alter_users_lock";
                        altercmd.CommandType = CommandType.StoredProcedure;
                        altercmd.Parameters.AddWithValue("@cnic", getCnic());
                        altercmd.Parameters.AddWithValue("@pass", oldPassword);
                        altercmd.Parameters.AddWithValue("@newpass", newPassword);
                        altercmd.Parameters.AddWithValue("@islocked", is_locked);
                        altercmd.ExecuteNonQuery();
                        db.Close();
                        MessageBox.Show("Password updated successfully");
                        newpass.Text = "";
                        confirmpass.Text = "";
                        login ls = new login();
                        this.Hide();
                        ls.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password must be match");
                        newpass.Text = "";
                        confirmpass.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Password must be at least 8 digits long");
                    newpass.Text = "";
                    confirmpass.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Value for field is required");
            }
        }

        public void setCnic(long cnic)
        {
            cnic_num = cnic;
        }
        public long getCnic()
        {
            return cnic_num;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void oldpassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oldpass.Text != "")
            {
                oldPassword = oldpass.Text;
                if (System.Text.ASCIIEncoding.ASCII.GetByteCount(oldPassword) >= 8)
                {
                    db = new Database();
                    login user = new login();
                    int status = 0;
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", oldPassword);
                    cmd.Parameters.AddWithValue("@cnic", getCnic());
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
                        panel2.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Invalid old password");
                    }
                    db.Close();
                }
                else
                {
                    MessageBox.Show("Password must be at least 8 digits long");
                }


            }
            else
            {
                MessageBox.Show("Password field must not empty");
            }
        }
    }
}
