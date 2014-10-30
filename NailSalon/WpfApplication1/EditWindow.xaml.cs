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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private DataSet1 _data = new DataSet1();
        private DataSet1.bottlesRow _myBottle;
        private bool _isNew = true;

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(int bottleID)
        {
            InitializeComponent();
            DataSet1TableAdapters.bottlesTableAdapter ta = new DataSet1TableAdapters.bottlesTableAdapter();
            ta.FillByID(_data.bottles, bottleID);
            if (_data.bottles.Rows.Count == 1)
            {
                _myBottle = (DataSet1.bottlesRow)_data.bottles.Rows[0];
                SetupReloaded();
                _isNew = false;
            }
            else
                _isNew = true;
        }

        private void EditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetupCombos();
            if (_isNew)
                btnIRLNotes.Visibility = Visibility.Hidden;
        }

        private void SetupCombos()
        {
            DataSet1TableAdapters.drawersTableAdapter taD = new DataSet1TableAdapters.drawersTableAdapter();
            taD.FillOrdered(_data.drawers);

            cmbDrawer.ItemsSource = _data.drawers.DefaultView;
            cmbDrawer.DisplayMemberPath = _data.drawers.Columns["DrawerName"].ToString();
            cmbDrawer.SelectedValuePath = _data.drawers.Columns["ID"].ToString();
            if (_isNew || _myBottle.IsSwatchDrawerNull())
                cmbDrawer.SelectedIndex = 0;
            else
                cmbDrawer.SelectedValue = _myBottle.SwatchDrawer;
        }

        private void SetupReloaded()
        {
            try
            {
                if (_myBottle.IsSwatchCoatsNull() == false)
                    txtCoats.Text = _myBottle.SwatchCoats.ToString();
                txtDesc.Text = _myBottle.Description;
                txtName.Text = _myBottle.Name;
                if (_myBottle.IsSwatchNotesNull() == false)
                    txtNotes.Text = _myBottle.SwatchNotes;
                cbxUsed.IsChecked = _myBottle.Used;
                if (_myBottle.IsDateAcquiredNull() == false)
                {
                    cbxAcDateKnown.IsChecked = true;
                    dpAcquired.SelectedDate = _myBottle.DateAcquired;
                }
                else
                {
                    cbxAcDateKnown.IsChecked = false;
                    dpAcquired.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            txtCoats.Clear();
            txtDesc.Clear();
            txtName.Clear();
            txtNotes.Clear();
            cmbDrawer.SelectedIndex = 0;
            cmbBrand.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.QueriesTableAdapter taQ = new DataSet1TableAdapters.QueriesTableAdapter();
            try
            {

                if (_isNew)
                {
                    if ((bool)cbxAcDateKnown.IsChecked)
                        taQ.INS_NewBottleWithDate(cmbBrand.SelectedBrandID, txtName.Text, txtDesc.Text, txtNotes.Text, int.Parse(txtCoats.Text),
                        (bool)cbxUsed.IsChecked, (int)cmbDrawer.SelectedValue, dpAcquired.SelectedDate);
                    else
                        taQ.INS_NewBottle(cmbBrand.SelectedBrandID, txtName.Text, txtDesc.Text, txtNotes.Text, int.Parse(txtCoats.Text),
                            (bool)cbxUsed.IsChecked, (int)cmbDrawer.SelectedValue);
                    Clear();
                }
                else
                {
                    if ((bool)cbxAcDateKnown.IsChecked)
                        taQ.UPD_BottleWithDate(txtName.Text, cmbBrand.SelectedBrandID, txtDesc.Text, txtNotes.Text, int.Parse(txtCoats.Text),
                        (bool)cbxUsed.IsChecked, (int)cmbDrawer.SelectedValue, dpAcquired.SelectedDate, _myBottle.ID);
                    else
                        taQ.UPD_Bottle(txtName.Text, cmbBrand.SelectedBrandID, txtDesc.Text, txtNotes.Text, int.Parse(txtCoats.Text),
                            (bool)cbxUsed.IsChecked, (int)cmbDrawer.SelectedValue, _myBottle.ID);
                    MessageBox.Show("Updated!");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbxAcDateKnown_Checked(object sender, RoutedEventArgs e)
        {
            dpAcquired.IsEnabled = true;
        }

        private void cbxAcDateKnown_Unchecked(object sender, RoutedEventArgs e)
        {
            dpAcquired.IsEnabled = false;
        }

        private void btnIRLNotes_Click(object sender, RoutedEventArgs e)
        {
            BottleNotes f = new BottleNotes(_myBottle.ID);
            f.ShowDialog();
        }

        private void btnTags_Click(object sender, RoutedEventArgs e)
        {
            TagEditor f = new TagEditor(_myBottle.ID);
            f.ShowDialog();
        }

        private void AddEditWindow_ContentRendered(object sender, EventArgs e)
        {
            if (_isNew == false)
                cmbBrand.SelectedBrandID = _myBottle.BrandID;

        }
    }
}
