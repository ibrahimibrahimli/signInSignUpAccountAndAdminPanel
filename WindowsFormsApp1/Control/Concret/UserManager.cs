using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Control.Abstract;
using WindowsFormsApp1.DB;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Control.Concret
{
    public class UserManager : DataBase, IUserOperation
    {
        private static UserManager _instance;

        public static UserManager Instance
        {
            get
            {
               if(_instance == null)
                    _instance = new UserManager();

               return _instance;
            }
        }
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            var foundedUser = users.Find(u => u.UserName == username);
            return foundedUser;
        }

        public void RemoveAll()
        {
            users.Clear();
        }

        public void RemoveById(string Id)
        {
            User foundedUser = users.Find(u => u.ID == Id);
            users.Remove(foundedUser);
        }

        public void Update(User entity)
        {
            var foundedUser = users.Find(u => u.ID == entity.ID);
            var index = users.IndexOf(foundedUser);
            users.Remove(foundedUser);
            users.Insert(index, entity);
        }
    }
}
