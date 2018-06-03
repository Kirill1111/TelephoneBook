using System;
using System.Windows;
using System.Text.RegularExpressions;

namespace TelephoneBook.Classes
{
    class Test
    {
        public static bool Tested(string Name, string Number,Book book,string NumberIn)
        {
            if (Name != string.Empty && Number != string.Empty)
            {
                if (Double.TryParse(Number, out double Temp))
                {
                    if (!book.Search(Number) || Number == NumberIn)
                    {
                        if (Regex.IsMatch(Name, "^[а-яА-ЯёЁa-zA-Z0-9]+$"))
                        {
                            return true;
                        }
                        else
                            MessageBox.Show("Недопустимые символы");
                    }
                    else
                        MessageBox.Show("Такой номер уже существует");
                }
                else
                    MessageBox.Show("В номере должны быть только цифры");
            }
            else
                MessageBox.Show("Заполните поля");

            return false;
        }
    }
}
