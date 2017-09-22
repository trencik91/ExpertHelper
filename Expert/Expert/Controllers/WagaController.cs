using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class WagaController
    {
        protected WagaController()
        {

        }

        public static void dodajWage(int idKryteriumJeden, int idKryteriumDwa, decimal wartosc, ExpertHelperDataContext db)
        {
            Waga waga = new Waga
            {
                Kryterium1 = idKryteriumJeden,
                Kryterium2 = idKryteriumDwa,
                Waga1 = wartosc
            };

            db.Wagas.InsertOnSubmit(waga);
            db.SubmitChanges();
        }

        public static void edytujWage(int idKryteriumJeden, int idKryteriumDwa, decimal wartosc)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Waga waga = pobierzWage(idKryteriumJeden, idKryteriumDwa, db);

            if (null != waga)
            {
                waga.Waga1 = wartosc;

                db.SubmitChanges();
            }
        }

        public static Waga pobierzWage(int idKryteriumJeden, int idKryteriumDwa, ExpertHelperDataContext db)
        {
            var waga = (from w in db.Wagas
                        where w.Kryterium1 == idKryteriumJeden && w.Kryterium2 == idKryteriumDwa
                        select w).FirstOrDefault();

            return waga;
        }

        public static Waga stworzWage(int idKryteriumJeden, int idKryteriumDwa, decimal wartosc)
        {
            Waga waga = new Waga();
            waga.Kryterium1 = idKryteriumJeden;
            waga.Kryterium2 = idKryteriumDwa;
            waga.Waga1 = wartosc;

            return waga;
        }
    }
}
