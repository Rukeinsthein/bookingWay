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
    public partial class trainMaster : Form

    {
        public trainMaster()
        {
            InitializeComponent();
            populate();
        }


        private void trainMastercs_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Faruk\OneDrive\Belgeler\BookingWayDb.mdf;Integrated Security=True;Connect Timeout=30"); 

       
        private void populate()
        {
            Con.Open();
            string query = "Select * from TRAINTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TrainDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string TrStatus = "";
        if(TrNameTb.Text == ""  || TrainCapasity.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (BusyRd.Checked == true) 
                {
                    TrStatus = "Busy";
                }else if(FreeRd.Checked)
                {
                    TrStatus = "Avaible";
                }
                    try {
                    Con.Open();
                    string Query = "insert into TRAINTBL values('" + TrNameTb.Text + "','" + TrainCapasity.Text + "','" + TrStatus + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Added Succesfully.");
                    Con.Close();
                    populate();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void reset()
        {
            TrNameTb.Text = "";
            TrainCapasity.Text = "";
            BusyRd.Checked = false;
            FreeRd.Checked = false;
            key = 0;

        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int key = 0;
        private void TrainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TrNameTb.Text = TrainDGV.SelectedRows[0].Cells[1].Value.ToString();
            TrainCapasity.Text = TrainDGV.SelectedRows[0].Cells[2].Value.ToString();
            if(TrNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(TrainDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Train To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from TRAINTBL where TrainId=" + key + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Deleted Succesfully.");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string TrStatus = "";
            if (TrNameTb.Text == "" || TrainCapasity.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (BusyRd.Checked == true)
                {
                    TrStatus = "Busy";
                }
                else if (FreeRd.Checked)
                {
                    TrStatus = "Avaible";
                }
                try
                {
                    Con.Open();
                    string Query = "update TRAINTBL set TrainName='"+TrNameTb.Text+"',TrainCap='"+TrainCapasity.Text+"',TrainStatus='"+TrStatus+"' where TrainId="+ key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Updated Succesfully.");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            mainForm Main = new mainForm();
            Main.Show();
            this.Hide();
        }
    }
}
