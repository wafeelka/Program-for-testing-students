using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySqlConnector;
using The_App_for_students.Class;
using System.Security.Cryptography.X509Certificates;

namespace The_App_for_students
{
    /// <summary>
    /// Логика взаимодействия для PageRegist.xaml
    /// </summary>
    public partial class PageRegist : Window
    {
        public PageRegist()
        {
            InitializeComponent();
        }

        private void RegistButton_Click(object sender, RoutedEventArgs e)
        {
            
            Regist newUser = new Regist();
            DataBase db = new DataBase();
            const string codeForAdmin = "TakeThisManOnJob";
                            
            db.openConnect();

            if (ForAdminField.Text == codeForAdmin)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`ID`, `Login`, `Password`, `Root`) VALUES(NULL, @newLogin, @newPass, @root)", db.GetConnection());
                command.Parameters.Add("@newLogin", MySqlDbType.VarChar).Value = NewLoginField.Text;
                command.Parameters.Add("@newPass", MySqlDbType.VarChar).Value = NewPasswordField.Text;
                command.Parameters.Add("@root", MySqlDbType.VarChar).Value = "admin";
                if (command.ExecuteNonQuery() == 1) MessageBox.Show("Поздравляем, вы успешно зарегистрировались!");
                else MessageBox.Show("Аккаунт не был зарегистрирован.Прошу повоторите попытку");
            }

            else
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`ID`, `Login`, `Password`, `Root`) VALUES(NULL, @newLogin, @newPass, @root)", db.GetConnection());
                command.Parameters.Add("@newLogin", MySqlDbType.VarChar).Value = NewLoginField.Text;
                command.Parameters.Add("@newPass", MySqlDbType.VarChar).Value = NewPasswordField.Text;
                command.Parameters.Add("@root", MySqlDbType.VarChar).Value = "user";
                if (command.ExecuteNonQuery() == 1) MessageBox.Show("Поздравляем, вы успешно зарегистрировались!");
                else MessageBox.Show("Аккаунт не был зарегистрирован. Пожалуйста повоторите попытку");
            }
            db.closedConnect();
            
            
               

            
            
        }
    }
}
