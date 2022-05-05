using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bookingWay
{
    public partial class passengerMaster : Form
    {
        public passengerMaster()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Faruk\OneDrive\Belgeler\BookingWayDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void passengerMaster_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            Con.Open();
            string query = "Select * from PASSENGERTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            PassengerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string Gender = "";
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAdressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (maleRd.Checked == true)
                {
                    Gender = "Male";
                }
                else if (femaleRd.Checked)
                {
                    Gender = "Female";
                }
                try
                {
                    Con.Open();
                    string Query = "insert into PASSENGERTBL values('" + PNameTb.Text + "','" + PAdressTb.Text + "','" + Gender + "','" + NatCb.SelectedItem.ToString() + "','" + PphoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Added Succesfully.");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Reset()
        {
            PNameTb.Text = "";
            PAdressTb.Text = "";
            PphoneTb.Text = "";
            maleRd.Checked = false;
            femaleRd.Checked = false;
            NatCb.SelectedIndex = -1;
            key = 0;
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Passenger To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from PASSENGERTBL where PId=" + key + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Succesfully.");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        int key = 0;
        private void PassengerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PassengerDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAdressTb.Text = PassengerDGV.SelectedRows[0].Cells[2].Value.ToString();
            NatCb.SelectedItem = PassengerDGV.SelectedRows[0].Cells[4].Value.ToString();
            PphoneTb.Text = PassengerDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PassengerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string Gender = "";
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAdressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (maleRd.Checked == true)
                {
                    Gender = "Male";
                }
                else if (femaleRd.Checked)
                {
                    Gender = "Female";
                }
                try
                {
                    Con.Open();
                    string Query = "update PASSENGERTBL set Pname='" + PNameTb.Text + "',PAdd='" + PAdressTb.Text + "',PGender='" + Gender + "',PNat='" + NatCb.SelectedItem.ToString() + "',Pphone='" + PphoneTb.Text + "' where PId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Updated Succesfully.");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            mainForm Main = new mainForm();
            Main.Show();
            this.Hide();
        }
    }
}
