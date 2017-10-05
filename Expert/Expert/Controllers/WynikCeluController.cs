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

        public static List<WynikCelu> pobierzListeWynikowDanegoCelu(int idCelu, ExpertHelperDataContext db)
        {
            List<WynikCelu> listaWynikow = new List<WynikCelu>();

            var lista = from w in db.WynikCelus
                        where w.ID_Celu == idCelu
                        select w;

            foreach (var w in lista)
            {
                WynikCelu wynikCelu = new WynikCelu()
                {
                    ID = w.ID,
                    ID_Celu = w.ID_Celu,
                    ID_Wariantu = w.ID_Wariantu,
                    Waga = w.Waga
                };

                listaWynikow.Add(wynikCelu);
            }

            return listaWynikow;
        }
    }
}
