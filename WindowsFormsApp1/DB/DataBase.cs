using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DB
{
    public class DataBase
    {
        private static DataBase _instance;
        public static DataBase Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new DataBase();

                return _instance;
            }
        }

        public List<User> users = new List<User>();
    }
}
