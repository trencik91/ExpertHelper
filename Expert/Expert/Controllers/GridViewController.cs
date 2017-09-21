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

        public static DataTable stworzTabeleWag(int idCelu, int idKryterium)
        {
            DataTable tabelaWag = new DataTable();
            List<Kryterium> listaPodkryteriow = KryteriumController.pobierzListePodkryteriow(idKryterium);
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = KryteriumController.pobierzKryterium(idKryterium, db);

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
                List<Wariant> listaWariantow = WariantController.pobierzListeWariantow(idCelu);
                tabelaWag.Columns.Add(kryterium.Nazwa);

                listaWariantow.ForEach(w =>
                {
                    tabelaWag.Columns.Add(w.Nazwa); tabelaWag.Rows.Add(w.Nazwa);
                });
            }

            return tabelaWag;
        }
    }
}
