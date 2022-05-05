using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bookingWay
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            passengerMaster Ps = new passengerMaster();
            Ps.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cancellationMaster Cancel = new cancellationMaster();
            Cancel.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            cancellationMaster Cancel = new cancellationMaster();
            Cancel.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            reservationMaster Res = new reservationMaster();
            Res.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            reservationMaster Res = new reservationMaster();
            Res.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            passengerMaster Ps = new passengerMaster();
            Ps.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            trainMaster Train = new trainMaster();
            Train.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            trainMaster Train = new trainMaster();
            Train.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
