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
using WindowsFormsApp1.DB;
using WindowsFormsApp1.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }





        private void Main_Load(object sender, EventArgs e)
        {
            var users = GetUsers();
            dataBox.DataSource = users;
        }

        List<User> GetUsers()
        {
            var users = UserManager.Instance.GetAll();
            return users;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var users = GetUsers();
            try
            {
                if (name.Text.Length < 3)
                    throw new Exception("Name cannot be less than 3 letters");

                if (!email.Text.Contains("@") && !email.Text.Contains("."))
                    throw new Exception("Email not valid");

                foreach (var u in users)
                {
                    if (u.UserName == username.Text)
                    {
                        throw new Exception("This username already used, Please enter other Username");
                    }
                    if (u.Email == email.Text)
                    {
                        throw new Exception("This email already used");
                    }
                }
                if (password.Text.Length < 8)
                    throw new Exception("Password must not be less than 8 digits");

                User user = new User()
                {
                    Name = name.Text,
                    UserName = username.Text,
                    Email = email.Text,
                    Password = password.Text
                };

                UserManager.Instance.Add(user);

                ClearInputs();


                MessageBox.Show("Succes Added User");
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            User user = UserManager.Instance.GetByUsername(searchBox.Text);

            if (user != null)
            {
                idText.Text = user.ID;
                name.Text = user.Name;
                username.Text = user.UserName;
                email.Text = user.Email;
                password.Text = user.Password;
                
            }
            else
            {
                MessageBox.Show("Has not this user");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UserManager.Instance.RemoveById(idText.Text);
            FillDataGridView();
            ClearInputs();
        }

        private void ClearInputs()
        {
            idText.Text = "";
            name.Text = "";
            email.Text = "";
            username.Text = "";
            password.Text = "";
        }

        private void FillDataGridView()
        {
            dataBox.DataSource = null;
            var newUserList = GetUsers();
            dataBox.DataSource = newUserList;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User newUser = new User()
            {
                ID = idText.Text,
                Name = name.Text,
                Email = email.Text,
                UserName = username.Text,
                Password = password.Text
            };

            UserManager.Instance.Update(newUser);

            ClearInputs();
            FillDataGridView();

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            UserManager.Instance.RemoveAll();
            ClearInputs();
            FillDataGridView();
        }

        private void back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
