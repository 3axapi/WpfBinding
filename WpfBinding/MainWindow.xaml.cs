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
using WpfBinding.Modules;
using static System.Net.Mime.MediaTypeNames;
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (dialog.ShowDialog() == true) 
            {
                imagealert.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void saveGrid(object sender, RoutedEventArgs e)
        {
            string id = idalert.Text;
            string name = namealert.Text;
            string age = agealert.Text;
            string src = imagealert.Source.ToString();
            string query = "INSERT INTO Users (id, name, age, src) VALUES (@ID, @Name, @Age, @SRC)";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@SRC", src);
                command.ExecuteNonQuery();
            }
        }

        private void loadGrid(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Users";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<User> usersList = new List<User>();
                    while (reader.Read())
                    {
                        usersList.Add(new User
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            Age = Convert.ToInt32(reader["age"]),
                            SRC = reader["src"].ToString()
                        });
                    }
                    mainDataGrid.ItemsSource = usersList;
                }
            }
        }

        private void clearDataBase(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM Users";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void clearGrid(object sender, RoutedEventArgs e)
        {
            mainDataGrid.ItemsSource = "";
        }
    }
}
