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
        private BinaryReader brData;
        private BinaryReader brHeader;
        private FileStream fData;
        private FileStream fHeader;
        private const string FILENAME_HEADER = "header.dat";
        private const string FILENAME_DATA = "data.dat";
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

            
            if (brData != null)
            {
                brData.Close();
            }
            
            if (bwHeader != null)
            {
                bwHeader.Close();
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
                if(k != 0)
                {
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
                    continue;
                }
                
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
                            
            long headerPos = 8 + (t.Id - 1) * 4;
            brHeader.BaseStream.Seek(headerPos, SeekOrigin.Begin);
            int k = brHeader.ReadInt32();

            long dataPos = (k - 1) * SIZE;
            bwData.BaseStream.Seek(dataPos, SeekOrigin.Begin);
            bwData.Write(k);
            bwData.Write(t.Cod);
            bwData.Write(t.FirstName);
            bwData.Write(t.LastName);
            bwData.Write(t.HireDate);
            bwData.Write(t.Salary);
            Close();
        }

        public void deleteEmpleado(Empleado t)
        {
            Open();
            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = brHeader.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                if (i == t.Id - 1)
                {
                    long posHeader = 8 + i * 4;
                    bwHeader.BaseStream.Seek(posHeader, SeekOrigin.Begin);
                    bwHeader.Write(0);
                    break;
                }
            }
            Close();
        }

        
        public Empleado FindById(int id)
        {
            Open();
            Empleado e = null;
            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = brHeader.ReadInt32();

            if (id <= 0 ||  id > n)
            {
                return e;
            }

            long dpos = (id - 1) * SIZE;
            brData.BaseStream.Seek(dpos, SeekOrigin.Begin);
            e = new Empleado()
            {
                Id = brData.ReadInt32(),
                Cod = brData.ReadString(),
                FirstName = brData.ReadString(),
                LastName = brData.ReadString(),
                HireDate = brData.ReadString(),
                Salary = brData.ReadSingle()
            };
            Close();
            return e;

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
