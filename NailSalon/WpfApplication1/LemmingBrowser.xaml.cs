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
    /// Interaction logic for LemmingBrowser.xaml
    /// </summary>
    public partial class LemmingBrowser : Window
    {
        private DataSet1 _comboData = new DataSet1();
        private DataSet2 _mydata = new DataSet2();

        public LemmingBrowser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgLemmings.DataContext = _mydata.LemList;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataSet2TableAdapters.QueriesTableAdapter ta = new DataSet2TableAdapters.QueriesTableAdapter();
            if (ta.INS_NewLemming(cmbBrand.SelectedBrandID, txtName.Text, txtDesc.Text, txtNotes.Text, int.Parse(txtLustLevel.Text)) > 0)
            {
                MessageBox.Show("Saved!");
                LoadLemmings((bool)cbxShowKilled.IsChecked);
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
            cmbBrand.SelectedIndex = 0;
            txtDesc.Clear();
            txtName.Clear();
            txtNotes.Clear();
        }

        private void LoadLemmings(bool withDeceased)
        {
            DataSet2TableAdapters.LemListTableAdapter ta = new DataSet2TableAdapters.LemListTableAdapter();
            if (withDeceased)
                ta.Fill(_mydata.LemList);
            else
                ta.FillLive(_mydata.LemList);
        }

        private DataSet2.LemListRow MyLemRow()
        {
            DataRowView drv = (DataRowView)dgLemmings.CurrentItem;
            DataRow dr = drv.Row;
            DataSet2.LemListRow lr = (DataSet2.LemListRow)dr;

            return lr;
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            DataSet2.LemListRow row = MyLemRow();
            //first put in inventory
            DataSet1TableAdapters.QueriesTableAdapter taI = new DataSet1TableAdapters.QueriesTableAdapter();
            taI.INS_NewBottleWithDate(row.brandID, row.Name, row.Description, row.notes, 0, 0, 13, DateTime.Now);
            //then kill it
            DataSet2TableAdapters.QueriesTableAdapter ta = new DataSet2TableAdapters.QueriesTableAdapter();
            ta.UPD_KillLemming(row.id);
            LoadLemmings((bool)cbxShowKilled.IsChecked);
        }

        private void btnOrdered_Click(object sender, RoutedEventArgs e)
        {
            DataSet2.LemListRow row = MyLemRow();
            //first put in orders
            DataSet1TableAdapters.QueriesTableAdapter taO = new DataSet1TableAdapters.QueriesTableAdapter();
            taO.INS_NewOrder(row.brandID, row.Name, row.Description, row.notes, DateTime.Now);
            //then kill it
            DataSet2TableAdapters.QueriesTableAdapter ta = new DataSet2TableAdapters.QueriesTableAdapter();
            ta.UPD_KillLemming(row.id);
            LoadLemmings((bool)cbxShowKilled.IsChecked);
        }

        private void btnKill_Click(object sender, RoutedEventArgs e)
        {
            DataSet2.LemListRow row = MyLemRow();
            DataSet2TableAdapters.QueriesTableAdapter ta = new DataSet2TableAdapters.QueriesTableAdapter();
            ta.UPD_KillLemming(row.id);
            LoadLemmings((bool)cbxShowKilled.IsChecked);
        }

        private void cbxShowKilled_Checked(object sender, RoutedEventArgs e)
        {
            LoadLemmings((bool)cbxShowKilled.IsChecked);
        }

        private void dgLemmings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLemmings(false);
        }

    }
}
