﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using School.Models;
using System.Timers;

namespace School.Pages
{
    public partial class Dashboard : Form
    {
        Loading loadingm = new Loading();
       
        public int MessageSecond { get; set; } = 0;
        System.Timers.Timer MessageTimer = new System.Timers.Timer();
        public static Form ThisForm { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            ThisForm = this;
            this.pctMain.Image = School.Properties.Resources.dashboard;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.ThisForm.Show();
        }

        private void QuationClick(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                //Login lgn = new Login();
                //lgn.Hide();
                //Dashboard dash = new Dashboard();
                //dash.Hide();
                new StuQuation().Show();
            }
            catch (Exception)
            {


                //this.Hide();
                //Login lgn = new Login();
                //lgn.Hide();
                //Dashboard dash = new Dashboard();
                //dash.Hide();
                //new Dashboard().Show();
                //ShowResponse1("Bilet əlavə olunmayıb", Color.Red);
                this.Show();
                MessageBox.Show("Sual əlavə olunmayıb", "Sualinfo");



            }
            //this.Hide();
            ////Login lgn = new Login();
            ////lgn.Hide();
            ////Dashboard dash = new Dashboard();
            ////dash.Hide();
            //new StuQuation().ShowDialog();


        }


        private void CloseMessage1(object source, ElapsedEventArgs e)
        {
            MessageSecond++;
            if (MessageSecond > 2)
            {
                this.MessageTimer.Stop();
                this.MessageTimer.Dispose();
                loadingm.Close();
                this.Close();
            }
        }
        private void ShowResponse1(string message, Color back_color)
        {

            loadingm.lblMessage.Text = message;
            loadingm.lblMessage.Left = ((loadingm.Width - loadingm.lblMessage.Width) / 2);
            loadingm.lblMessage.ForeColor = Color.White;
            loadingm.BackColor = back_color;
            loadingm.Show(this);
            MessageTimer.Elapsed += new ElapsedEventHandler(CloseMessage1);
            MessageTimer.Interval = 1000;
            MessageTimer.Enabled = true;
        }
        private void TicketClick(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                //Login lgn = new Login();
                //lgn.Hide();
                //Dashboard dash = new Dashboard();
                //dash.Hide();
                new StuTicket().Show();
            }
            catch (Exception)
            {


                //this.Hide();
                //Login lgn = new Login();
                //lgn.Hide();
                //Dashboard dash = new Dashboard();
                //dash.Hide();
                //new Dashboard().Show();
                //ShowResponse1("Bilet əlavə olunmayıb", Color.Red);
                this.Show();
                MessageBox.Show("Bilet əlavə olunmayıb","Biletinfo");
                


            }
          
            //if ()
            //{

            //}

        }

        private void UpdateProfile(object sender, EventArgs e)
        {
            this.txtEmail.Text = Login.LoginedUser.Email;
            this.txtName.Text = Login.LoginedUser.Name;
            this.txtSurname.Text = Login.LoginedUser.Surname;
            if (Login.LoginedUser.Gender)
            {
                this.ckbMale.Checked = true;
            }
            else
            {
                this.ckbFemale.Checked = true;
            }
            this.grpStuProfile.Visible = !this.grpStuProfile.Visible;
            this.pctMain.Visible = !this.grpStuProfile.Visible;
            this.pnlAbout.Visible = false;
        }



        private void FormResize(object sender, EventArgs e)
        {
            this.pctMain.Width = this.Width - 200;
            this.pctMain.Height = this.Height - 100;

            this.grpStuProfile.Left = ((this.Width - this.grpStuProfile.Width) / 2 - 8);
            //this.grpInfo.Left = ((this.Width - this.grpInfo.Width) / 2 - 8);
            this.pctMain.Left = ((this.Width - this.pctMain.Width) / 2 - 8);
            this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
            this.Top = (this.Height - this.pctMain.Height) / 2;
            //this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.pctMain.Width = this.Width - 200;
            this.pctMain.Height = this.Height - 100;
            //this.grpInfo.Width = this.Width - 200;
            //this.grpInfo.Height = this.Height - 200;

            //this.grpInfo.Left = ((this.Width - this.grpInfo.Width) / 2 - 8);
            this.pctMain.Left = ((this.Width - this.pctMain.Width) / 2 - 8);
            // deyis bas
            //Loading ldng = new Loading();
            //ldng.Hide();

            //this.grpStuProfile.Left = ((this.Width - this.grpStuProfile.Width) / 2 - 8);
            //this.grpInfo.Width =this.grpInfo.Width+( (this.Width - this.grpInfo.Width) / 2);
            //this.pctMain.Width = this.pctMain.Width + ((this.Width - this.pctMain.Width) / 2);
            this.pnlAbout.Left = (this.Width - this.pnlAbout.Width) / 2;
            //this.label01.Left = (this.Width - this.label01.Width) / 2;
            //this.label6.Left = (this.Width - this.label6.Width) / 2;

            //this.grpInfo.Height =this.grpInfo.Height+ ((this.Height - this.grpInfo.Height) / 2);
            this.pnlAbout.Height =this.pnlAbout.Height+( (this.Height - this.pnlAbout.Height) / 2);
            // this.grpInfo.Left = ((this.Width - this.grpInfo.Width) / 2 - 8);
            this.pctMain.Top = 50;
            this.pnlAbout.Top = 50;
            this.Top = (this.Height - this.pctMain.Height) / 2;
            
           //this.pctMain.Height=this.Height-
          //this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
            //this.pnlAbout.Top = 100;
            //deyis son
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.grpStuProfile.Visible = false;
            this.pctMain.Visible = false;
            this.pnlAbout.Visible = true;
        }
          
        private void Dashboard_FontChanged(object sender, EventArgs e)
        {
            //this.grpInfo.Width = this.grpInfo.Width + ((this.Width - this.grpInfo.Width) / 2);
            this.pctMain.Width = this.pctMain.Width + ((this.Width - this.pctMain.Width) / 2);
        }
    }
}
