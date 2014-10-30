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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NailSalon.Usercontrols
{
    /// <summary>
    /// Interaction logic for ucBrandPickerWithAdd.xaml
    /// </summary>
    public partial class ucBrandPickerWithAdd : UserControl
    {
        #region Fields

        private DataSet1 _data = new DataSet1();
        private int _currentBrand = -1;

        #endregion

        #region Constructors

        public ucBrandPickerWithAdd()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int SelectedIndex
        {
            get { return cmbBrand.SelectedIndex; }
            set { cmbBrand.SelectedIndex = value; }
        }

        public int SelectedBrandID
        {
            get { return (int)cmbBrand.SelectedValue; }
            set
            {
                _currentBrand = value;
                cmbBrand.SelectedValue = value;
            }
        }

        public string SelectedBrandName
        {
            get { return cmbBrand.Text; }
        }

        #endregion

        #region Methods

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetUpCombo();
        }

        private void SetUpCombo()
        {
            DataSet1TableAdapters.brandsTableAdapter taBr = new DataSet1TableAdapters.brandsTableAdapter();
            taBr.ClearBeforeFill = false;

            _data.brands.Clear();
            _data.brands.AddbrandsRow(-1, "Select");
            _data.brands.AddbrandsRow(0, "Add new...");
            taBr.FillOrdered(_data.brands);

            cmbBrand.ItemsSource = _data.brands.DefaultView;
            cmbBrand.DisplayMemberPath = _data.brands.Columns["Name"].ToString();
            cmbBrand.SelectedValuePath = _data.brands.Columns["ID"].ToString();

            cmbBrand.SelectedIndex = 0;
        }

        private void cmbNewBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNewBrand.Text.Length > 0 && e.Key == Key.Enter)
            {
                //chuck it in the db
                DataSet1TableAdapters.brandsTableAdapter ta = new DataSet1TableAdapters.brandsTableAdapter();
                ta.Insert(txtNewBrand.Text);

                //reload the data
                cmbBrand.SelectionChanged -= cmbBrand_SelectionChanged;
                SetUpCombo();

                //find the newly added thing
                string filter = "Name='" + txtNewBrand.Text + "'";
                DataRow[] selrow = _data.brands.Select(filter);
                DataSet1.brandsRow r = (DataSet1.brandsRow)selrow[0];

                //and set the combo to the new value
                cmbBrand.Visibility = Visibility.Visible;
                cmbBrand.SelectedValue = r.ID;
                cmbBrand.SelectionChanged += cmbBrand_SelectionChanged;

                //and finally, hide the textbox
                txtNewBrand.Clear();
                txtNewBrand.Visibility = Visibility.Hidden;
            }
        }

        private void cmbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((int)cmbBrand.SelectedValue)
            {
                case -1:
                    break;
                case 0:
                    cmbBrand.Visibility = Visibility.Hidden;
                    txtNewBrand.Visibility = Visibility.Visible;
                    txtNewBrand.Focus();
                    break;
                default:
                    string filter = "ID=" + cmbBrand.SelectedValue.ToString();
                    DataRow[] selr = _data.brands.Select(filter);
                    break;
            }
        }

        #endregion
    }
}
