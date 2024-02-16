using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
// system.data.sqlite installing

namespace WpfBinding
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Data Source=MojaBaza.db;Version=3;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void imageLoad(object sender, RoutedEventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*|";

                if (dialog.ShowDialog() == true) 
                {
                    imageLocation = dialog.FileName;
                    imagealert.Source = {imageLocation};
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("En Error Occured");
            }
        }
    }
}
