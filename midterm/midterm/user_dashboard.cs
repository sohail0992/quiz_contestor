﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace midterm
{
    public partial class user_dashboard : Form
    {
        
        Database db;
        int count;
        int marks;
        String status;
        String previous_selected;
        string selected_option;
        string correct_option;
        private int test_count;
        private int user_id;
        int q_id;

        static int Second = 0;
        static int Minutes = 0;
        public user_dashboard()
        {
            InitializeComponent();
            marks = 0;
            count = 0;
            status = "";
            test_count = 0;  
            q_id = 0;
            startquizpanel.Visible = true;
            timer.Start();
         
        }

       


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
      

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selected_option = "";
            selected_option = option1.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            selected_option = "";
            selected_option = option2.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selected_option = "";
            selected_option = option4.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selected_option = "";
            selected_option = option3.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;

            string previous_correct = correct_option;
          
            if (count > 0 && count < 10)
            {
                DataTable dt = GetData();
                DataRow dr = dt.Rows[0];
                no.Text = count.ToString();
                question.Text = dr["quetion_text"].ToString();
                option1.Text= dr["quetstion_option1"].ToString();
                option2.Text= dr["quetstion_option2"].ToString();
                option3.Text= dr["quetstion_option3"].ToString();
                option4.Text = dr["quetstion_option4"].ToString();
                correct_option = dr["quetstion_correct"].ToString();
                byte[] img = (byte[])(dr["question_pic"]);
                if (img == null)
                {
                    questionpic.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    questionpic.Image = Image.FromStream(ms);
                }
                if (count != 1)
                {
                    marks = marksCount(previous_correct);
                }
               
            }
            else
            {
                quizEnd();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
      
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void startquizpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            startquizpanel.Visible = false;
     
        }

        private DataTable GetData()
        {
            db = new Database();
            DataTable dt = new DataTable();
            Random random = new Random();
            int max;

            try
            { 
                SqlCommand command = db.conn.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM dbo.questions";
                command.CommandType = CommandType.Text;
                try
                {
                    max = Convert.ToInt16(command.ExecuteScalar());
                }
                catch (NotFiniteNumberException)
                {
                    max = 1;
                }
                q_id=random.Next(1,max);
                SqlCommand cmd = db.conn.CreateCommand();
                cmd.CommandText = "get_question";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qid", q_id);
                if (command.ExecuteScalar() != null)
                {
                    db.cmd = cmd;
                    dt = db.ExQuery();
                   
                }
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);

            }
            finally
            {
                db.Close();
            }
            return dt;
        }

        private void questionlabel_Click(object sender, EventArgs e)
        {

        }

        public void setTestCount(int count)
        {
            test_count = count;
        }

        public int getTestCount()
        {
            return test_count;
        }


        public void setUserID(int id)
        {
            user_id = id;
        }

        public int getUserID()
        {
            return user_id;
        }

        public int marksCount(string pC)
        {
            if (selected_option.Equals(pC))
            {
                marks++;
            }
            return marks;
        }

        private void time_TextChanged(object sender, EventArgs e)
        {
            
        }

      
        public void quizEnd()
        {
            MessageBox.Show("QUIZ End");
            db = new Database();
            SqlCommand resultCmd = db.conn.CreateCommand();
            resultCmd.CommandText = "test_result";
            resultCmd.CommandType = CommandType.StoredProcedure;
            resultCmd.Parameters.AddWithValue("@user_id", getUserID());
            resultCmd.Parameters.AddWithValue("@test_count", getTestCount());
            resultCmd.Parameters.AddWithValue("@test_marks", marks);
            //if marks is 6 it will show pass
            int result =  marks;
            if (result >= 6)
            {
                MessageBox.Show("Congrates You Passed");
                this.Hide();
                result rs = new result(result);
                rs.setMarks(marks);
                rs.setUserID(user_id);
                status = "passed";
                rs.setQuizStatus(status);
                resultCmd.Parameters.AddWithValue("@test_status", status);
                rs.Show();
            }
            else
            {
                MessageBox.Show("You Failed Try Again");
                status = "failed";
                resultCmd.Parameters.AddWithValue("@test_status", status);
                this.Hide();
                login user = new login();
                user.Show();
            }
            resultCmd.ExecuteNonQuery();
        }

        private void question_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            Second++;
            if (Second == 60)
            {
                Minutes++;
                Second = 0;
            }
            label10.Text = Minutes + ":" + Second;
            if (Minutes == 5)
            {
                timer.Stop();
                MessageBox.Show("Time Up Quiz Will Be Ended ");
                quizEnd();
               
            }
        }

        private void options_Enter(object sender, EventArgs e)
        {
          
        }
    }
}
