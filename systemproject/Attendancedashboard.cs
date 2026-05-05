using QRCoder;
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
using System.Xml.Linq;


namespace systemproject
{
    public partial class Attendancedashboard : Form
    {
        public Attendancedashboard()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

            string query = "INSERT INTO Attendance (StudentID, StudentName, Department, StudyYear) " +
                           "VALUES (@id, @name, @dept, @year)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@dept", txtDep.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", txtYear.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Attendance Registered Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtID.Clear();
                    txtName.Clear();
                    txtDep.Clear();
                    txtYear.Clear();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void Attendancedashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Studentdashboard home = new Studentdashboard();
            home.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Attendancedashboard attendance = new Attendancedashboard();
            attendance.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archivedashboard archive = new Archivedashboard();
            archive.Show();
            this.Hide();
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
