using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Upload_page;
using System.IO;
using ExcelDataReader;
using Twilio.Rest.Api.V2010.Account.Usage.Record;


namespace Admin_Login
{
    public partial class Form1: Form
    {
        
        string username = "Admin";
        string password = "pass123";
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUser.Text==username && txtPass.Text==password)
            {
                this.Hide();
                Upload_Page Uploadform = new Upload_Page();
                Uploadform.ShowDialog();
                this.Show();
            }
            else
                {
                    MessageBox.Show("Error in Login", "Login Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //String connectionString = "Data Source=DESKTOP-U310I1D;Initial Catalog=Loginapp;Integrated Security=True;Pooling=False;Encrypt=False;";
                //using(SqlConnection con = new SqlConnection(connectionString))
                //{
                //    con.Open();
                //    string query = "SELECT COUNT(*) FROM AdminLogin WHERE Username = @Username and Password = @Password";
                //    SqlCommand cmd = new SqlCommand(query, con);
                //    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                //    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                //    int count = (int)cmd.ExecuteScalar();
                //    con.Close();
                //    if (count > 0)
                //    {
                //        this.Hide();
                //        Upload_Page Uploadform = new Upload_Page();
                //        Uploadform.ShowDialog();
                //        this.Show();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Error in Login", "Login Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // If the checkbox is checked, show the password
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                // If the checkbox is unchecked, hide the password
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}