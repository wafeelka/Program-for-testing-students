using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Data.Common;
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
using The_App_for_students.Class;
using MySql.Data.MySqlClient;

namespace The_App_for_students
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

        private void Sing_In_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passField.Text;
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT* FROM `users` WHERE `Login` = @ul AND `Password` = @up", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0) {MessageBox.Show("Authentification succeed");}
            else { MessageBox.Show("Authentification failed"); }
        }
    }
}
 
