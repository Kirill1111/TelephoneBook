using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TelephoneBook.FileOperations
{
    class Load
    {
        static string[] result;
        public static List<Phone> LoadInfo(string path)
        {
            string Str = File.ReadAllText(path);
 
                result = Str.Split(new char[] { '|', '&' });
                result[result.Length-1] = null;
                result = result.Where(x => x != null).ToArray();

                List<Phone> phone = new List<Phone>();
                
                for (int i = 0; i < result.Length; i += 2)
                {
                    Phone Myphone = new Phone();
                    Myphone.Name = result[i];
                    Myphone.Number = result[i + 1];
                    phone.Add(Myphone);
                }
                    return phone;
        }

    }
}
