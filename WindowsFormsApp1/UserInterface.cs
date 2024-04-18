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
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            var user = GetAllUsers();
            FillInput(user);
        }

        private User GetAllUsers()
        {
            var user = Account.Instance.User;
            return user;
        }

        private void FillInput(User user)
        {
            if (user != null)
            {
                name.Text = user.Name;
                username.Text = user.UserName;
                email.Text = user.Email;
                password.Text = user.Password;
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            var user = Account.Instance.User;
            Account.Instance.User = null;
            UserManager.Instance.RemoveById(user.ID);
            Login login = new Login();
            this.Hide();
            login.Show();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var user = Account.Instance.User;
            User newUser = new User()
            {
                ID =user.ID,
                Name = name.Text,
                Email = email.Text,
                UserName = username.Text,
                Password = password.Text

            };
            UserManager.Instance.Update(newUser);
            ClearInputs();

            FillInput(newUser);
        }

        private void ClearInputs()
        {
            name.Text = "";
            email.Text = "";
            username.Text = "";
            password.Text = "";
        }

        private void logOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
