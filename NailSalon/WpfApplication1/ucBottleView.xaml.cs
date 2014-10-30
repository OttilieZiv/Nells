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

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for ucBottleView.xaml
    /// </summary>
    public partial class ucBottleView : UserControl
    {
        private Models.Bottle _myBottle;

        public ucBottleView()
        {
            InitializeComponent();
        }

        public ucBottleView(Models.Bottle bottle)
        {
            InitializeComponent();
            _myBottle = bottle;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_myBottle != null)
                SetFields();
        }

        private void SetFields()
        {
            lblBrand.Content = _myBottle.BrandName;
            lblID.Content = "Bottle ID: " + _myBottle.ID.ToString();
            lblDrawer.Content = "Swatch stored in " + _myBottle.DrawerName + " drawer";
            lblName.Content = _myBottle.Name;
            lblDesc.Content = _myBottle.Description;
            lblSwatchNotes.Text = "Coats on swatch: " + _myBottle.SwatchCoats.ToString() +
                Environment.NewLine + _myBottle.SwatchNotes;
            if (_myBottle.DateAcquired.HasValue == false)
            {
                lblDateBought.Visibility = Visibility.Collapsed;
                lblUsed.Content = "I ";
            }
            else
            {
                string buydate = string.Format("{0:dd MMMM yyyy}", _myBottle.DateAcquired);
                lblDateBought.Content = "Purchased on " + buydate;
                lblUsed.Content = " and I ";
            }
            string usequalifier = _myBottle.Used ? "have" : "haven't";
            lblUsed.Content += usequalifier + " used this one IRL";
            if (_myBottle.Tags.Rows.Count == 0)
                lblTags.Visibility = Visibility.Collapsed;
            else
            {
                lblTags.Content = "Tags:";
                foreach (DataSet1.bottletagsRow t in _myBottle.Tags.Rows)
                {
                    lblTags.Content += " " + t.TagName + ",";
                }
                lblTags.Content = lblTags.Content.ToString().Substring(0, lblTags.Content.ToString().Length - 1);
            }

            dgNotes.DataContext = _myBottle.Notes;
        }
    }
}
