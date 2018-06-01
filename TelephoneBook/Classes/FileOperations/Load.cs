using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;

namespace TelephoneBook.FileOperations
{
    class Load
    {
        private static string[] result;
        private static List<Phone> phone = new List<Phone>();

        public static List<Phone> LoadInfo(string path)
        {
            try
            {
                string Str = File.ReadAllText(path);

                result = Str.Split(new char[] { '|', '&' });
                result[result.Length - 1] = null;
                result = result.Where(x => x != null).ToArray();

                for (int i = 0; i < result.Length; i += 2)
                    phone.Add(new Phone() { Name = result[i], Number = result[i + 1] });
            }catch(Exception)
            {
                MessageBox.Show("Произошла ошибка загрузки данных");
            }

                return phone;
            
        }

    }
}
