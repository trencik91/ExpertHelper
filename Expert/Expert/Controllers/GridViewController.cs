using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class GridViewController
    {
        protected GridViewController()
        {

        }

        public static DataTable stworzTabeleWag(int idCelu, int idKryterium, Dictionary<String, int> listaIdKryteriow)
        {
            DataTable tabelaWag = new DataTable();
            List<Kryterium> listaPodkryteriow = KryteriumController.pobierzListePodkryteriow(idKryterium);

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = KryteriumController.pobierzKryterium(idKryterium, db, false);

            if (listaPodkryteriow.Count > 0)
            {
                tabelaWag.Columns.Add(kryterium.Nazwa);
                listaPodkryteriow.ForEach(d =>
                {
                    tabelaWag.Columns.Add(d.Nazwa); tabelaWag.Rows.Add(d.Nazwa);
                });

            }
            else
            {
                List<Kryterium> listaWariantow = KryteriumController.pobierzListeWariantow(idCelu);
                tabelaWag.Columns.Add(kryterium.Nazwa);

                listaWariantow.ForEach(w =>
                {
                    tabelaWag.Columns.Add(w.Nazwa); tabelaWag.Rows.Add(w.Nazwa);
                });
            }

            foreach (DataRow dr in tabelaWag.Rows)
            {
                foreach (DataColumn dc in tabelaWag.Columns)
                {
                    if (dr.Table.Columns[dc.ColumnName].Ordinal > 0)
                    {
                        int rowID = listaIdKryteriow[dr[0].ToString()];
                        int columnID = listaIdKryteriow[dc.ColumnName];
                        int glowneID = listaIdKryteriow[dr.Table.Columns[0].ColumnName.ToString()];

                        Waga waga = WagaController.pobierzWage(glowneID, rowID, columnID, db);

                        if (null != waga)
                        {
                            dr[dc] = waga.Waga1;
                        }
                        else if (rowID == columnID)
                        {
                            dr[dc] = 1;
                        }
                        else
                        {
                            dr[dc] = 0;
                        }
                    }
                }
            }

            return tabelaWag;
        }
    }
}
