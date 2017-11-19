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
    public partial class login : Form
    {
        validation v = new validation();
        ChangePassword cp = new ChangePassword();
        user_dashboard ud = new user_dashboard();
        Database db;
        DataTable dt;
        int test_count;
        int user_id;

        public login()
        {
            InitializeComponent();
            test_count = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnic_text = cnic_login.Text;
            string pass = pass_login.Text;
            long cnic_num = v.IsCnicValid(cnic_text);
            if (cnic_num == 0)
            {
                MessageBox.Show("Cnic number must be 14 digits long with no spaces");
                cnic_login.Text = "";
            }
            else
            {
                
                if (System.Text.ASCIIEncoding.ASCII.GetByteCount(pass)>= 8)
                {
                    db = new Database();
                    int status = 0;
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cnic", cnic_num);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cp.setCnic(cnic_num);
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
                        Boolean isLocked = true ;
                        db.Close();
                        db = new Database();
                        Users cs = new Users();
                        SqlCommand command= db.conn.CreateCommand();
                        command.CommandText = "is_Locked";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@cnic", cnic_num);
                        command.Parameters.AddWithValue("@pass", pass); 
                        if (command.ExecuteScalar() != null)
                        {
                           db.cmd = command;
                           dt = db.ExQuery();
                           DataRow dr = dt.Rows[0];
                            try
                            {
                                isLocked=(bool)dr["user_isLocked"];
                                user_id = Convert.ToInt16(dr["user_id"]);
                            }
                            catch
                            {
                                isLocked = true;
                            }


                           
                            if (isLocked)
                            { 
                                    MessageBox.Show("User login Success.You must Change Password");
                                    this.Hide();
                                    cp.Show();
                            
                            }
                            else 
                            {

                                    MessageBox.Show("User login Success.");
                                   
                                //check no of test already conducted
                                    SqlCommand eligibilityCmd = db.conn.CreateCommand();
                                     eligibilityCmd.CommandText = "check_test_eligibility";
                                     eligibilityCmd.CommandType = CommandType.StoredProcedure;
                                     eligibilityCmd.Parameters.AddWithValue("@user_id", user_id);

                                if (eligibilityCmd.ExecuteScalar() != null)
                                {
                                    db.cmd = eligibilityCmd;
                                    dt = db.ExQuery();
                                    DataRow testcountrow = dt.Rows[0];
                                    try
                                    {
                                        test_count = Convert.ToInt16(testcountrow["test_count"]);
                                    }
                                    catch
                                    {
                                        test_count = 0;
                                    }

                                    if (test_count < 3)
                                    {
                                        test_count++;
                                        this.Hide();
                                        ud.setTestCount(test_count);
                                        ud.setUserID(user_id);
                                        ud.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Not Eligible! You conducted 3 Test Already. Good Bye");
                                        cnic_login.Text = "";
                                        pass_login.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Eligible! You Test Count is NULL. Good Luck");
                                    this.Hide();
                                    ud.setTestCount(0);
                                    ud.setUserID(user_id);
                                    ud.Show();
                                }
                                
                            }
                          
                      }
                      else
                      {
                            MessageBox.Show("Invalid Username or password");
                            pass_login.Text = "";
                      }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or password");      
                        pass_login.Text = "";
                    }
                    db.Close();
                }
                else
                {
                    MessageBox.Show("Password is at least 8 character long");
                    pass_login.Text = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users ca = new Users();
            ca.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm ms = new mainForm();
            ms.Show();
        }
    }
}
