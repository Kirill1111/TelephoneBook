using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Text.RegularExpressions;

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
            if (Classes.Test.Tested(Text2.Text, Text1.Text, b, null))
            {
                b.AddNum(Text1.Text, Text2.Text);
                Updata();
            }   
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
            if (Table.SelectedIndex != -1)
            {
                Edit edit = new Edit(b, List[Table.SelectedIndex].Number);
                edit.ShowDialog();

                if (edit.NewName!=null|| edit.NewNumber!=null)
                {
                    List[Table.SelectedIndex].Name = edit.NewName;
                    List[Table.SelectedIndex].Number = edit.NewNumber;
                }

                Updata();
                edit.Close();
            }
        }



    }

}
