using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;

namespace NailSalon
{
    public class Tools
    {
        public delegate void IntegerSelectedHandler(int selection);

        public static int Count()
        {
            int result = 0;
            try
            {
                DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
                result = int.Parse(ta.TotalCount().ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static int UsedCount()
        {
            int result = 0;
            try
            {
                DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
                result = int.Parse(ta.Used().ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static int UnusedCount()
        {
            int result = 0;
            try
            {
                DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
                result = int.Parse(ta.TotalCount().ToString()) - int.Parse(ta.Used().ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static int UsedPercentage()
        {
            int result = 0;
            try
            {
                DataSet1TableAdapters.QueriesTableAdapter ta = new DataSet1TableAdapters.QueriesTableAdapter();
                decimal used = decimal.Parse(ta.Used().ToString());
                decimal total = decimal.Parse(ta.TotalCount().ToString());
                result = (int)(decimal.Round((used / total) * 100, 0));
            }
            catch (Exception ex)
            {
               System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static int SearchBottles(DataSet1 data, string search, int brand, int drawer, bool filterbyused, bool used, 
            int tag, string country, string type)
        {
            int result = 0;

            //first a bit of twattery made necessary by the rubbishness of mysql
            search = "%" + search + "%";
            DataSet1TableAdapters.BottleSearchTableAdapter ta = new DataSet1TableAdapters.BottleSearchTableAdapter();
            result = ta.FillBySearch(data.BottleSearch, search, brand, drawer, filterbyused, used, tag, country, type);

            return result;
        }

        public static int SearchBottles(DataSet1 data, int tagtype)
        {
            int result = 0;

            DataSet1TableAdapters.BottleSearchTableAdapter ta = new DataSet1TableAdapters.BottleSearchTableAdapter();
            result = ta.FillByLackOfTag(data.BottleSearch, tagtype);

            return result;
        }

        public static int SearchBottles(DataSet1 data, string tagsearch)
        {
            int result = 0;
            DataSet1TableAdapters.BottleSearchTableAdapter ta = new DataSet1TableAdapters.BottleSearchTableAdapter();
            ta.FillByTagSearchBasic(data.BottleSearch, tagsearch);
            return result;
        }

        public static BitmapImage ImageFromByteArray(byte[] imagebits)
        {
            MemoryStream mstr = new MemoryStream();
            mstr.Write(imagebits, 0, imagebits.Length);
            mstr.Position = 0;

            System.Drawing.Image img = System.Drawing.Image.FromStream(mstr);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream mstr2 = new MemoryStream();
            img.Save(mstr2, System.Drawing.Imaging.ImageFormat.Bmp);
            mstr2.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = mstr2;
            bi.EndInit();

            return bi;
        }

        public static byte[] ConvertImageForStorage(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            return data;
        }
    }
}
