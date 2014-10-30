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
    /// Interaction logic for ucManiView.xaml
    /// </summary>
    public partial class ucManiView : UserControl
    {
        #region Constructors

        public ucManiView()
        {
            InitializeComponent();
        }

        public ucManiView(Manicure mani)
        {
            InitializeComponent();
            MyMani = mani;
            SetLabels();
        }

        #endregion

        #region Properties

        public Manicure MyMani
        { get; set; }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgItems.DataContext = MyMani.items;
        }

        private void SetLabels()
        {
            lblName.Content = MyMani.Name;
            lblWorn.Content = MyMani.HasBeenWorn ? "Worn it" : "Not worn yet";
            lblType.Content = "Type: " + MyMani.Type;
            lblLength.Content = "Nail length: " + MyMani.NailLength;
            lblNotes.Text = MyMani.Notes;
            if (MyMani.Verdict != null && MyMani.Verdict.Length > 0)
                lblVerdict.Text = MyMani.Verdict;
            else
                dkVerdict.Visibility = Visibility.Collapsed;
        }

        private void btnPics_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer img = new ImageViewer(MyMani);
            img.Show();
        }
    }
}
