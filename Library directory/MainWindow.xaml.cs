using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using Library_Core;
using System.Collections.ObjectModel;

namespace Library_directory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CatalogObject> catalogObjects = new ObservableCollection<CatalogObject>();
        static DataTable dt = new DataTable();
        DataRow dataRow = dt.NewRow();
        public MainWindow()
        {
            InitializeComponent();
            lbData.ItemsSource = CatalogObjectsFab.InitFiguresData();
            lbDataList.ItemsSource = catalogObjects;
        }


        private void ClearDateTable()
        {
            dt.Rows.Clear();
            dt.Columns.Clear();   //warning: All Columns delete
            dt.Dispose();
        }
        private void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearDateTable();
            dgvFigData.ItemsSource = null;

            var catalogObject = lbData.SelectedItem as CatalogObjectsData;

            dt.Rows.Add(dataRow);
            foreach (var c in catalogObject.Data)
            {
                dt.Columns.Add(c.Key);
                if(c.Key == "")
                    dataRow[c.Key] = c.Value;
            }
            dgvFigData.ItemsSource = dt.DefaultView;
        }


        private void saveDataBtn_Click(object sender, RoutedEventArgs e)
        {
            CatalogObjectsData fig = lbData.SelectedItem as CatalogObjectsData;

            foreach (DataRow row in dt.Rows)
            {
                foreach (var c in fig.Data.ToArray())
                {
                    var key = c.Key;
                    var val = row[c.Key].ToString();
                    if (val == "")
                    {
                        System.Windows.MessageBox.Show("Неправильно введенные данные " + key);
                        ClearDateTable();
                        return;
                    }
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
                ClearDateTable();
                System.Windows.MessageBox.Show("Вы успешно добавили " + fig.Name);
        }

        private void CreateObject()
        {
            var fig = CatalogObjectsFab.Make(lbData.SelectedItem as CatalogObjectsData);
            if (fig != null)
            {
                catalogObjects.Add(fig);
            }
        }


        private void lbDataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            catalogObjects.RemoveAt(lbDataList.SelectedIndex);
            ClearDateTable();
        }
    }
}