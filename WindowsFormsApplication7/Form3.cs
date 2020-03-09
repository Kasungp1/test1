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


    public partial class Form3 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;");
        public Form3()
        {
            InitializeComponent();
            tableData();
            txt_dob.Format = DateTimePickerFormat.Custom;
            txt_dob.CustomFormat = "yyyy-MM-dd";

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txt_dob.Format = DateTimePickerFormat.Custom;
            txt_dob.CustomFormat = "yyyy-MM-dd";

        }
        public void tableData()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from orange.patient";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            data_table.DataSource = dt;

            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open(); // connection open
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO orange.patient(patient_id,first_name,last_name,nic,date_of_birth,gender,address,mobile,telephone) VALUES('" + txt_id.Text + "','" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_dob.Text + "','" + txt_gen.Text + "','" + txt_address.Text + "','" + txt_mob.Text + "','" + txt_tel.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Data Inserted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open(); // connection open
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from orange.patient where patient_id='" + txt_id.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Deleted Sucessfull");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open(); // connection open
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update orange.patient set fisrt_name='" + txt_first.Text + "', last_name = '" + txt_last.Text + "', nic = '" + txt_nic.Text + "',date_of_birth = '" + txt_dob.Text + "', gender = '" + txt_gen.Text + "', address = '" + txt_address.Text + "', mobile = '" + txt_mob.Text + "', telephone = '" + txt_tel.Text + "' where patient_id='" + txt_id.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            tableData();
            MessageBox.Show("Update Sucessfull");
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
            txt_dob.Text = row.Cells[4].Value.ToString();
            txt_gen.Text = row.Cells[5].Value.ToString();
            txt_address.Text = row.Cells[6].Value.ToString();
            txt_mob.Text = row.Cells[7].Value.ToString();
            txt_tel.Text = row.Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_first.Clear();
            txt_last.Clear();
            txt_nic.Clear();
            txt_dob.ResetText();
            txt_gen.SelectedIndex = -1;
            txt_address.Clear();
            txt_mob.Clear();
            txt_tel.Clear();
        }
    }
}
