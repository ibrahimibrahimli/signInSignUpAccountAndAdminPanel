using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entity
{
    public class Account
    {
        private static Account _instance;
        public static Account Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Account();
                return _instance;
            }
        }

        public User User { get; set; }

    }
}
