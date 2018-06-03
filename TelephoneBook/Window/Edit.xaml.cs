using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace TelephoneBook
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public string NewName;
        public string NewNumber;
        private Book book;
        private string NumberIn;

        public Edit(Book book,string NumberIn)
        {
            InitializeComponent();
            this.book = book;
            this.NumberIn = NumberIn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double Temp;

            if (Name.Text != string.Empty && Number.Text != string.Empty)
            {
                if (Double.TryParse(Number.Text, out Temp))
                {
                    if (!book.Search(Number.Text) || Number.Text == NumberIn)
                    {
                        if (Regex.IsMatch(Name.Text, "^[а-яА-ЯёЁa-zA-Z0-9]+$"))
                        {
                            NewName = Name.Text;
                            NewNumber = Number.Text;
                            this.Close();
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

        }
    }
}
