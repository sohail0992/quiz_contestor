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
    public partial class result : Form
    {
        Database db;
        private int marks;
        private int user_id;
        private String quizStatus;
  

        public result(int marks)
        {
            InitializeComponent();
            this.marks = marks;
                correct.Text = marks.ToString();
                status.Text = "Passed";
                wrong.Text = (10 - marks).ToString();
                markslabel.Text = marks.ToString();
           
            
        }

        private void result_Load(object sender, EventArgs e)
        {

        }

        
        private void correct_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db = new Database();
            Boolean is_Applied = true;
            SqlCommand isApply = db.conn.CreateCommand();
            isApply.CommandText = "is_Applied_for_practical";
            isApply.CommandType = CommandType.StoredProcedure;
            isApply.Parameters.AddWithValue("@user_id", getUserID());
            isApply.Parameters.AddWithValue("@isApplied", is_Applied);
            isApply.ExecuteNonQuery();
            db.Close();
            MessageBox.Show("You Successfully Applied for the Practical test. You will be Notified through Email");
        }



        public void setUserID(int id)
        {
            user_id = id;
        }

        public int getUserID()
        {
            return user_id;
        }
        public void setQuizStatus(String s)
        {
            quizStatus = s;
        }

        public String getQuizStatus()
        {
            return quizStatus;
        }

        public void setMarks(int m)
        {
            marks = m;
        }

        public int getMarks()
        {
            return marks;
        }

    }


}
