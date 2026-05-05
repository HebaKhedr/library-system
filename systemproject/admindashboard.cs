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
using WinFormsApp1;

namespace systemproject
{
    public partial class admindashboard : Form
    {
        private void LoadAllAttendance()
        {
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT StudentName, AttendanceDate, AttendanceTime FROM Attendance ORDER BY AttendanceDate DESC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void LoadSomeBooks()
        {
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

           
            string query = "SELECT TOP 5 Title, Author, Category FROM books ORDER BY BookCode DESC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;

                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading books: " + ex.Message);
                }
            }
        }
        private void LoadLiveStatus()
        {
            
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

            string query = "SELECT TOP 3 StudentName, AttendanceTime FROM Attendance ORDER BY AttendanceDate DESC, AttendanceTime DESC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    dataGridView2.Columns[0].HeaderText = "Student";
                    dataGridView2.Columns[1].HeaderText = "Time";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Live Status Error: " + ex.Message);
                }
            }
        }

        public admindashboard()
        {
            InitializeComponent();
        }

        private void admindashboard_Load(object sender, EventArgs e)
        {
            LoadAllAttendance();
            LoadSomeBooks();
            LoadLiveStatus();
            panel2.BackColor = Color.FromArgb(50, 255, 255, 255);
            panel3.BackColor = Color.FromArgb(50, 255, 255, 255);
            panel4.BackColor = Color.FromArgb(50, 255, 255, 255);
            panel5.BackColor = Color.FromArgb(50, 255, 255, 255);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admindashboard home = new admindashboard();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archiveadmindashboard archive = new Archiveadmindashboard();
            archive.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please enter Student Name , ID , year and department !");
                return;
            }

            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

            string query = "INSERT INTO Attendance (StudentName, AttendanceDate, AttendanceTime, StudentID , Department, StudyYear) VALUES (@name, @date, @time, @id, @dept, @year)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@year", textBox6.Text);
                    cmd.Parameters.AddWithValue("@dept", textBox7.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd")); 
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));   

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Attendance Registered Successfully!");

                    LoadAllAttendance(); 
                    LoadLiveStatus();    

                    
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox6.Clear();
                    textBox7.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ScrollControlIntoView(textBox3);

            textBox3.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Please add book details!");
                return;
            }

            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

            
            string query = "INSERT INTO books (Title, Author, Category, BookCode) VALUES (@title, @author, @cat, @code)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.AddWithValue("@title", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@cat", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@code", textBox8.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Add book successfully!");

                    
                    LoadSomeBooks();

                  
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox8.Clear();

                    textBox3.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("there is something wrong: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                logindashboard logindashboard= new logindashboard();

                logindashboard.Show();

                this.Close();
            }
        }
    }
}
