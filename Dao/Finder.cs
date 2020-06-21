using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAF_Ochimpo.Dao
{
    class Finder
    {
        public static int BinarySearchById(BinaryReader binaryReader, int key, int low, int high)
        {
            int middle = (low + high) / 2;
            long pos = 8 + middle * 4;
            binaryReader.BaseStream.Seek(pos, SeekOrigin.Begin);
            int id = binaryReader.ReadInt32();
            if (high < low)
            {
                return -1;
            }

            if (key == id)
            {
                return middle;
            }
            else if (key < id)
            {
                return BinarySearchById(binaryReader, key, low, middle - 1);
            }
            else
            {
                return BinarySearchById(binaryReader, key, middle + 1, high);
            }
        }

    }
}
