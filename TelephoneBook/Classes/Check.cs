using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TelephoneBook
{
    class Check
    {
        static public void CheckFile()
        {
                if (!Directory.Exists("SaveInfo"))
                    Directory.CreateDirectory("SaveInfo");

            CheckTheFile("SaveInfo/List.TB");
        }

        static private void CheckTheFile(string path)
        {
            if (!File.Exists(path))
            {
                FileStream stream = new FileStream(path, FileMode.Create);
                stream.Close();
            }
        }
    }
}
