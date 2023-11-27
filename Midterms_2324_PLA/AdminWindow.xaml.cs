using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Midterms_2324_PLA
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        Database_midtermsDataContext db = new Database_midtermsDataContext();

        private ObservableCollection<Product> Products;
        private ObservableCollection<Product> DisplayProduct;

        public AdminWindow()
        {
            InitializeComponent();
            InitializeListView();

            db = new Database_midtermsDataContext(Properties.Settings.Default.MidtermsDatabaseConnectionString);
        }

       public class Product
        {
            public string Pid { get; set; }
            public string Pname { get; set; }
            public string Pdescrip { get; set; }
            public string Pstock { get; set; }
            public string Pcost { get; set; }
            public string Psellingprice { get; set; }

        }

        private void InitializeListView()
        {
            Products = new ObservableCollection<Product>();
            DisplayProduct = Products;
            Lv_ProductData.ItemsSource = DisplayProduct;


            try
            {
                var positions = from s in db.Db_Users where s.UserID  select s;

            }
        }





    }
}
