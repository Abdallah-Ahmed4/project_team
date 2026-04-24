using project_team.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_team.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Back_li_Click(object sender, EventArgs e)
        {
            Forms.LoginForm f = new Forms.LoginForm();
            f.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    user u = new user(txtName.Text, txtUserMail.Text, txtUserPassword.Text);
                    u.savetofile();
                    MessageBox.Show("Account created successfully!");

                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                }
                     catch
                 {
                MessageBox.Show("Enter all data!");
                  }


        }
    }
    }
