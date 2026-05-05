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
    public partial class Studentdashboard : Form
    {
        private void LoadMyAttendance()
        {
            string connString = @"Data Source=DESKTOP-03DEBVP\SQLEXPRESS;Initial Catalog=libraryDB;Integrated Security=True;TrustServerCertificate=True";

            string query = "SELECT  AttendanceID ,StudentName ,Department ,StudyYear ,AttendanceDate, AttendanceTime FROM Attendance WHERE StudentName = @sname";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@sname", logindashboard.CurrentStudentName);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public Studentdashboard()
        {
            InitializeComponent();
        }

        private void Studentdashboard_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(50, 255, 255, 255);
            panel3.BackColor = Color.FromArgb(50, 255, 255, 255);
            LoadMyAttendance();
            label3.Text = "Welcome Dear  " + logindashboard.CurrentStudentName;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Attendancedashboard attendancedashboard = new Attendancedashboard();
            attendancedashboard.Show();
            this.Hide();

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

        private void button7_Click(object sender, EventArgs e)
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
