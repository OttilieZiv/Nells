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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NailSalon.Models;

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for ucManiEditor.xaml
    /// </summary>
    public partial class ucManiEditor : UserControl
    {
        #region Fields

        private DataSet1 _comboData = new DataSet1();

        #endregion

        #region Constructors

        public ucManiEditor()
        {
            InitializeComponent();
            MyMani = new Manicure();
            MyMani.maniID = -1;
        }

        public ucManiEditor(Manicure mani)
        {
            InitializeComponent();
            MyMani = mani;
            SetFields();
        }

        #endregion

        #region Properties

        public Manicure MyMani
        { get; set; }

        #endregion

        #region Events

        public event StashEvents.CancelHandler Cancel;

        public event StashEvents.ManiEventHandler ManiSaved;

        #endregion

        #region Methods

        private void SetupCombo()
        {
            DataSet1TableAdapters.brandsTableAdapter taBr = new DataSet1TableAdapters.brandsTableAdapter();
            taBr.ClearBeforeFill = false;

            _comboData.brands.Clear();
            _comboData.brands.AddbrandsRow(-1, "Any brand");
            taBr.FillOrdered(_comboData.brands);

            cmbBrand.ItemsSource = _comboData.brands.DefaultView;
            cmbBrand.DisplayMemberPath = _comboData.brands.Columns["Name"].ToString();
            cmbBrand.SelectedValuePath = _comboData.brands.Columns["ID"].ToString();
            cmbBrand.SelectedIndex = 0;
        }

        private void SetFields()
        {
            txtName.Text = MyMani.Name;
            txtType.Text = MyMani.Type;
            txtNotes.Text = MyMani.Notes;
            txtLength.Text = MyMani.NailLength;
            cbxWorn.IsChecked = MyMani.HasBeenWorn;
            txtVerdict.Text = MyMani.Verdict;
        }

        private void ReturnFields()
        {
            MyMani.Name = txtName.Text;
            MyMani.Type = txtType.Text;
            MyMani.Notes = txtNotes.Text;
            MyMani.NailLength = txtLength.Text;
            MyMani.Verdict = txtVerdict.Text;
            MyMani.HasBeenWorn = (bool)cbxWorn.IsChecked;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ReturnFields();
            MyMani.Save();
            if (ManiSaved != null)
                ManiSaved(MyMani);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Cancel != null)
                Cancel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgManiItems.DataContext = MyMani.items;
            dgPickBottle.DataContext = _comboData.BottleSearch;
            dgPickBottle.Height = 250;
            dgPickBottle.Visibility = Visibility.Collapsed;
            SetupCombo();
        }

        private void btnClearItems_Click(object sender, RoutedEventArgs e)
        {
            MyMani.items.Clear();
        }

        private void txtBottleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            int results = 0;
            if (e.Key == Key.Enter)
                results = Tools.SearchBottles(_comboData, txtBottleSearch.Text, (int)cmbBrand.SelectedValue, -1, false, false,
                    -1, "Any country", "Any type");

            if (results > 0)
                dgPickBottle.Visibility = Visibility.Visible;
        }

        private void dgPickBottle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)dgPickBottle.CurrentItem;
            if (drv != null)
            {
                System.Data.DataRow dr = drv.Row;
                DataSet1.BottleSearchRow row = (DataSet1.BottleSearchRow)dr;

                MyMani.items.AddmanicureitemsRow(MyMani.maniID, row.ID, "", 0, row.brand, row.name);
            }
        }

        private void btnCollapseSearch_Click(object sender, RoutedEventArgs e)
        {
            dgPickBottle.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
