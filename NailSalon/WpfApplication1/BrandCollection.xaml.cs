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
    /// Interaction logic for BrandCollection.xaml
    /// </summary>
    public partial class BrandCollection : Window
    {
        private Models.Brand _mybrand = new Models.Brand();

        public BrandCollection()
        {
            InitializeComponent();
        }

        public BrandCollection(int BrandID)
        {
            InitializeComponent();
            _mybrand.ID = BrandID;
            _mybrand.LoadFromDB();
            SetupTabs();
        }

        private void SetupTabs()
        {
            foreach (Models.Bottle bt in _mybrand.Bottles)
            {
                TabItem tab = new TabItem();
                ucBottleView botv = new ucBottleView(bt);
                tab.Content = botv;
                tab.Header = bt.Name;
                tab.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                tab.VerticalContentAlignment = VerticalAlignment.Stretch;

                tbMain.Items.Add(tab);
            }
        }
    }
}
