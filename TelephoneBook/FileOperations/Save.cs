using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TelephoneBook.FileOperations
{
    class Save
    {
        static string Str;

        public static void SaveInfo(Phone[] phone,string path)
        {
            foreach(var i in phone)
            {
                Str += i.Name+"|";
                Str += i.Number + "&";
            }

            File.WriteAllText(path,Str);

        }


    }
}
