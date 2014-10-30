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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetLabels();
        }

        private void SetLabels()
        {
            lblCount.Content = "Count: " + Tools.Count().ToString();
            lblUsed.Content = Tools.UsedCount().ToString() + " - " + Tools.UsedPercentage().ToString() + "%";
            lblUnused.Content = Tools.UnusedCount().ToString() + " - " + (100 - Tools.UsedPercentage()).ToString() + "%";
            prgUsed.Value = Tools.UsedPercentage();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditWindow f = new EditWindow();
            f.Closed += ChildForm_Closed;
            f.Show();
        }

        private void ChildForm_Closed(object sender, EventArgs e)
        {
            SetLabels();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            StashBrowser f = new StashBrowser();
            f.Closed += ChildForm_Closed;
            f.Show();
        }

        private void btnOrdered_Click(object sender, RoutedEventArgs e)
        {
            OrderBrowser f = new OrderBrowser();
            f.Closed += ChildForm_Closed;
            f.Show();
        }

        private void btnGeekOut_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer f = new ReportViewer();
            f.Show();
        }

        private void btnLemmings_Click(object sender, RoutedEventArgs e)
        {
            LemmingBrowser f = new LemmingBrowser();
            f.Closed += ChildForm_Closed;
            f.Show();
        }

        private void btnManiPlan_Click(object sender, RoutedEventArgs e)
        {
            ManiManager f = new ManiManager();
            f.Show();
        }
    }
}
