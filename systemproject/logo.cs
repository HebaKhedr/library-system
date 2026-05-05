using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systemproject
{
    public partial class logo : Form
    {
        public logo()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            logindashboard logindashboard = new logindashboard();
            logindashboard.Show();
            this.Hide();
        }

        private void logo_Load(object sender, EventArgs e)
        {

        }
    }
}
