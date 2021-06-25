using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Library_Core;
using Binding = System.Windows.Data.Binding;

namespace Library_directory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            lbData.ItemsSource = CatalogObjectsFab.InitFiguresData();
           
        }

        private void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Cat = lbData.SelectedItem as CatalogObjectsData;

            DataTable dt = new DataTable();
            foreach (var c in Cat.Data)
            {
                dt.Columns.Add(c.Key);
                DataRow dr = dt.NewRow(); ;
                dt.Rows.Add(dr);
                dr[c.Key] = c.Value;
            }
            dgvFigData.ItemsSource = dt.DefaultView;
        }
    }
}