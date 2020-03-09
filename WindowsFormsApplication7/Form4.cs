using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication7
{
    public partial class Form4 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;");
        public Form4()
        {
            InitializeComponent();
            tableData();
            txt_birth.Format = DateTimePickerFormat.Custom;
            txt_birth.CustomFormat = "yyyy-MM-dd";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txt_birth.Format = DateTimePickerFormat.Custom;
            txt_birth.CustomFormat = "yyyy-MM-dd";
                                    
        }
        public void tableData()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from orange.doctor";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            data_table.DataSource = dt;

            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open(); 
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from orange.doctor where doctor_id='" + txt_id.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Deleted Sucessfull");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open(); // connection open
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO orange.doctor(doctor_id,first_name,last_name,nic,gender,date_of_birth,speciality,telephone,status) VALUES('" + txt_id.Text + "','" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_gen.Text + "','" + txt_birth.Text + "','" + txt_special.Text + "','" +txt_tel.Text + "','" + txt_status.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Data Inserted");
        }

        private void data_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable table = new DataTable();
            int indexRow;

            indexRow = e.RowIndex;
            DataGridViewRow row = data_table.Rows[indexRow];

            txt_id.Text = row.Cells[0].Value.ToString();
            txt_first.Text = row.Cells[1].Value.ToString();
            txt_last.Text = row.Cells[2].Value.ToString();
            txt_nic.Text = row.Cells[3].Value.ToString();
            txt_gen.Text = row.Cells[4].Value.ToString();
            txt_birth.Text = row.Cells[5].Value.ToString();
            txt_special.Text = row.Cells[6].Value.ToString();
            txt_tel.Text = row.Cells[7].Value.ToString();
            txt_status.Text = row.Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open(); // connection open
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update orange.doctor set first_name = '"+txt_first.Text+"', last_name = '" + txt_last.Text + "', nic = '" + txt_nic.Text + "',gender = '" + txt_gen.Text + "',date_of_birth = '" + txt_birth.Text + "', speciality = '" + txt_special.Text + "', telephone = '" + txt_tel.Text + "', status = '" + txt_status.Text + "' where doctor_id= '" + txt_id.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Update Sucessfull");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_first.Clear();
            txt_last.Clear();
            txt_nic.Clear();
            txt_gen.SelectedIndex = -1;
            txt_birth.ResetText();
            txt_special.SelectedIndex = -1;
            txt_tel.Clear();
            txt_status.SelectedIndex = -1;

        }
    }
}
