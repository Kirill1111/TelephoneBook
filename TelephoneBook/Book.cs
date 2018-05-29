using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public class Book
    {
        public static List<Phone> phone;

        public Book()
        {
            phone = new List<Phone>();
        }

        public void AddNum(string Number , string Name)
        {
            Phone NewPhone = new Phone();
            NewPhone.Name = Name;
            NewPhone.Number = Number;

            phone.Add(NewPhone); 
        }

        public static List<Phone> Input()
        {
            if(phone!=null)
            return phone.ToList();
            return null;
        }

    }
}
