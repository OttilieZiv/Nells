using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NailSalon.Models
{
    public class Manicure
    {
        public int maniID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public string NailLength { get; set; }
        public bool HasBeenWorn { get; set; }
        public string Verdict { get; set; }

        public DataSet2.manicureitemsDataTable items = new DataSet2.manicureitemsDataTable();

        public void LoadFromDataRow(DataSet2.manicuresRow row)
        {
            maniID = row.maniID;
            Name = row.Name;
            Type = row.Type;
            Notes = row.Notes;
            NailLength = row.NailLength;
            HasBeenWorn = row.HasBeenWorn;
            Verdict = row.Verdict;

            LoadItems();
        }

        public void LoadItems()
        {
            DataSet2TableAdapters.manicureitemsTableAdapter ta = new DataSet2TableAdapters.manicureitemsTableAdapter();
            ta.FillByMani(items, maniID);
        }

        public void Save()
        {
            DataSet2TableAdapters.QueriesTableAdapter taQ = new DataSet2TableAdapters.QueriesTableAdapter();
            DataSet2TableAdapters.manicureitemsTableAdapter taMI = new DataSet2TableAdapters.manicureitemsTableAdapter();
            int? newmaniID = 0;
            if (maniID == -1)
            {
                taQ.INS_NewManicure(out newmaniID, Name, Type, Notes, NailLength, HasBeenWorn, Verdict);
                foreach (DataSet2.manicureitemsRow r in items)
                { r.ManiID = (int)newmaniID; }
            }
            else
                taQ.UPD_UpdateManicure(Name, Type, Notes, NailLength, HasBeenWorn, Verdict, maniID);

            
            taMI.Update(items);
        }
    }
}
