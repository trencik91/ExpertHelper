using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Controllers
{
    class ObliczeniaController
    {
        protected ObliczeniaController()
        {

        }

        public static Wynik stworzObliczenia(int idCelu, int idKryterium, DataTable tablicaWag)
        {
            StringBuilder sb = new StringBuilder();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            foreach (DataRow dr in tablicaWag.Rows)
            {
                sb.Append(stworzWierszObliczen(dr));
                sb.Append("\n");
            }

            Obliczenia obliczenia = new Obliczenia()
            {
                ID_Celu = idCelu,
                ID_Kryterium = idKryterium,
                Wyniki = sb.ToString()
            };

            db.Obliczenias.InsertOnSubmit(obliczenia);
            db.SubmitChanges();

            return null;
        }

        private static String stworzWierszObliczen(DataRow dr)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn dc in dr.Table.Columns)
            {
                sb.Append(dr[dc].ToString());
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
