using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NailSalon.Models
{
   public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Bottle> Bottles = new List<Bottle>();

        public void LoadFromDB()
        {
            try
            {
                DataSet1 temp = new DataSet1();
                DataSet1TableAdapters.brandsTableAdapter taBr = new DataSet1TableAdapters.brandsTableAdapter();
                DataSet1TableAdapters.bottlesTableAdapter taBo = new DataSet1TableAdapters.bottlesTableAdapter();
                taBr.FillByID(temp.brands, ID);
                taBo.FillByBrand(temp.bottles, ID);

                DataSet1.brandsRow brow = (DataSet1.brandsRow)temp.brands.Rows[0];
                Name = brow.Name;

                foreach (DataSet1.bottlesRow boro in temp.bottles.Rows)
                {
                    Bottle bot = new Bottle { ID = boro.ID, BrandName = Name };
                    bot.LoadFromDataRow(boro);
                    bot.LoadDrawer(temp);
                    bot.LoadNotes();
                    bot.LoadTags();
                    Bottles.Add(bot);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
