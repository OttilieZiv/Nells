using System;
using System.Collections.Generic;
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
    /// Interaction logic for StashBrowser.xaml
    /// </summary>
    public partial class StashBrowser : Window
    {
        private DataSet1 _data = new DataSet1();
        bool filterbyused = false;
        bool usedonly = false;

        public StashBrowser()
        {
            InitializeComponent();
        }

        private void SetupCombos()
        {
            //flipping 'eck, there are a lot of these buggers!
            DataSet1TableAdapters.brandsTableAdapter taBr = new DataSet1TableAdapters.brandsTableAdapter();
            taBr.ClearBeforeFill = false;

            _data.brands.Clear();
            _data.brands.AddbrandsRow(-1, "Any brand");
            taBr.FillOrdered(_data.brands);

            cmbBrand.ItemsSource = _data.brands.DefaultView;
            cmbBrand.DisplayMemberPath = _data.brands.Columns["Name"].ToString();
            cmbBrand.SelectedValuePath = _data.brands.Columns["ID"].ToString();
            cmbBrand.SelectedIndex = 0;

            DataSet1TableAdapters.drawersTableAdapter taD = new DataSet1TableAdapters.drawersTableAdapter();
            taD.ClearBeforeFill = false;

            _data.drawers.Clear();
            _data.drawers.AdddrawersRow(-1, "All drawers");
            taD.FillOrdered(_data.drawers);

            cmbDrawer.ItemsSource = _data.drawers.DefaultView;
            cmbDrawer.DisplayMemberPath = _data.drawers.Columns["DrawerName"].ToString();
            cmbDrawer.SelectedValuePath = _data.drawers.Columns["ID"].ToString();
            cmbDrawer.SelectedIndex = 0;

            DataSet1TableAdapters.bottletagsTableAdapter taT = new DataSet1TableAdapters.bottletagsTableAdapter();
            taT.ClearBeforeFill = false;

            _data.bottletags.Clear();
            _data.bottletags.AddbottletagsRow(-1, "Any tagging", 0);
            _data.bottletags.AddbottletagsRow(0, "No tags", 0);
            taT.FillOrderedPhys(_data.bottletags);

            cmbTag.ItemsSource = _data.bottletags.DefaultView;
            cmbTag.DisplayMemberPath = _data.bottletags.Columns["TagName"].ToString();
            cmbTag.SelectedValuePath = _data.bottletags.Columns["ID"].ToString();
            cmbTag.SelectedIndex = 0;

            DataSet1TableAdapters.CountryListTableAdapter taC = new DataSet1TableAdapters.CountryListTableAdapter();
            taC.ClearBeforeFill = false;

            _data.CountryList.Clear();
            _data.CountryList.AddCountryListRow("Any country");
            taC.FillOrdered(_data.CountryList);

            cmbCountry.ItemsSource = _data.CountryList.DefaultView;
            cmbCountry.DisplayMemberPath = _data.CountryList.Columns["origincountry"].ToString();
            cmbCountry.SelectedValuePath = _data.CountryList.Columns["origincountry"].ToString();
            cmbCountry.SelectedIndex = 0;

            DataSet1TableAdapters.BrandTypeListTableAdapter taBT = new DataSet1TableAdapters.BrandTypeListTableAdapter();
            taBT.ClearBeforeFill = false;

            _data.BrandTypeList.Clear();
            _data.BrandTypeList.AddBrandTypeListRow("Any type");
            taBT.FillOrdered(_data.BrandTypeList);

            cmbType.ItemsSource = _data.BrandTypeList.DefaultView;
            cmbType.DisplayMemberPath = _data.BrandTypeList.Columns["type"].ToString();
            cmbType.SelectedValuePath = _data.BrandTypeList.Columns["type"].ToString();
            cmbType.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetupCombos();
            dgvBottles.DataContext = _data.BottleSearch;
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Tools.SearchBottles(_data, txtSearch.Text, (int)cmbBrand.SelectedValue, (int)cmbDrawer.SelectedValue,
                filterbyused, usedonly, (int)cmbTag.SelectedValue, cmbCountry.SelectedValue.ToString(),
                cmbType.SelectedValue.ToString());
        }

        private void btnUsedFilter_Click(object sender, RoutedEventArgs e)
        {
            if (filterbyused == false && usedonly == false)
            {
                filterbyused = true;
                usedonly = false;
                btnUsedFilter.Content = "Unused";
                btnSearch_Click(null, null);
                return;
            }

            if (filterbyused == true && usedonly == false)
            {
                filterbyused = true;
                usedonly = true;
                btnUsedFilter.Content = "Used";
                btnSearch_Click(null, null);
                return;
            }

            if (filterbyused == true && usedonly == true)
            {
                filterbyused = false;
                usedonly = false;
                btnUsedFilter.Content = "All";
                btnSearch_Click(null, null);
                return;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)dgvBottles.CurrentItem;
            System.Data.DataRow dr = drv.Row;
            DataSet1.BottleSearchRow row = (DataSet1.BottleSearchRow)dr;
            EditWindow f = new EditWindow(row.ID);
            f.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSearch_Click(null, null);
        }

        private void cmbBrand_DropDownClosed(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void cmbDrawer_DropDownClosed(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void btnNotes_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)dgvBottles.CurrentItem;
            System.Data.DataRow dr = drv.Row;
            DataSet1.BottleSearchRow row = (DataSet1.BottleSearchRow)dr;
            BottleNotes f = new BottleNotes(row.ID);
            f.ShowDialog();
        }

        private void btnBrandFancy_Click(object sender, RoutedEventArgs e)
        {
            BrandCollection f = new BrandCollection((int)cmbBrand.SelectedValue);
            f.ShowDialog();
        }

        private void btnTag_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)dgvBottles.CurrentItem;
            System.Data.DataRow dr = drv.Row;
            DataSet1.BottleSearchRow row = (DataSet1.BottleSearchRow)dr;
            TagEditor f = new TagEditor(row.ID);
            f.ShowDialog();
        }

        private void cmbTag_DropDownClosed(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void MultiTagConfirmed(int tagID)
        {
            DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();

            foreach (object bot in dgvBottles.SelectedItems)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)bot;
                System.Data.DataRow dr = drv.Row;
                DataSet1.BottleSearchRow row = (DataSet1.BottleSearchRow)dr;
                ta.ACT_AddTagToBottle(row.ID, tagID);
            }
        }

        private void btnMultiTag_Click(object sender, RoutedEventArgs e)
        {
            TagEditor f = new TagEditor();
            f.TagChosen += MultiTagConfirmed;
            f.ShowDialog();
        }

        private void mnuGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void mnuGrid_Opened(object sender, RoutedEventArgs e)
        {
            btnNotes.Visibility = dgvBottles.SelectedItems.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            btnEdit.Visibility = dgvBottles.SelectedItems.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            btnTag.Visibility = dgvBottles.SelectedItems.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            btnMultiTag.Visibility = dgvBottles.SelectedItems.Count == 1 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void txtTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Tools.SearchBottles(_data, txtTag.Text);
            }
        }
    }
}
