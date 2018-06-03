using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public class Book
    {
        public List<Phone> phone;
        Phone NewPhone;

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

        public void AddAll(List<Phone> list)
        {
            if(list!=null)
            phone = list;
        }

        public List<Phone> Input()
        {
            if(phone!=null)
            return phone.ToList();
            return null;
        }

        public void Delete(int Index)
        {
            if(Index!=-1)
            if(phone != null)
            phone.RemoveAt(Index);
        }

        public bool Search(string Num)
        {
            if (phone != null)
            {
                if (phone.Find(x => x.Number == Num) == null)
                    return false;
                return true;
            }
            return false;
        }

        public void Sort()
        {
            

        }

    }
}
