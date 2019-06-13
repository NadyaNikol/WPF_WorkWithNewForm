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
       
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                //Image image = new Image();
                
                //(this.Content as Panel).Children.Add(image);

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
                            //Grid.SetRowSpan(image, 6);                       
                    }
                }
              
            }
        }
    }
}
