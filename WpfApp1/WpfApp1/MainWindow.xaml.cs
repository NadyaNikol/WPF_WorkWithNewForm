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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            ChildWindow child = new ChildWindow(employee);

            if (child.ShowDialog() == true)
            {
                lstbPerson.Items.Add(employee);
            }
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstbPerson.SelectedIndex != -1)
            {
                int index = lstbPerson.SelectedIndex;
                Employee employee = lstbPerson.SelectedItem as Employee;
                ChildWindow child = new ChildWindow(employee);
                if (child.ShowDialog() == true)
                {
                    lstbPerson.Items.Insert(index, employee);
                    lstbPerson.Items.RemoveAt(index + 1);
                    //lstbPerson.Items.Add(employee);
                }

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstbPerson.Items.RemoveAt(lstbPerson.SelectedIndex);
            }
            catch { }
        }
    }
}
