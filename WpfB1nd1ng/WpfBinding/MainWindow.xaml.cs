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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBinding
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

        private void saveData(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Dane z Formułarza do zapisu";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "pliki tekstów (*.txt) | *txt";

            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                string dane = returnText.Text;
                System.IO.File.WriteAllText(filePath, dane);
            }
        }
        private void secondSaveData(object sender, RoutedEventArgs e)
        {
            string textToSave = textDoKopiowania.Text;
            string docFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            try
            {
                string filePath = System.IO.Path.Combine(docFilePath, "moje_dane.txt");
                System.IO.File.WriteAllText(filePath, textToSave);
                MessageBox.Show("Super poszło");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bład podczas zapisywania danych {ex.Message}");
            }
        }
    }
}