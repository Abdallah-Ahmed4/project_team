using project_team.Models;
using System;
using System.Windows.Forms;
namespace project_team.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter Email and Password");
                    return;
                }
                user u = user.load(txtEmail.Text, txtPassword.Text);

                if (u != null)

                {
                    MessageBox.Show("Welcome " + u.Name);

                    SubjectForm pf = new SubjectForm();
                    pf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password");
                }
            
           } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Forms.RegisterForm Form = new RegisterForm();
            Form.Show();
            this.Hide();
        }
    }
}
