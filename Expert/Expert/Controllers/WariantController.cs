using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class WariantController
    {
        protected WariantController()
        {

        }

        public static Wariant dodajWariant(String nazwa, String opis, int idCelu)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Wariant wariant = new Wariant
            {
                Nazwa = nazwa,
                Opis = opis
            };

            db.Wariants.InsertOnSubmit(wariant);
            db.SubmitChanges();

            Warianty_Celu wariantCelu = new Warianty_Celu
            {
                ID_Wariantu = wariant.ID_Wariantu,
                ID_Celu = idCelu
            };

            db.Warianty_Celus.InsertOnSubmit(wariantCelu);
            db.SubmitChanges();

            return wariant;
        }

        public static void edytujWariant(int idWariantu, String nazwa, String opis)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Wariant wariant = pobierzWariant(idWariantu, db);

            if (null != wariant)
            {
                wariant.Nazwa = nazwa;
                wariant.Opis = opis;

                db.SubmitChanges();
            }
        }

        public static List<Wariant> pobierzListeWariantow(int idCelu)
        {
            List<Wariant> listaWariantow = new List<Wariant>();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from w in db.Warianty_Celus
                        where w.ID_Celu == idCelu
                        select w.ID_Wariantu;

            foreach (var w in lista)
            {
                listaWariantow.Add(pobierzWariant(w, db));
            }

            return listaWariantow;
        }

        public static Wariant pobierzWariant(int idWariantu)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            return pobierzWariant(idWariantu, db);
        }

        public static Wariant pobierzWariant(int idWariantu, ExpertHelperDataContext db)
        {
            var wariant = (from w in db.Wariants
                           where w.ID_Wariantu == idWariantu
                           select w).FirstOrDefault();

            if (null != wariant)
            {
                return wariant;
            }

            return null;
        }
    }
}
