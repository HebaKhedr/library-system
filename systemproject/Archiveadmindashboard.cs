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

namespace systemproject
{
    public partial class Archiveadmindashboard : Form
    {
        private void LoadAllBooks()
        {
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "SELECT BookCode, Author, Title, Category FROM books";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Wrong: " + ex.Message);
                }
            }
        }

        public Archiveadmindashboard()
        {
            InitializeComponent();
        }

        private void Archiveadmindashboard_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archiveadmindashboard archive = new Archiveadmindashboard();
            archive.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admindashboard home = new admindashboard();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT Title, Author, BookCode FROM books " +
                           "WHERE Title LIKE @search OR Author LIKE @search";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search Error: " + ex.Message);
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search books by Title or Author.....")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Search books by Title or Author.....";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                logindashboard logindashboard = new logindashboard();

                logindashboard.Show();

                this.Close();
            }
        }
    }
}
