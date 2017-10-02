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

        public static void dodajListeWag(IEnumerable<Waga> listaWag)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            foreach (Waga w in listaWag)
            {
                int idWagi = sprawdzCzyWagaIstnieje(w, db);

                if (idWagi == 0)
                {
                    db.Wagas.InsertOnSubmit(w);
                }
                else
                {
                    Waga waga = pobierzWage(idWagi, db);

                    if (null != waga)
                    {
                        waga.Waga1 = w.Waga1;
                    }
                }
            }

            db.SubmitChanges();
        }

        public static void dodajWage(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, double wartosc, ExpertHelperDataContext db)
        {
            Waga waga = new Waga
            {
                KryteriumGlowne = kryteriumGlowne,
                Kryterium1 = idKryteriumJeden,
                Kryterium2 = idKryteriumDwa,
                Waga1 = wartosc
            };

            db.Wagas.InsertOnSubmit(waga);
            db.SubmitChanges();
        }

        public static void edytujWage(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, double wartosc)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Waga waga = pobierzWage(kryteriumGlowne, idKryteriumJeden, idKryteriumDwa, db);

            if (null != waga)
            {
                waga.Waga1 = wartosc;

                db.SubmitChanges();
            }
        }

        public static Waga pobierzWage(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, ExpertHelperDataContext db)
        {
            var waga = (from w in db.Wagas
                        where w.KryteriumGlowne == kryteriumGlowne && w.Kryterium1 == idKryteriumJeden && w.Kryterium2 == idKryteriumDwa
                        select w).FirstOrDefault();

            return waga;
        }

        public static Waga stworzWage(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, double wartosc)
        {
            Waga waga = new Waga();
            waga.KryteriumGlowne = kryteriumGlowne;
            waga.Kryterium1 = idKryteriumJeden;
            waga.Kryterium2 = idKryteriumDwa;
            waga.Waga1 = wartosc;

            return waga;
        }

        public static List<Waga> pobierzWszystkieWagi(ExpertHelperDataContext db)
        {
            List<Waga> listaWag = new List<Waga>();

            var lista = from w in db.Wagas
                        select w;

            foreach (Waga waga in lista)
            {
                Waga w = new Waga
                {
                    ID = waga.ID,
                    KryteriumGlowne = waga.KryteriumGlowne,
                    Kryterium1 = waga.Kryterium1,
                    Kryterium2 = waga.Kryterium2,
                    Waga1 = waga.Waga1
                };

                listaWag.Add(w);
            }

            return listaWag;
        }

        public static Waga pobierzWage(int idWagi, ExpertHelperDataContext db)
        {
            var waga = (from w in db.Wagas
                        where w.ID == idWagi
                        select w).First();

            if (null != waga)
            {
                return waga;
            }

            return null;
        }

        public static int sprawdzCzyWagaIstnieje(Waga waga, ExpertHelperDataContext db)
        {
            var idWagi = (from w in db.Wagas
                          where w.KryteriumGlowne == waga.KryteriumGlowne && w.Kryterium1 == waga.Kryterium1 && w.Kryterium2 == waga.Kryterium2
                          select w).First();

            if (null != idWagi)
            {
                return idWagi.ID;
            }

            return 0;
        }
    }
}
