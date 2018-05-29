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
        static Phone NewPhone;

        public Book()
        {
            phone = new List<Phone>();
        }

        public void AddNum(string Number , string Name)
        {
            NewPhone = new Phone();
            NewPhone.Name = Name;
            NewPhone.Number = Number;

            phone.Add(NewPhone); 
        }

        public List<Phone> Input()
        {
            if(phone!=null)
            return phone.ToList();
            return null;
        }

        public void Delete(int Index)
        {
            if(phone != null)
            phone.RemoveAt(Index);
        }

        public bool Search(string Num)
        {
            if (phone.Find(x => x.Number == Num) == null)
                return true;
            return false;
        }

    }
}
