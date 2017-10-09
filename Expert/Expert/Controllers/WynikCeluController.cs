using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class WynikCeluController
    {
        protected WynikCeluController()
        {

        }

        public static void dodajListeWynikow(IEnumerable<WynikCelu> listaWynikow, ExpertHelperDataContext db)
        {
            foreach (WynikCelu wynik in listaWynikow)
            {
                int idWyniku = sprawdzCzyWynikIstnieje(wynik.ID_Celu, wynik.ID_Wariantu, db);

                if (idWyniku == 0)
                {
                    db.WynikCelus.InsertOnSubmit(wynik);
                }
                else
                {
                    WynikCelu wynikCelu = pobierzWynik(idWyniku, db);

                    if (null != wynikCelu)
                    {
                        wynikCelu.Waga = wynik.Waga;
                    }
                }
            }

            db.SubmitChanges();
        }

        public static void dodajWynikCelu(int idCelu, int idWariantu, decimal waga, ExpertHelperDataContext db)
        {
            WynikCelu wynik = new WynikCelu()
            {
                ID_Celu = idCelu,
                ID_Wariantu = idWariantu,
                Waga = Convert.ToDouble(waga)
            };

            db.WynikCelus.InsertOnSubmit(wynik);
            db.SubmitChanges();
        }

        public static List<WynikCelu> pobierzListeWynikow(int idCelu, ExpertHelperDataContext db)
        {
            List<WynikCelu> listaWynikow = new List<WynikCelu>();

            var lista = from w in db.WynikCelus
                        where w.ID_Celu == idCelu
                        select w;

            foreach (var wynik in lista)
            {
                WynikCelu w = new WynikCelu()
                {
                    ID = wynik.ID,
                    ID_Celu = wynik.ID_Celu,
                    ID_Wariantu = wynik.ID_Wariantu,
                    Waga = wynik.Waga
                };

                listaWynikow.Add(w);
            }

            return listaWynikow;
        }

        public static int sprawdzCzyWynikIstnieje(int idCelu, int idWariantu, ExpertHelperDataContext db)
        {
            var idWyniku = (from w in db.WynikCelus
                            where w.ID_Celu == idCelu && w.ID_Wariantu == idWariantu
                            select w).FirstOrDefault();

            if (null != idWyniku)
            {
                return idWyniku.ID;
            }

            return 0;
        }

        public static WynikCelu pobierzWynik(int idWyniku, ExpertHelperDataContext db)
        {
            var wynik = (from w in db.WynikCelus
                         where w.ID == idWyniku
                         select w).FirstOrDefault();

            return wynik;
        }
    }
}
