using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace midterm
{
    public partial class update_sign : Form
    {
        string imageLocation;
        Database db;
        DataTable dt;
        int imageId;
        public update_sign()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (question.Text != "" && option1.Text != "" && option2.Text != "" && option3.Text != "" && option4.Text != "" && correctoption.Text != "")
            {
                db = new Database();
                SqlCommand cmd = db.conn.CreateCommand();
                cmd.CommandText = "update_sign";
                cmd.CommandType = CommandType.StoredProcedure;
                byte[] img = null;
                if (imageLocation != null) {
                    FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs); 
                    img = br.ReadBytes((int)fs.Length);
                    cmd.Parameters.AddWithValue("@pictures", img);
                }
                else
                {
                  
                    byte[] image = imageToByteArray(questionpic.Image);
                    cmd.Parameters.AddWithValue("@pictures", image);
                }
             
                cmd.Parameters.AddWithValue("@question_id", imageId);
                cmd.Parameters.AddWithValue("@option1", option1.Text);
                cmd.Parameters.AddWithValue("@option2", option2.Text);
                cmd.Parameters.AddWithValue("@option3", option3.Text);
                cmd.Parameters.AddWithValue("@option4", option4.Text);
                cmd.Parameters.AddWithValue("@correct", correctoption.Text);
                cmd.Parameters.AddWithValue("@question_text", question.Text);
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sign Detail Updated");
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
                if (img.Height <= 400 | img.Width <= 400)
                {
                    questionpic.Image = img;
                }
                else
                {
                    MessageBox.Show("Picture is too large");
                }

            }

          }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchimage.Text != "")
            {
                if (int.TryParse(searchimage.Text, out imageId)){
                    db = new Database();
                    SqlCommand cmd = db.conn.CreateCommand();
                    cmd.CommandText = "search_image_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",imageId);
                    if (cmd.ExecuteScalar()!=null)
                    {
                        db.cmd = cmd;
                        dt = db.ExQuery();
                        DataRow dr = dt.Rows[0];
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
                        option1.Text = dr["quetstion_option1"].ToString();
                        option2.Text = dr["quetstion_option2"].ToString();
                        option3.Text = dr["quetstion_option3"].ToString();
                        option4.Text = dr["quetstion_option4"].ToString();
                        correctoption.Text = dr["quetstion_correct"].ToString();
                        question.Text= dr["quetion_text"].ToString();
                    }
                    else
                    {
                        question.Text = "";
                        option1.Text = "";
                        option2.Text = "";
                        option3.Text = "";
                        option4.Text = "";
                        correctoption.Text = "";
                        questionpic.Image = null;
                        MessageBox.Show("No Record Found Against this id");
                    }

                }
                else
                {
                    MessageBox.Show("Enter Numerice Id");
                }

            }
            else
            {
                MessageBox.Show("Search field empty");
            }
        }

        public  byte[] imageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
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
