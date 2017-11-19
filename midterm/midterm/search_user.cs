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
    public partial class search_user : Form
    {
        Database db;
        DataTable dt;
        Boolean isApply;
        validation vs = new validation();
        int test_count;
        string test_status;
        int test_marks;
        string user_email;
        int u_id;

        public search_user()
        {
            InitializeComponent();
            isApply = false;
        }

        private void option2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchcnic.Text != "")
            {
                long cnic_num = vs.IsCnicValid(searchcnic.Text);
                if (cnic_num == 0)
                {
                    MessageBox.Show("Cnic number must be 14 digits long with no spaces");
                    searchcnic.Text = "";                }
                else
                {
                    db = new Database();
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "search_user_by_cnic";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cnic", cnic_num);
                    if (cmd.ExecuteScalar() != null)
                    {
                        db.cmd = cmd;
                        dt = db.ExQuery();
                        DataRow dr = dt.Rows[0];
                        email.Text = dr["user_email"].ToString();
                        pass.Text = dr["user_pass"].ToString();
                        user_id.Text = dr["user_id"].ToString();
                        u_id = Convert.ToInt16(dr["user_id"]);
                        try
                        {
                            isApply = (bool)dr["user_isAppliedForPractical"];

                        }
                        catch
                        {
                            isApply = false;
                        }

                        if (isApply)
                        {
                            isApplied.Checked = isApply;
                        }
                        else
                        {
                            isApplied.Checked = isApply;
                        }


                    }
                    else
                    {
                        email.Text = "";
                        pass.Text = "";
                        user_id.Text = "";
                        isApplied.Checked = false;
                        MessageBox.Show("No Record Found Against this Cnic");
                    }
                }
            }
            else
            {
                MessageBox.Show("Search field empty");
            }
        }

        private void isApplied_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isApply)
            {

                db = new Database();
                SqlCommand eligibilityCmd = db.conn.CreateCommand();
                eligibilityCmd.CommandText = "check_test_eligibility";
                eligibilityCmd.CommandType = CommandType.StoredProcedure;
                eligibilityCmd.Parameters.AddWithValue("@user_id", u_id);

                if (eligibilityCmd.ExecuteScalar() != null)
                {
                    db.cmd = eligibilityCmd;
                    dt = db.ExQuery();
                    DataRow testcountrow = dt.Rows[0];
                    try
                    {
                        test_count = Convert.ToInt16(testcountrow["test_count"]);
                        test_status = testcountrow["test_status"].ToString();
                        test_marks= Convert.ToInt16(testcountrow["test_count"]);
                        user_email = testcountrow["user_email"].ToString();
                    }
                    catch
                    {
                        test_count = 0;
                        test_marks = 0;
                        test_status = "";
                    }
                }
                    Mail mail = new Mail();
                //reciever_email ,your_email, pass ,subject, body
                bool email_status = mail.send(user_email, "sohail9099@gmail.com", "Engg@soft7", "Confirmation For Practical Test", "Test Marks\t " + test_marks + "Test Status"+ test_status + "Test Count" + test_count +"\t \n Your are Approved to appear for practical test");
                if (email_status)
                {
                    MessageBox.Show("Mail Sent");
                    email.Text = "";
                    pass.Text = "";
                    user_id.Text = "";
                    isApplied.Checked = false;
                }
                else
                {
                    MessageBox.Show("Mail Fail");
                }
                db.Close();
            }
            else
            {
                MessageBox.Show("User haven't Applied For Practical Test. CheckBox Empty");
            }
        }
    }
}
