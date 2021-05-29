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
            parolaLogInTextBox.PasswordChar = '•';
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vicev\OneDrive\Documents\GitHub\Proiect-IP-Glovo\data.mdf;Integrated Security=True;Connect Timeout=30;");
                SqlDataAdapter sql = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                string login = "SELECT * FROM Autentificare WHERE USERNAME='" + usernameLogInTextBox.Text + "' and PAROLA='" + parolaLogInTextBox.Text + "'";
                cmd = new SqlCommand(login, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    new Magazine().Show();
                    Hide();
                }     
                else
                {
                    MessageBox.Show("Utilizator sau parola date invalide", "Autentificare esuata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernameLogInTextBox.Text = "";
                    parolaLogInTextBox.Text = "";
                    usernameLogInTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vicev\OneDrive\Documents\GitHub\Proiect-IP-Glovo\data.mdf;Integrated Security=True;Connect Timeout=30;");
                SqlDataAdapter sql = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                string login = "SELECT * FROM Autentificare WHERE USERNAME='" + usernameLogInTextBox.Text + "' and PAROLA='" + parolaLogInTextBox.Text + "'";
                cmd = new SqlCommand(login, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    new Magazine().Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Utilizator sau parola date invalide", "Autentificare esuata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernameLogInTextBox.Text = "";
                    parolaLogInTextBox.Text = "";
                    usernameLogInTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main form = new Main();
            form.Show();
        }

        private void parolaUitataButton_Click(object sender, EventArgs e)
        {
            Hide();
            Forgotten_password form = new Forgotten_password();
            form.Show();
        }

        private void checkBox_afiseaza_parola_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_afiseaza_parola.Checked)
            {
                parolaLogInTextBox.PasswordChar = '\0';

            }
            else
            {
                parolaLogInTextBox.PasswordChar = '•';

            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            usernameLogInTextBox.Text = "";
            parolaLogInTextBox.Text = "";
            usernameLogInTextBox.Focus();
        }
    }
}
