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

            foreach (Wynik w in listaWynikow)
            {
                int idWyniku = sprawdzCzyWynikIstnieje(w, db);

                if (idWyniku == 0)
                {
                    db.Wyniks.InsertOnSubmit(w);
                }
                else
                {
                    Wynik wynik = pobierzWynik(idWyniku, db);

                    if (null != wynik)
                    {
                        wynik.Waga = w.Waga;
                    }
                }
            }

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

        public static List<Wynik> pobierzWynikiKryterium(int idCelu, int idKryterium, List<Kryterium> listaPodkryteriowWariantow)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            List<Wynik> listaWynikow = new List<Wynik>();

            foreach (Kryterium k in listaPodkryteriowWariantow)
            {
                Wynik wynik = pobierzWynik(idCelu, k.ID, idKryterium, db);

                if (null != wynik)
                {
                    listaWynikow.Add(wynik);
                }
            }

            return listaWynikow;
        }

        public static List<Wynik> pobierzWynikiCelu(int idCelu)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            List<Wynik> listaWynikow = new List<Wynik>();

            var lista = from w in db.Wyniks
                        where w.KryteriumGlowne == idCelu
                        select w;

            foreach (var w in lista)
            {
                Wynik wynik = new Wynik()
                {
                    ID = w.ID,
                    KryteriumGlowne = w.KryteriumGlowne,
                    Kryterium1 = w.Kryterium1,
                    Kryterium2 = w.Kryterium2,
                    Waga = w.Waga
                };

                listaWynikow.Add(wynik);
            }

            return listaWynikow;
        }

        public static Wynik pobierzWynik(int idWyniku, ExpertHelperDataContext db)
        {
            var wynik = (from w in db.Wyniks
                         where w.ID == idWyniku
                         select w).FirstOrDefault();

            if (null != wynik)
            {
                return wynik;
            }

            return null;
        }

        public static int sprawdzCzyWynikIstnieje(Wynik wynik, ExpertHelperDataContext db)
        {
            var idWyniku = (from w in db.Wyniks
                            where w.KryteriumGlowne == wynik.KryteriumGlowne && w.Kryterium1 == wynik.Kryterium1 && w.Kryterium2 == wynik.Kryterium2
                            select w).FirstOrDefault();

            if (null != idWyniku)
            {
                return idWyniku.ID;
            }

            return 0;
        }
    }
}
