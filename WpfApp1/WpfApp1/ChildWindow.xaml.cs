using Microsoft.Win32;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        Employee employee;
        public ChildWindow( Employee emp)
        {
            InitializeComponent();
            this.employee = emp;
            txtbFirstName.Text = emp.FirstName;
            txtbSecondName.Text = emp.SecondName;
            dtBirthday.Text= emp.Birthday;
            txtbSalary.Text = emp.Salary.ToString();
            txtbPosition.Text = emp.Position;

        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtbFirstName.Text))
                    employee.FirstName = txtbFirstName.Text;
                if (!string.IsNullOrEmpty(txtbSecondName.Text))
                    employee.SecondName = txtbSecondName.Text;
                if (!string.IsNullOrEmpty(dtBirthday.Text))
                    employee.Birthday = dtBirthday.Text;
                if (!string.IsNullOrEmpty(txtbSalary.Text))
                    employee.Salary = Convert.ToDouble(txtbSalary.Text);
                if (!string.IsNullOrEmpty(txtbPosition.Text))
                {
                    employee.Position = txtbPosition.Text;
                    this.DialogResult = true;
                }
                else MessageBox.Show("Необходимо заполнить все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {

                Grid mainGrid = this.Content as Grid;
                foreach (UIElement elem in mainGrid.Children)
                {
                    if (elem is Grid)
                    {
                        Grid childGrid = elem as Grid;
                        foreach (UIElement childElem in childGrid.Children)
                        {
                            if (childElem is Image)
                            {
                                Image image = childElem as Image;
                                image.Source = new BitmapImage(new Uri(openDialog.FileName, UriKind.RelativeOrAbsolute));
                            }
                        }                     
                    }
                }
              
            }
        }

        private void txtbSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            double g;
            if (!double.TryParse(txtbSalary.Text, out g)  && txtbSalary.Text != ",")
            {
                txtbSalary.Text = "";
            }
        }
    }
}
