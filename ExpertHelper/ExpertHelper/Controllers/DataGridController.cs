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

        public static DataTable stworzTabeleWag(int idKryterium)
        {
            DataTable tabelaWag = new DataTable();
            List<Kryterium> listaDzieci = KryteriumController.pobierzListeDzieci(idKryterium);
            Kryterium ojciec = KryteriumController.pobierzKryterium(idKryterium);

            tabelaWag.Columns.Add(ojciec.Nazwa);

            foreach (Kryterium k in listaDzieci)
            {
                tabelaWag.Columns.Add(k.Nazwa);
                tabelaWag.Rows.Add(k.Nazwa);
            }

            return tabelaWag;
        }
    }
}
