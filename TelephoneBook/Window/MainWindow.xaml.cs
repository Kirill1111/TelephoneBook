using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TelephoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Phone> List { get; set; }
        Book b = new Book();

        public MainWindow()
        {
            Check.CheckFile();
            b.AddAll(FileOperations.Load.LoadInfo("SaveInfo/List.TB"));
            InitializeComponent();
            Updata();
        }

        public void Updata()
        {
            List = b.Input();
            DataContext = this;
            Table.GetBindingExpression(ListView.ItemsSourceProperty)
                                .UpdateTarget();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            double Temp;

            if (Text1.Text != string.Empty && Text2.Text != string.Empty)
            {
                if (Double.TryParse(Text1.Text, out Temp))
                {
                    if (b.Search(Text1.Text))
                    {
                        b.AddNum(Text1.Text, Text2.Text);
                        Updata();
                    }
                    else
                    {
                        MessageBox.Show("Такой номер уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("В номере должны быть только цифры");
                }
            }
            else
                MessageBox.Show("Заполните поля");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            b.Delete(Table.SelectedIndex);
            Updata();
        }

        ~MainWindow()
        {
            FileOperations.Save.SaveInfo(List!=null?List.ToArray():new List<Phone>().ToArray(), "SaveInfo/List.TB");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            Edit edit = new Edit(b, List[Table.SelectedIndex].Number);
            edit.ShowDialog();

            if (edit.NewNumber != string.Empty && edit.NewName != string.Empty)
            {
                if (edit.NewNumber != null && edit.NewName != null)
                {
                    List[Table.SelectedIndex].Name = edit.NewName;
                    List[Table.SelectedIndex].Number = edit.NewNumber;
                }
            }
            Updata();

            edit.Close();
        }
    }

}
