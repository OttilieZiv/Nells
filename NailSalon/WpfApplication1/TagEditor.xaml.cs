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
    /// Interaction logic for TagEditor.xaml
    /// </summary>
    public partial class TagEditor : Window
    {
        private Models.Bottle _myBottle = new Models.Bottle();
        private DataSet1 _data = new DataSet1();
        private bool _finishedLoading = false;

        public TagEditor()
        {
            InitializeComponent();
            lblCurrent.Visibility = Visibility.Collapsed;
            wrpTagButtons.Visibility = Visibility.Collapsed;
            this.SizeToContent = SizeToContent.Height;
            EditingBottle = false;
        }

        public TagEditor(int bottleID)
        {
            InitializeComponent();
            _myBottle.ID = bottleID;
            _myBottle.LoadFromDB();
            EditingBottle = true;
        }

        public bool EditingBottle { get; set; }

        public event Tools.IntegerSelectedHandler TagChosen;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetupTypeCombo(true);
            SetupTagCombo(true);
            foreach (DataSet1.bottletagsRow r in _myBottle.Tags)
            {
                AddTagRemoveButton(r.ID, r.TagName);
            }
            _finishedLoading = true;
        }

        private void SetupTypeCombo(bool SetToTop)
        {
            DataSet1TableAdapters.bottletagtypesTableAdapter ta2 = new DataSet1TableAdapters.bottletagtypesTableAdapter();
            ta2.ClearBeforeFill = false;
            _data.bottletagtypes.Clear();
            _data.bottletagtypes.AddbottletagtypesRow(-1, "Any");
            ta2.FillOrdered(_data.bottletagtypes);

            cmbTagType.ItemsSource = _data.bottletagtypes.DefaultView;
            cmbTagType.DisplayMemberPath = _data.bottletagtypes.Columns["Type"].ToString();
            cmbTagType.SelectedValuePath = _data.bottletagtypes.Columns["ID"].ToString();
            if (SetToTop)
                cmbTagType.SelectedIndex = 0;
        }

        private void SetupTagCombo(Boolean SetToTop)
        {            
            DataSet1TableAdapters.bottletagsTableAdapter ta = new DataSet1TableAdapters.bottletagsTableAdapter();
            ta.ClearBeforeFill = false;
            _data.bottletags.Clear();
            _data.bottletags.AddbottletagsRow(-1, "Select...", 0);
            _data.bottletags.AddbottletagsRow(0, "Add new...", 0);
            if ((int)cmbTagType.SelectedValue == -1)
                ta.FillOrdered(_data.bottletags);
            else
                ta.FillByType(_data.bottletags, (int)cmbTagType.SelectedValue);

            cmbTag.ItemsSource = _data.bottletags.DefaultView;
            cmbTag.DisplayMemberPath = _data.bottletags.Columns["TagName"].ToString();
            cmbTag.SelectedValuePath = _data.bottletags.Columns["ID"].ToString();
            if (SetToTop)
                cmbTag.SelectedIndex = 0;
        }

        private void AddTagRemoveButton(int tagID, string tagName)
        {
            Button butt = new Button();
            butt.Content = tagName + "  x";
            butt.Tag = tagID;
            butt.HorizontalAlignment = HorizontalAlignment.Left;
            butt.Click += btnRemoveTag_Click;
            wrpTagButtons.Children.Add(butt);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (EditingBottle)
            {
                DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
                ta.ACT_AddTagToBottle(_myBottle.ID, (int)cmbTag.SelectedValue);
                AddTagRemoveButton((int)cmbTag.SelectedValue, cmbTag.Text);
            }

            if (TagChosen != null)
            {
                TagChosen((int)cmbTag.SelectedValue);
                Close();
            }
        }

        private void btnRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
            ta.ACT_RemoveTagFromBottle(_myBottle.ID, (int)butt.Tag);
            _myBottle.LoadTags();
            butt.Visibility = Visibility.Collapsed;
        }

        private void cmbTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((int)cmbTag.SelectedValue)
            {
                case -1:
                    btnAdd.IsEnabled = false;
                    break;
                case 0:
                    btnAdd.IsEnabled = false;
                    pnlCombos.Visibility = Visibility.Hidden;
                    txtNewTag.Visibility = Visibility.Visible;
                    txtNewTag.Focus();
                    break;
                default:
                    string filter = "ID=" + cmbTag.SelectedValue.ToString();
                    DataRow[] selr = _myBottle.Tags.Select(filter);
                    btnAdd.IsEnabled = selr.Length == 0;
                    break;
            }
        }

        private void txtNewTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNewTag.Text.Length > 0 && e.Key == Key.Enter)
            {
                //chuck it in the db
                DataSet1TableAdapters.bottletagsTableAdapter ta = new DataSet1TableAdapters.bottletagsTableAdapter();
                if ((int)cmbTagType.SelectedValue == -1)
                    ta.Insert(txtNewTag.Text, null);
                else
                    ta.Insert(txtNewTag.Text, (int)cmbTagType.SelectedValue);
                //reload the data
                cmbTag.SelectionChanged -= cmbTag_SelectionChanged;
                SetupTagCombo(false);
                //find the newly added thing
                string filter = "tagname='" + txtNewTag.Text + "'";
                DataRow[] selrow = _data.bottletags.Select(filter);
                DataSet1.bottletagsRow r = (DataSet1.bottletagsRow)selrow[0];
                //and set the combo to the new value
                pnlCombos.Visibility = Visibility.Visible;
                cmbTag.SelectedValue = r.ID;
                cmbTag.SelectionChanged += cmbTag_SelectionChanged;
                btnAdd.IsEnabled = true;
                //and finally, hide the textbox
                txtNewTag.Clear();
                txtNewTag.Visibility = Visibility.Hidden;
            }
        }

        private void cmbTagType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_finishedLoading)
            {
                cmbTag.SelectionChanged -= cmbTag_SelectionChanged;
                SetupTagCombo(true);
                cmbTag.SelectionChanged += cmbTag_SelectionChanged;
            }
        }
    }
}
