using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAF_Ochimpo.Dao
{
    interface IDaoModel<T>
    {
        void addEmpleado(T t);
        void updateEmpleado(T t);
        void deleteEmpleado(T t);
        List<T> showAll();
    }
}
