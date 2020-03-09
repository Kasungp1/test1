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
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;");
        public Form5()
        {
            InitializeComponent();
            loadDataGrid();
            txt_apo_date.Format = DateTimePickerFormat.Custom;
            txt_apo_date.CustomFormat = "yyyy-MM-dd";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txt_apo_date.Format = DateTimePickerFormat.Custom;
            txt_apo_date.CustomFormat = "yyyy-MM-dd";
        }
       
        private void loadDataGrid()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from orange.appointment";
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
            cmd.CommandText = "INSERT INTO orange.appointment(ref_no,first_name,last_name,nic,appo_no,doc_name,speciality,patient_id,appo_date) VALUES('" + txt_ref.Text + "','" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_apo.Text + "','" + txt_doc.Text + "','" + txt_special.Text + "','" + txt_id.Text + "','" + txt_apo_date.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            loadDataGrid();
            MessageBox.Show("Data Inserted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from orange.appointment where appo_no='" + txt_apo.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            loadDataGrid();
            MessageBox.Show("Deleted Sucessfull");
        }

        private void data_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable table = new DataTable();
            int indexRow;

            indexRow = e.RowIndex;
            DataGridViewRow row = data_table.Rows[indexRow];

            txt_ref.Text = row.Cells[0].Value.ToString();
            txt_first.Text = row.Cells[1].Value.ToString();
            txt_last.Text = row.Cells[2].Value.ToString();
            txt_nic.Text = row.Cells[3].Value.ToString();
            txt_apo.Text = row.Cells[4].Value.ToString();
            txt_doc.Text = row.Cells[5].Value.ToString();
            txt_special.Text = row.Cells[6].Value.ToString();
            txt_id.Text = row.Cells[7].Value.ToString();
            txt_apo_date.Text = row.Cells[8].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open(); 
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update orange.appointment set ref_no = '" + txt_ref.Text + "', first_name = '" + txt_first.Text + "', last_name = '" + txt_last.Text + "',nic = '" +txt_nic.Text + "',doc_name = '" + txt_doc.Text + "', speciality = '" + txt_special.Text + "', patient_id = '" + txt_id.Text + "', appo_date = '" +txt_apo_date.Text + "' where appo_no= '" + txt_apo.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            loadDataGrid();
            MessageBox.Show("Update Sucessfull");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_ref.Clear();
            txt_first.Clear();
            txt_last.Clear();
            txt_nic.Clear();
            txt_apo.Clear();
            txt_doc.Clear();
            txt_special.SelectedIndex = -1;
            txt_id.Clear();
            txt_apo_date.ResetText();
        }
    }
}
