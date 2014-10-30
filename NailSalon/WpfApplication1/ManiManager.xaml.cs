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
using NailSalon.Models;

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for ManiManager.xaml
    /// </summary>
    public partial class ManiManager : Window
    {
        public ManiManager()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet2 temp = new DataSet2();
            DataSet2TableAdapters.manicuresTableAdapter ta = new DataSet2TableAdapters.manicuresTableAdapter();
            ta.Fill(temp.manicures);

            foreach (DataSet2.manicuresRow r in temp.manicures.Rows)
            {
                AddManiTab(r);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = new TabItem();
            ucManiEditor uc = new ucManiEditor();
            uc.ManiSaved += ManiEditCompleted;
            tab.Content = uc;
            tab.Header = "New mani";
            tab.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tab.VerticalContentAlignment = VerticalAlignment.Stretch;

            tbManis.Items.Add(tab);
            tab.Focus();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TabItem tb = (TabItem)tbManis.SelectedItem;
            ucManiView view = (ucManiView)tbManis.SelectedContent;
            Manicure mani = view.MyMani;

            ucManiEditor edit = new ucManiEditor(mani);
            edit.ManiSaved += ManiEditCompleted;
            tb.Content = edit;
            tb.Header = "Editing...";
        }

        private void AddManiTab(DataSet2.manicuresRow maniRow)
        {
            Manicure mani = new Manicure();
            mani.LoadFromDataRow(maniRow);
            AddManiTab(mani);
        }

        private void AddManiTab(Manicure mani)
        {
            TabItem tab = new TabItem();
            ucManiView uc = new ucManiView(mani);
            tab.Content = uc;
            tab.Header = mani.Name;
            tab.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tab.VerticalContentAlignment = VerticalAlignment.Stretch;

            tbManis.Items.Add(tab);
        }

        private void ManiEditCompleted(Manicure mani)
        {
            //TabItem tb = (TabItem)tbManis.Items.CurrentItem;
            tbManis.Items.Remove(tbManis.SelectedItem);
            AddManiTab(mani);
        }
    }
}
