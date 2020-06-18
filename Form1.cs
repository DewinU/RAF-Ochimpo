using RAF_Ochimpo.Imp;
using RAF_Ochimpo.Pojo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAF_Ochimpo
{
    public partial class Form1 : Form
    {
        ImpDaoEmpleado iDao;
        public Form1()
        {
            iDao = new ImpDaoEmpleado();
            InitializeComponent();
            RefreshTable();
        }

        private void RefreshTable()
        {
            tableView.Rows.Clear();
            int i = 0;
            List<Empleado> empleados = iDao.showAll();
            foreach(var e in empleados)
            {
                tableView.Rows.Add();
                tableView.Rows[i].Cells[1].Value = e.Id;
                tableView.Rows[i].Cells[1].Value = e.Cod;
                tableView.Rows[i].Cells[1].Value = e.FirstName;
                tableView.Rows[i].Cells[2].Value = e.LastName;
                tableView.Rows[i].Cells[1].Value = e.HireDate;
                tableView.Rows[i].Cells[1].Value = e.Salary;
                i++;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            {
                Id = 1,
                Cod = "777",
                FirstName = "Dewin",
                LastName = "Umana",
                HireDate = "2020",
                Salary = 50000.00f
            };
            iDao.addEmpleado(emp);
            RefreshTable();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            {
                Id = 2,
                Cod = "56",
                FirstName = "Gustavo",
                LastName = "Leyton",
                HireDate = "2030",
                Salary = 2000.00f
            };
            iDao.addEmpleado(emp);
            RefreshTable();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            {
                Id = 3,
                Cod = "464",
                FirstName = "Test",
                LastName = "Admin",
                HireDate = "2000",
                Salary = 100000.00f
            };
            iDao.addEmpleado(emp);
            RefreshTable();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<Empleado> empleados = iDao.showAll();
            string emp = empleados.ElementAt(1).ToString();

            label1.Text = emp;
           
        }
    }
}
