using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entity
{
    public class BaseEntity
    {
        public virtual string ID { get; set; }
        public BaseEntity()
        {
            ID = Guid.NewGuid().ToString();
        }

    }
}
