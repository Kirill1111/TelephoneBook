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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            ((ListView)Table).GetBindingExpression(ListView.ItemsSourceProperty)
                    .UpdateTarget();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            double Temp;

            if (Text1.Text != "" && Text2.Text != "")
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
            FileOperations.Save.SaveInfo(List.ToArray(),"SaveInfo/List.TB");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            Edit edit = new Edit(Table.SelectedIndex,b, List[Table.SelectedIndex].Number);
            edit.ShowDialog();

            if (edit.NewNumber != "" && edit.NewName != "")
            {
                List[Table.SelectedIndex].Name = edit.NewName;
                List[Table.SelectedIndex].Number = edit.NewNumber;
            }
            Updata();

            edit.Close();
        }
    }
    
}
