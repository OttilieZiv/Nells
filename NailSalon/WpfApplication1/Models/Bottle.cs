using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NailSalon.Models
{
   public class Bottle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public string Description { get; set; }
        public string SwatchNotes { get; set; }
        public int SwatchCoats { get; set; }
        public int SwatchDrawer { get; set; }
        public bool Used { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string BrandName { get; set; }
        public string DrawerName { get; set; }

        public DataSet1.notesDataTable Notes = new DataSet1.notesDataTable();
        public DataSet1.bottletagsDataTable Tags = new DataSet1.bottletagsDataTable();

        public void LoadFromDB()
        {
            try
            {
                DataSet1 temp = new DataSet1();
                DataSet1TableAdapters.bottlesTableAdapter taBo = new DataSet1TableAdapters.bottlesTableAdapter();
                taBo.FillByID(temp.bottles, ID);
                DataSet1.bottlesRow row = (DataSet1.bottlesRow)temp.bottles.Rows[0];
                LoadFromDataRow(row);
                LoadBrand(temp);
                LoadDrawer(temp);
                LoadNotes();
                LoadTags();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }

        public void LoadFromDataRow(DataSet1.bottlesRow row)
        {
            try
            {
                Name = row.Name;
                BrandID = row.BrandID;
                Description = row.Description;
                SwatchNotes = row.SwatchNotes;
                SwatchCoats = row.IsSwatchCoatsNull() ? 0 : row.SwatchCoats;
                SwatchDrawer = row.IsSwatchDrawerNull() ? 0 : row.SwatchDrawer;
                Used = row.Used;
                if (row.IsDateAcquiredNull() == false)
                    DateAcquired = row.DateAcquired;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadBrand(DataSet1 data)
        {
            data.brands.Clear();
            DataSet1TableAdapters.brandsTableAdapter taBr = new DataSet1TableAdapters.brandsTableAdapter();
            taBr.FillByID(data.brands, BrandID);
            DataSet1.brandsRow brrow = (DataSet1.brandsRow)data.brands.Rows[0];
            BrandName = brrow.Name;
        }

        public void LoadDrawer(DataSet1 data)
        {
            data.drawers.Clear();
            DataSet1TableAdapters.drawersTableAdapter taDr = new DataSet1TableAdapters.drawersTableAdapter();
            taDr.FillByID(data.drawers, SwatchDrawer);
            DataSet1.drawersRow drrow = (DataSet1.drawersRow)data.drawers.Rows[0];
            DrawerName = drrow.DrawerName;
        }

        public void LoadNotes()
        {
            DataSet1TableAdapters.notesTableAdapter taN = new DataSet1TableAdapters.notesTableAdapter();
            taN.FillByBottle(Notes, ID);
        }

        public void LoadTags()
        {
            Tags.Clear();
            DataSet1TableAdapters.bottletagsTableAdapter taBt = new DataSet1TableAdapters.bottletagsTableAdapter();
            taBt.FillByBottleID(Tags, ID);
        }
    }
}
