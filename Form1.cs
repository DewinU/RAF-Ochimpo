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
                tableView.Rows[i].Cells[0].Value = e.Id;
                tableView.Rows[i].Cells[1].Value = e.Cod;
                tableView.Rows[i].Cells[2].Value = e.FirstName;
                tableView.Rows[i].Cells[3].Value = e.LastName;
                tableView.Rows[i].Cells[4].Value = e.HireDate;
                tableView.Rows[i].Cells[5].Value = e.Salary;
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
            int Index = tableView.CurrentRow.Index;
            int id = Convert.ToInt32(tableView.Rows[Index].Cells[0].Value);
            Empleado empleado = iDao.FindById(id);
            empleado.LastName = "EDITADO";
            iDao.updateEmpleado(empleado);
            RefreshTable();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            { 
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
            int Index = tableView.CurrentRow.Index;
            int id = Convert.ToInt32(tableView.Rows[Index].Cells[0].Value);
            Empleado empleado = iDao.FindById(id);
            iDao.deleteEmpleado(empleado);
            RefreshTable();
        }


        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(tableView.CurrentRow.Cells[0].Value);
            Empleado empleado = iDao.FindById(id);
            if(empleado != null){
                label1.Text = empleado.ToString();
            }
            else
            {
                label1.Text = "Es Nulo";
            }
            
        }
    }
}
