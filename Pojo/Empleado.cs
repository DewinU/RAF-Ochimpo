using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAF_Ochimpo.Pojo
{
    class Empleado
    {
        public int Id { get; set; } //4
        public string Cod { get; set; } //5 * 4 = 20
        public string FirstName { get; set; } // 20 * 4 = 80
        public string LastName { get; set; } // 20 * 4 = 80
        public string HireDate { get; set; } // 20 * 4 = 80
        public float Salary { get; set; } // 4

        //SIZE = 270

        public Empleado()
        {
        }

        public Empleado(string cod, string firstName, string lastName, string hireDate, float salary)
        {
            Cod = cod;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Salary = salary;
        }

        public Empleado(int id, string cod, string firstName, string lastName, string hireDate, float salary)
        {
            Id = id;
            Cod = cod;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Salary = salary;
        }

        public override string ToString()
        {
            return $@"ID: {Id} Código de empleado: {Cod}  Nombres: {FirstName} Apellidos: {LastName} Fecha de contratación: {HireDate} Salario base: {Salary}";
        }
    }
}
