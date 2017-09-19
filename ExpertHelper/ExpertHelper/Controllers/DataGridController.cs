using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertHelper
{
    class DataGridController
    {
        protected DataGridController()
        {

        }

        public static DataTable stworzTabeleWag(int idCelu, int idKryterium)
        {
            DataTable tabelaWag = new DataTable();
            List<Kryterium> listaPodkryteriow = KryteriumController.pobierzListePodkryteriow(idKryterium);
            Kryterium kryterium = KryteriumController.pobierzKryterium(idKryterium);

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
                tabelaWag.Columns.Add("Wariant");
                tabelaWag.Columns.Add(kryterium.Nazwa);

                listaWariantow.ForEach(w =>
                {
                    tabelaWag.Rows.Add(w.Nazwa);
                });
            }

            return tabelaWag;
        }
    }
}
