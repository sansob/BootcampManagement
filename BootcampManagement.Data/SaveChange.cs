using BootcampManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Data
{
    public class SaveChange
    {
        public static MyContext _myContext = new MyContext();
        public SaveChange(MyContext myContext)
        {
                _myContext = myContext;
        }

        public SaveChange()
        {

        }

        public bool save()
        {
            var result = _myContext.SaveChanges();
            return result > 0;
        }
    }
}
