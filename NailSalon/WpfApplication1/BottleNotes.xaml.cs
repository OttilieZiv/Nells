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
    /// Interaction logic for BottleNotes.xaml
    /// </summary>
    public partial class BottleNotes : Window
    {
        private DataSet1 _data = new DataSet1();
        private int _myBottle = -1;
        private int _currentNoteID = -1;

        public BottleNotes()
        {
            InitializeComponent();
        }

        public BottleNotes(int bottle)
        {
            InitializeComponent();
            grdNewNote.Visibility = Visibility.Collapsed;
            _myBottle = bottle;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgNotes.DataContext = _data.BottleNotes;
        }

        private void dgNotes_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.BottleNotesTableAdapter ta = new DataSet1TableAdapters.BottleNotesTableAdapter();
            ta.FillByID(_data.BottleNotes, _myBottle);

            if (_data.BottleNotes.Rows.Count == 0)
            {
                grdNewNote.Visibility = Visibility.Visible;
                btnNewNote.Visibility = Visibility.Hidden;
            }
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            grdNewNote.Visibility = Visibility.Visible;
            btnNewNote.Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
            try
            {
                if (_currentNoteID == -1)
                {
                    ta.INS_BottleNote(_myBottle, DateTime.Now, txtNote.Text);
                }
                else
                {
                    ta.UPD_BottleNote(txtNote.Text, _currentNoteID);
                }
            }
            catch
            {
                MessageBox.Show("Ooops.");
            }
            txtNote.Clear();
            _currentNoteID = -1;
            grdNewNote.Visibility = Visibility.Collapsed;
            btnNewNote.Visibility = Visibility.Visible;

            //and reload the notes
            DataSet1TableAdapters.BottleNotesTableAdapter ta2 = new DataSet1TableAdapters.BottleNotesTableAdapter();
            ta2.FillByID(_data.BottleNotes, _myBottle);
        }

        private void btnCancelNote_Click(object sender, RoutedEventArgs e)
        {
            grdNewNote.Visibility = Visibility.Collapsed;
            btnNewNote.Visibility = Visibility.Visible;
        }

        private void btnEditNote_Click(object sender, RoutedEventArgs e)
        {
            DataSet1.BottleNotesRow row = (DataSet1.BottleNotesRow)((DataRow)((DataRowView)dgNotes.CurrentItem).Row);
            _currentNoteID = row.ID;
            txtNote.Text = row.NoteText;
            grdNewNote.Visibility = Visibility.Visible;
            btnNewNote.Visibility = Visibility.Hidden;
        }
    }
}
