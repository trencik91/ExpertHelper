using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class WynikController
    {
        protected WynikController()
        {

        }

        public static void dodajListeWynikow(IEnumerable<Wynik> listaWynikow)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();
            db.Wyniks.InsertAllOnSubmit(listaWynikow);
            db.SubmitChanges();
        }

        public static void dodajWynik(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, double wartosc, ExpertHelperDataContext db)
        {
            Wynik wynik = new Wynik
            {
                KryteriumGlowne = kryteriumGlowne,
                Kryterium1 = idKryteriumJeden,
                Kryterium2 = idKryteriumDwa,
                Waga = wartosc
            };

            db.Wyniks.InsertOnSubmit(wynik);
            db.SubmitChanges();
        }

        public static Wynik pobierzWynik(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, ExpertHelperDataContext db)
        {
            var wynik = (from w in db.Wyniks
                         where w.KryteriumGlowne == kryteriumGlowne && w.Kryterium1 == idKryteriumJeden && w.Kryterium2 == idKryteriumDwa
                         select w).FirstOrDefault();

            return wynik;
        }

        public static Wynik stworzWynik(int kryteriumGlowne, int idKryteriumJeden, int idKryteriumDwa, double wartosc)
        {
            Wynik wynik = new Wynik();
            wynik.KryteriumGlowne = kryteriumGlowne;
            wynik.Kryterium1 = idKryteriumJeden;
            wynik.Kryterium2 = idKryteriumDwa;
            wynik.Waga = wartosc;

            return wynik;
        }

        public static List<Wynik> pobierzWszystkieWyniki(ExpertHelperDataContext db)
        {
            List<Wynik> listaWynikow = new List<Wynik>();

            var lista = from w in db.Wyniks
                        select w;

            foreach (Wynik wynik in lista)
            {
                Wynik w = new Wynik
                {
                    ID = wynik.ID,
                    KryteriumGlowne = wynik.KryteriumGlowne,
                    Kryterium1 = wynik.Kryterium1,
                    Kryterium2 = wynik.Kryterium2,
                    Waga = wynik.Waga
                };

                listaWynikow.Add(w);
            }

            return listaWynikow;
        }
    }
}
