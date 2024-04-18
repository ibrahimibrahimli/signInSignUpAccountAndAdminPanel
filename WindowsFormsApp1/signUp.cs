using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Control.Concret;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            GetUsers();
        }

        public List<User> GetUsers()
        {
            var users = UserManager.Instance.GetAll();
            return users;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit() ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var users = GetUsers();
            try
            {
                if (name.Text.Length < 3)
                    throw new Exception("Name cannot be less than 3 letters");

                if (email.Text.Length < 6 && !email.Text.Contains("@") && !email.Text.Contains("."))
                    throw new Exception("Email not valid");

                foreach (var u in users)
                {
                    if (u.UserName == userName.Text)
                    {
                        throw new Exception("This username already used, Please enter other Username");
                    }
                    if(u.Email == email.Text)
                    {
                        throw new Exception("This email already used");
                    }
                }
                if (password.Text.Length < 8)
                    throw new Exception("Password must not be less than 8 digits");
                if (!isAgreePrivacy.Checked)
                    throw new Exception("Accept Privacy and Policy");

                User user = new User()
                {
                    Name = name.Text,
                    UserName = userName.Text,
                    Email = email.Text,
                    Password = password.Text
                };

                UserManager.Instance.Add(user);
                name.Text = "";
                email.Text = "";
                userName.Text = "";
                password.Text = "";
                isAgreePrivacy.Checked = false;

                MessageBox.Show("Succes registration");

                Login login = new Login();
                this.Hide();
                login.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();

        }
    }
}
