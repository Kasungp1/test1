using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            username = Convert.ToString(txt_user.Text);
            password = Convert.ToString(txt_pass.Text);

            if (username == "wasala" && password == "123")
            {
                Form2 f1 = new Form2();
                this.Hide();
                f1.Show();

            }
            else
            {
                MessageBox.Show("Login Fail");
            }
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_user.Clear();
            txt_pass.Clear();
        }
    }
}
