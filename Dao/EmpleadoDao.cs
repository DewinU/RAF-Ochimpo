using RAF_Ochimpo.Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAF_Ochimpo.Dao
{
    interface IEmpleadoDao : IDaoModel<Empleado>
    {
        Empleado FindById(int id);

        List<Empleado> FindByNombre(string nombre);
        List<Empleado> FindByApellidos(string apellido);
        List<Empleado> FindByHireData(DateTime fecha);
        List<Empleado> FindByRangoSalario(float min, float max);
    }
}
