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
    public partial class Users : Form
    {
        validation vs = new validation();
        Database db;
        public Users()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cnic_text = cnic_create.Text;
            string email = email_text.Text;
            long cnic_num = vs.IsCnicValid(cnic_text);
            if (cnic_num == 0)
            {
                MessageBox.Show("Cnic number must be 14 digits long with no spaces");
                cnic_create.Text = null;
            }
            else
            {
                if (vs.IsValidEmail(email))
                {
                    db = new Database();
                    string password = vs.generte_pass();
                    int locked = 1;
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "create_account";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cnic", cnic_num);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@islocked", locked);
                    Mail mail = new Mail();
                    //reciever_email ,your_email, pass ,subject, body
                    bool email_status=mail.send(email, "sohail9099@gmail.com", "Engg@soft7", "Password For licensing authority account", password+"\n"+"This password will be use for future login. Keep it Secure");
                    if (email_status)
                    {
                        cmd.ExecuteNonQuery(); 
                        MessageBox.Show("User Register Successfuly");
                        cnic_create.Text = null;
                        email_text.Text = null;
                        this.Hide();
                        login user_login = new login();
                        user_login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sending Pass through email failed! User not register");
                    }
                    db.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter valid email address");
                    email_text = null;
                }
            } 
        }
    }
}
