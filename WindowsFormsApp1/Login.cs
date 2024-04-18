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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllUser();
        }

        public List<User> GetAllUser()
        {
            var users = UserManager.Instance.GetAll();
            return users;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool foundUser = false;
           var users = GetAllUser();

            if(userName.Text == "admin" && password.Text == "admin")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                foreach (var u in users)
                {
                    if (u.UserName == userName.Text && u.Password == password.Text)
                    {
                        MessageBox.Show("Succes Login");
                        foundUser = true;
                        Account.Instance.User = u;
                        UserInterface uInterface = new UserInterface();
                        this.Hide();
                        uInterface.Show();
                    }

                }
                if (!foundUser)
                {
                    MessageBox.Show("Username or Password is not valid");
                    userName.Text = "";
                    password.Text = "";
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }
    }
}
