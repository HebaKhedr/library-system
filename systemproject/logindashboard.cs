using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace systemproject
{
    public partial class logindashboard : Form
    {
        public static string CurrentStudentName = "";
        public static string CurrentStudentID = "";
        public logindashboard()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Left=(this.ClientSize.Width-panel1.Width)/2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text== "Enter Your Name                        ")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter Your Name                        ";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Your Password                   ")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter Your Password                   ";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus(); 
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            string myConnString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text == "Enter Your Password")
            {
                MessageBox.Show("Please enter both Name and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(myConnString))
            {
                try
                {
                    conn.Open();
                    string tableName = radioButton2.Checked ? "Student" : "Librarian";
                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE Name=@user AND Password=@pass";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Welcome back!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (radioButton2.Checked)
                        {
                            CurrentStudentName = textBox1.Text;
                            CurrentStudentID = textBox2.Text;
                            Studentdashboard sd = new Studentdashboard();
                            sd.Show();
                        }
                        else
                        {
                            admindashboard ad = new admindashboard();
                            ad.Show();
                        }

                        this.Hide(); 
                    }
                    else
                    {
                       
                        MessageBox.Show("Invalid Name, Password or Role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = "Enter Your Name                        ";
            textBox2.Text = "Enter Your Password                   ";
            textBox1.Focus();
            textBox1_Enter(null, null);
            textBox1_Leave(null, null);
            textBox2_Enter(null, null);
            textBox2_Leave(null, null);
        }   
               
    }
}
