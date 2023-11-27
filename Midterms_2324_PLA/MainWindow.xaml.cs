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

namespace Midterms_2324_PLA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database_midtermsDataContext db = new Database_midtermsDataContext();
        public MainWindow()
        {
            InitializeComponent();

            db = new Database_midtermsDataContext(Properties.Settings.Default.MidtermsDatabaseConnectionString);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (Login())
            {
               
                string role = "";

                var positions = from s in db.Db_Users where s.UserID == tb_UserId.Text select s;



            foreach (Db_User position in positions)
            {
                    
             role = position.Position;
                    

               if (role == "admin")
               {

                   MessageBox.Show("I am a ADMIN");

               }


               else if (role == "employee")
               {

                   MessageBox.Show("I am a EMPLOYEE");

               }

            }
                   
                    return;
                

            }
            else
            {
                MessageBox.Show("Incorrect password or user ID", "ERROR", MessageBoxButton.OK);
            }
        }


        private bool Login()
        {
            if (tb_UserId.Text.Length > 0)
            {
                if (tb_pass.Text.Length > 0)
                {
                    string Account = GetAccount();

                    if (!string.IsNullOrEmpty(Account))
                    {
                        string[] credentials = Account.Split('|');
                        return AccountCheck(credentials[0], credentials[1]);
                    }
                    
                }
                
            }

            return false;
        }



        private string GetAccount()
        {
            string Pass = "";
            string User = "";

            var users = from s in db.Db_Users where s.UserID == tb_UserId.Text && s.Password == tb_pass.Text select s;

            foreach (Db_User user in users)
            {
                
                User = user.UserID;
                Pass = user.Password;

            }

            return Pass + "|" + User;
        }


        private bool AccountCheck(string Pass, string User)
        {
            return tb_pass.Text == Pass && tb_UserId.Text == User;
        }

    }
}
