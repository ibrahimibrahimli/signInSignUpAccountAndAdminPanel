using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Control.Abstract
{
    public interface IBaseOperation<T> where T : BaseEntity, new()
    {
        void Add (T entity);
        List<T> GetAll();
        T GetById(string Id);
        void RemoveAll();
        void RemoveById(string Id);
        void Update (T entity);
    }
}
