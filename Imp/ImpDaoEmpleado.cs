using RAF_Ochimpo.Dao;
using RAF_Ochimpo.Pojo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RAF_Ochimpo.Imp
{
    class ImpDaoEmpleado : IEmpleadoDao
    {
        private BinaryWriter bwData;
        private BinaryWriter bwHeader;
        private BinaryWriter bwTemp;
        private BinaryReader brData;
        private BinaryReader brHeader;
        private BinaryReader brTemp;
        private FileStream fData;
        private FileStream fHeader;
        private FileStream fTemp;
        private const string FILENAME_HEADER = "header.dat";
        private const string FILENAME_DATA = "data.dat";
        private const string TEMP_HEADER = "temp.dat";
        private const int SIZE = 268;

        private void Open()
        {
            fData = new FileStream(FILENAME_DATA,
                FileMode.OpenOrCreate, FileAccess.ReadWrite);

            fHeader = new FileStream(FILENAME_HEADER,
                FileMode.OpenOrCreate, FileAccess.ReadWrite);

            brData = new BinaryReader(fData);
            bwData = new BinaryWriter(fData);

            brHeader = new BinaryReader(fHeader);
            bwHeader = new BinaryWriter(fHeader);


            if (fHeader.Length == 0)
            {
                bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                bwHeader.Write(0);
                bwHeader.Write(0);
            }

        }

        private void Close()
        {
            if (brHeader != null)
            {
                brHeader.Close();
            }

            if (brTemp != null)
            {
                brTemp.Close();
            }
            
            if (brData != null)
            {
                brData.Close();
            }
            
            if (bwHeader != null)
            {
                bwHeader.Close();
            }

            if (bwTemp != null)
            {
                bwTemp.Close();
            }

            if (bwData != null)
            {
                bwData.Close();
            }
            
            if (fHeader != null)
            {
                fHeader.Close();
            }
            
            if (fData != null)
            {
                fData.Close();
            }

            if(fTemp != null)
            {
                fTemp.Close();
            }
        }

        public List<Empleado> showAll()
        {
            Open();
            List<Empleado> empleados = new List<Empleado>();
            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = brHeader.ReadInt32();
            for (int i = 0; i < n; i++)
            {
                long posHeader = 8 + i * 4;
                brHeader.BaseStream.Seek(posHeader, SeekOrigin.Begin);
                int k = brHeader.ReadInt32();
                long posData = (k - 1) * SIZE;
                brData.BaseStream.Seek(posData, SeekOrigin.Begin);
                Empleado e = new Empleado()
                {
                    Id = brData.ReadInt32(),
                    Cod = brData.ReadString(),
                    FirstName = brData.ReadString(),
                    LastName = brData.ReadString(),
                    HireDate = brData.ReadString(),
                    Salary = brData.ReadSingle()
                };
                
                empleados.Add(e);
            }
            Close();
            return empleados;
        }

        public void addEmpleado(Empleado t)
        {
            Open();
            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = brHeader.ReadInt32();
            int k = brHeader.ReadInt32();

            long posData = k * SIZE;
            bwData.BaseStream.Seek(posData, SeekOrigin.Begin);
            bwData.Write(++k);
            bwData.Write(t.Cod);
            bwData.Write(t.FirstName);
            bwData.Write(t.LastName);
            bwData.Write(t.HireDate);
            bwData.Write(t.Salary);

            bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            bwHeader.Write(++n);
            bwHeader.Write(k);

            long posHeader = 8 + (n - 1) * 4;
            bwHeader.BaseStream.Seek(posHeader, SeekOrigin.Begin);
            bwHeader.Write(k);

            Close();
        }

        public void updateEmpleado(Empleado t)
        {
            Open();
            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = brHeader.ReadInt32();

            if(t.Id > n || t.Id <= 0)
            {
                return;
            }

                            
            long headerPos = 8 + t.Id * 4;  //(t.id - 1)¿?
            brHeader.BaseStream.Seek(headerPos, SeekOrigin.Current);
            int k = brHeader.ReadInt32();

            long dataPos = (k - 1) * SIZE;
            bwData.BaseStream.Seek(dataPos, SeekOrigin.Begin);

            bwData.Write(k); //Write(k) ¿?
            bwData.Write(t.Cod);
            bwData.Write(t.FirstName);
            bwData.Write(t.LastName);
            bwData.Write(t.HireDate);
            bwData.Write(t.Salary);

            Close();
        }

        public void deleteEmpleado(Empleado t)
        {
            fTemp = new FileStream(TEMP_HEADER,
                FileMode.CreateNew, FileAccess.ReadWrite);
            brTemp = new BinaryReader(fTemp);
            bwTemp = new BinaryWriter(fTemp);
            bwTemp.BaseStream.Seek(0, SeekOrigin.Begin);
            bwTemp.Write(0);
            bwTemp.Write(0);
            bwTemp.BaseStream.Seek(0, SeekOrigin.Current);
            int n = brTemp.ReadInt32();

            List<Empleado> empleados = showAll();
            foreach(var e in empleados.Skip(t.Id))
            {
                bwTemp.BaseStream.Seek(0, SeekOrigin.Begin);
                bwTemp.Write(++n);
                bwTemp.Write(e.Id);

                long posHeader = 8 + (n - 1) * 4;
                bwTemp.BaseStream.Seek(posHeader, SeekOrigin.Begin);
                bwTemp.Write(e.Id);
            }
            Close();
            File.Delete(FILENAME_HEADER);
            File.Move(TEMP_HEADER, FILENAME_HEADER);
        }

        
        public Empleado FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindByApellidos(string apellido)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindByHireData(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindByRangoSalario(float min, float max)
        {
            throw new NotImplementedException();
        }

    }
}
