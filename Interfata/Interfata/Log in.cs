﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interfata
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vicev\OneDrive\Documents\Dayta.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sql = new SqlDataAdapter("Select Count(*) From Autentificare Where Utilizator='" + usernameLogInTextBox.Text + "' and Parola='" + parolaLogInTextBox.Text + "'", conn);
            DataTable dta = new DataTable();
            sql.Fill(dta);
            Console.WriteLine(dta);

            if (dta.Rows[0][0].ToString() == "1")
            {
                Hide();
                Magazine form = new Magazine();
                form.Show();
            }
            else
            {
                MessageBox.Show("Utilizator sau parola date invalide");
            }
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (rememberMeCheckBox.Checked)
            {
                Properties.Settings.Default.UserName = usernameLogInTextBox.Text;
                Properties.Settings.Default.Password = parolaLogInTextBox.Text;
                Properties.Settings.Default.Save();
            }
            if (!rememberMeCheckBox.Checked)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
            }
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vicev\OneDrive\Documents\Dayta.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sql = new SqlDataAdapter("Select Count(*) From Autentificare Where Utilizator='" + usernameLogInTextBox.Text + "' and Parola='" + parolaLogInTextBox.Text + "'", conn);
            DataTable dta = new DataTable();
            sql.Fill(dta);
            if (dta.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Magazine form = new Magazine();
                form.Show();
            }
            else
            {
                MessageBox.Show("Utilizator sau parola date invalide");
            }
        }

        private void usernameLogInTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void parolaLogInTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

                usernameLogInTextBox.Text = Properties.Settings.Default.UserName;
                parolaLogInTextBox.Text = Properties.Settings.Default.Password;

        }
    }
}