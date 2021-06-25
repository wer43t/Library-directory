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

namespace Library_directory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CatalogObject> catalogObjects = new List<CatalogObject>();
        DataTable dt = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            lbData.ItemsSource = CatalogObjectsFab.InitFiguresData();
        }


        private void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRow dataRow = dt.NewRow();
            dgvFigData.ItemsSource = null;
            dt.Columns.Clear();
            dt.Rows.Clear();
            var catalogObject = lbData.SelectedItem as CatalogObjectsData;

            dt.Rows.Add(dataRow);
            foreach (var c in catalogObject.Data)
            {
                dt.Columns.Add(c.Key);
                dataRow[c.Key] = c.Value;
            }
            dgvFigData.ItemsSource = dt.DefaultView;
        }


        private void saveDataBtn_Click(object sender, RoutedEventArgs e)
        {
            var fig = lbData.SelectedItem as CatalogObjectsData;
            foreach (DataRow row in dt.Rows)
            {
                foreach (var c in fig.Data.ToArray())
                {
                    var key = c.Key;
                    var val = row[c.Key].ToString();
                    try
                    {
                        fig.Data[key] = val;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Неправильно введенные данные", key);
                    }
                }
            }
            CreateObject();
        }

        private void CreateObject()
        {
            var fig = CatalogObjectsFab.Make(lbData.SelectedItem as CatalogObjectsData);
            if (fig != null)
            {
                catalogObjects.Add(fig);
            }
        }

        private void btnSaveInJSON_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}