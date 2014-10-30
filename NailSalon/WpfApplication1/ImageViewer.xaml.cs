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
using System.IO;
using NailSalon.Models;

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : Window
    {
        #region Variables

        private DataSet2 _data = new DataSet2();
        Manicure _mymani = null;
        Bottle _mybottle = null;

        #endregion

        #region Constructors

        public ImageViewer()
        {
            InitializeComponent();
        }

        public ImageViewer(Manicure mani)
        {
            InitializeComponent();
            LoadImages(mani);
            _mymani = mani;
        }

        public ImageViewer(Bottle bottle)
        {
            InitializeComponent();
            LoadImages(bottle);
            _mybottle = bottle;
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataSet2.picturesRow r in _data.pictures.Rows)
            {
                AddImageTile(r);
            }
        }

        private void LoadImages(Manicure mani)
        {
            DataSet2TableAdapters.picturesTableAdapter ta = new DataSet2TableAdapters.picturesTableAdapter();
            ta.FillByMani(_data.pictures, mani.maniID);
        }

        private void LoadImages(Bottle bottle)
        {
            DataSet2TableAdapters.picturesTableAdapter ta = new DataSet2TableAdapters.picturesTableAdapter();
            ta.FillByBottle(_data.pictures, bottle.ID);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fd = new Microsoft.Win32.OpenFileDialog();
            fd.ShowDialog();

            byte[] imagebits = Tools.ConvertImageForStorage(fd.FileName);

            DataSet2TableAdapters.QueriesTableAdapter taQ = new DataSet2TableAdapters.QueriesTableAdapter();

            int? newpicID = 0;

            if (_mymani != null)
                taQ.INS_NewManiPic(out newpicID, imagebits, _mymani.maniID);

            if (_mybottle != null)
                taQ.INS_NewBottlePic(out newpicID, imagebits, _mybottle.ID);

            BitmapImage bi = Tools.ImageFromByteArray(imagebits);

            AddImageTile(bi, (int)newpicID);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddImageTile(DataSet2.picturesRow picRow)
        {
            BitmapImage pic = Tools.ImageFromByteArray(picRow.Image);
            AddImageTile(pic, picRow.picID);
        }

        private void AddImageTile(BitmapImage pic, int picID)
        {
            BrushConverter conv = new BrushConverter();

            Border outerB = new Border();
            outerB.BorderThickness = new Thickness(2, 2, 2, 2);
            outerB.BorderBrush = conv.ConvertFromString("Black") as Brush;
            outerB.CornerRadius = new CornerRadius(5);
            outerB.Margin = new Thickness(5);

            Border innerB = new Border();
            innerB.BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5);
            innerB.BorderBrush = conv.ConvertFromString("White") as Brush;
            innerB.CornerRadius = new CornerRadius(4);
            innerB.Height = 150;
            innerB.Width = pic.Width / (pic.Height / 150);
            innerB.Tag = picID;
            innerB.MouseDown += new MouseButtonEventHandler(pic_MouseDown);

            ImageBrush ibox = new ImageBrush();
            ibox.ImageSource = pic;

            outerB.Child = innerB;
            innerB.Background = ibox;

            wrpImg.Children.Add(outerB);
        }

        private void pic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border b = (Border)sender;
            string stuff = "Pic ID: " + b.Tag.ToString();
            MessageBox.Show(stuff);
        }
    }
}
