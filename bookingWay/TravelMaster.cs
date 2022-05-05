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
    public partial class TravelMaster : Form
    {
        public TravelMaster()
        {
            InitializeComponent();
            populate();
            FillTcode();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Faruk\OneDrive\Belgeler\BookingWayDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void populate()
        {
            Con.Open();
            string query = "Select * from TRAVELTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TravelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void FillTcode()
        {
            string TrStatus = "Busy";
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TrainId from TRAINTBL where TrainStatus='"+TrStatus+"'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TrainId", typeof(int));
            dt.Load(rdr);
            Tcode.ValueMember = "TrainId";
            Tcode.DataSource = dt;
            Con.Close();
        }
        private void TravelMaster_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChangeStatus()
        {
            String TrStatus = "Busy";
            try
            {
                Con.Open();
                string Query = "update TRAINTBL set TrainStatus='" + TrStatus + "' where TrainId=" + Tcode.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Train Updated Succesfully.");
                Con.Close();
                populate();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
            //for add button
        {
            if (TravDate.Text == "" || Tcode.SelectedIndex == -1 || SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into TRAVELTBL values('" + TravDate.Value + "','" + Tcode.SelectedValue.ToString() + "','" +SrcCb.SelectedItem.ToString()+ "','" +DestCb.SelectedItem.ToString()+ "'," +TCostTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Added Succesfully.");
                    Con.Close();
                    populate();
                    ChangeStatus();
                    reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void reset()
        {
            SrcCb.SelectedIndex = -1;
            DestCb.SelectedIndex = -1;
            //Tcode.SelectedIndex = -1;
            TCostTb.Text = "";
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //for edit button
            if (SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1 || TCostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update TRAVELTBL set TravDate='" +TravDate.Value+ "',Train=" + Tcode.SelectedValue.ToString() + ",Src='" + SrcCb.SelectedItem.ToString() + "',Dest='" + DestCb.SelectedItem.ToString() + "',Cost=" + TCostTb.Text + " where TravCode=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Updated Succesfully.");
                    Con.Close();
                    populate();
                    reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void TravelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TravDate.Text = TravelDGV.SelectedRows[0].Cells[1].Value.ToString();
            Tcode.SelectedValue = TravelDGV.SelectedRows[0].Cells[2].Value.ToString();
            SrcCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[3].Value.ToString();
            DestCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[4].Value.ToString();
            TCostTb.Text = TravelDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (Tcode.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TravelDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            mainForm Main = new mainForm();
            Main.Show();
            this.Hide();
        }
    }
}
