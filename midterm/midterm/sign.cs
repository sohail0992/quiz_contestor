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
using System.IO;

namespace midterm
{
    public partial class sign : Form
    {
        string imageLocation;
        Database db;
      
        public sign()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (.jpg)|.jpg|GIF Files (.gif)|.gif|All Files (.)|*.*";
            dlg.Title = "Select Student Picture";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                imageLocation = dlg.FileName.ToString();
                FileInfo file = new FileInfo(dlg.FileName);
                Bitmap img = new Bitmap(dlg.FileName);
                if (img.Height <= 400  | img.Width <= 400)
                {
                    questionpic.Image = img;
                }
                else
                {
                    MessageBox.Show("Picture is too large");
                }



            }
        }

        private void option4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (question.Text != "" && option1.Text != "" && option2.Text != "" && option3.Text != "" && option4.Text != "" && correctoption.Text != "")
            {
                db = new Database();
                byte[] img = null;
                FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                SqlCommand cmd = db.conn.CreateCommand();
                cmd.CommandText = "add_sign";  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@option1", option1.Text);
                cmd.Parameters.AddWithValue("@option2", option2.Text);
                cmd.Parameters.AddWithValue("@option3", option3.Text);
                cmd.Parameters.AddWithValue("@option4", option4.Text);
                cmd.Parameters.AddWithValue("@correct", correctoption.Text);
                cmd.Parameters.AddWithValue("@question_text", question.Text);
                cmd.Parameters.AddWithValue("@pictures", img);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sign Saved");
                question.Text = "";
                option1.Text = "";
                option2.Text = "";
                option3.Text = "";
                option4.Text = "";
                correctoption.Text = "";
                questionpic.Image = null;
                img = null;
                db.Close();
            }
            else
            {
                MessageBox.Show("One or more fields are empty");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
        }
    }
}
