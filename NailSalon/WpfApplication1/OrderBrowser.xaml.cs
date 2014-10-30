using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for OrderBrowser.xaml
    /// </summary>
    public partial class OrderBrowser : Window
    {
        private DataSet1 _mydata = new DataSet1();

        public OrderBrowser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgOrdered.DataContext = _mydata.OnOrder;
            grid2.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
            
            if (ta.INS_NewOrder(ucBrandPickerWithAdd1.SelectedBrandID, txtName.Text, txtDesc.Text, txtNotes.Text, dtpOrd.SelectedDate) > 0)
            {
                MessageBox.Show("Saved!");
                LoadOrders();
                ClearNoob();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = System.Windows.Visibility.Collapsed;
            ClearNoob();
        }

        private void ClearNoob()
        {
            ucBrandPickerWithAdd1.SelectedIndex = 0;
            txtDesc.Clear();
            txtName.Clear();
            txtNotes.Clear();            
        }

        private void LoadOrders()
        {
            DataSet1TableAdapters.OnOrderTableAdapter ta = new DataSet1TableAdapters.OnOrderTableAdapter();
            ta.Fill(_mydata.OnOrder);
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)dgOrdered.CurrentItem;
            DataRow dr = drv.Row;

            DataSet1.OnOrderRow row = (DataSet1.OnOrderRow)dr;

            DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
            ta.INS_OrderToInventory(row.brandID, row.name, row.description, DateTime.Now);
            ta.UPD_OrderReceived((int)row.orderID);
            LoadOrders();
        }

        private void dgOrdered_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }
        
    }
}
