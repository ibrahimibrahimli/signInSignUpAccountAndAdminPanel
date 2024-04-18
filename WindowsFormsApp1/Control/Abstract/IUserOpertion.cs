using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Control.Abstract
{
    public interface IUserOperation : IBaseOperation<User>
    {
        User GetByUsername(string username);
    }
}
