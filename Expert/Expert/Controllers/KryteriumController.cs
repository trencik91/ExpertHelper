using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert
{
    class KryteriumController
    {
        public List<Kryterium> listaKryteriowBezPodkryteriow = new List<Kryterium>();

        protected KryteriumController()
        {

        }

        public static Kryterium dodajKryterium(String nazwa, String opis, int idRodzica, bool czyWariant, int idCelu)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            if (idCelu == 0)
            {
                Kryterium kryterium = new Kryterium
                {
                    Nazwa = nazwa,
                    Opis = opis,
                    Data_utworzenia = DateTime.Now,
                    ID_Rodzica = idRodzica,
                    Liczba_Podkryteriow = 0,
                    Czy_Wariant = czyWariant
                };

                db.Kryteriums.InsertOnSubmit(kryterium);
                db.SubmitChanges();

                kryterium.ID_Celu = kryterium.ID;
                db.SubmitChanges();

                return kryterium;
            }
            else
            {
                Kryterium kryterium = new Kryterium
                {
                    Nazwa = nazwa,
                    Opis = opis,
                    Data_utworzenia = DateTime.Now,
                    ID_Rodzica = idRodzica,
                    ID_Celu = idCelu,
                    Liczba_Podkryteriow = 0,
                    Czy_Wariant = czyWariant
                };

                db.Kryteriums.InsertOnSubmit(kryterium);
                db.SubmitChanges();

                return kryterium;
            }

            return null;
        }

        public static void edytujKryterium(int id, String nazwa, String opis, bool czyWariant)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(id, db, czyWariant);

            if (null != kryterium)
            {
                kryterium.Nazwa = nazwa;
                kryterium.Opis = opis;
            }

            db.SubmitChanges();
        }

        public static void usunKryterium(int id, ExpertHelperDataContext db)
        {
            Kryterium kryterium = pobierzKryteriumWariant(id, db);

            if (null != kryterium)
            {
                kryterium.ID_Rodzica = -1;
                db.SubmitChanges();
            }
        }

        public static void dodajLiczbePodkryteriow(int idKryterium, bool czyWariant)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(idKryterium, db, czyWariant);

            if (null != kryterium)
            {
                int liczbaPodkryteriow = kryterium.Liczba_Podkryteriow + 1;
                kryterium.Liczba_Podkryteriow = liczbaPodkryteriow;

                db.SubmitChanges();

            }
        }

        public static DataTable pobierzListeKryteriow()
        {
            DataTable listaKryteriow = new DataTable("Kryterium");

            listaKryteriow.Rows.Clear();
            listaKryteriow.Columns.Clear();
            listaKryteriow.Columns.Add("Lp");
            listaKryteriow.Columns.Add("ID");
            listaKryteriow.Columns.Add("ID_Rodzica");
            listaKryteriow.Columns.Add("Cel");
            listaKryteriow.Columns.Add("Opis");
            listaKryteriow.Columns.Add("Liczba_Podkryteriow");
            listaKryteriow.Columns.Add("Czy_Wariant");
            listaKryteriow.Columns.Add("ID_Celu");

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from d in db.Kryteriums
                        select new
                        {
                            id = d.ID,
                            idRodzica = d.ID_Rodzica,
                            idCelu = d.ID_Celu,
                            cel = d.Nazwa,
                            opis = d.Opis,
                            liczbaPodkryteriow = d.Liczba_Podkryteriow,
                            czyWariant = d.Czy_Wariant
                        };

            int lp = 1;

            foreach (var cel in lista)
            {
                DataRow dr = listaKryteriow.NewRow();
                dr["Lp"] = lp;
                dr["ID"] = cel.id;
                dr["ID_Rodzica"] = cel.idRodzica;
                dr["Cel"] = cel.cel;
                dr["Opis"] = cel.opis;
                dr["Liczba_Podkryteriow"] = cel.liczbaPodkryteriow;
                dr["Czy_Wariant"] = cel.czyWariant;
                dr["ID_Celu"] = cel.idCelu;

                lp++;

                listaKryteriow.Rows.Add(dr);
            }

            return listaKryteriow;
        }

        public static TreeNode pobierzDrzewo(int idRoot)
        {
            TreeNode rootItem = new TreeNode();
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium rootKryterium = pobierzKryterium(idRoot, db, false);

            if (null != rootKryterium)
            {
                rootItem.Name = rootKryterium.ID.ToString();
                rootItem.Text = rootKryterium.Nazwa;
            }

            stworzDrzewo(rootItem, idRoot);

            return rootItem;
        }

        public static List<int> stworzListeDoUsuniecia(int idRoot, int idCelu)
        {
            List<int> listaIdDoUsuniecia = new List<int>();
            listaIdDoUsuniecia.Add(idRoot);

            stworzListeIdPodkryteriow(idRoot, listaIdDoUsuniecia, idCelu);

            return listaIdDoUsuniecia;
        }

        public static List<Kryterium> pobierzListeCelow()
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            return listaKryteriow.AsEnumerable().Select(row => new Kryterium()).Where(row => row.ID_Celu == row.ID).ToList();
        }

        public static DataTable pobierzTabeleCelow()
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            if (listaKryteriow.Rows.Count > 0)
            {
                return listaKryteriow.AsEnumerable().Where(p => p.Field<String>("ID_Rodzica") == "0").CopyToDataTable();
            }
            else
            {
                return listaKryteriow;
            }
        }

        public static Kryterium pobierzKryterium(int id, ExpertHelperDataContext db, bool czyWariant)
        {
            var kryterium = (from kr in db.Kryteriums
                             where kr.ID == id && kr.Czy_Wariant == czyWariant
                             select kr).FirstOrDefault();

            if (null != kryterium)
            {
                return kryterium;
            }

            return null;
        }

        public static Kryterium pobierzKryterium(int id, bool czyWariant)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            return pobierzKryterium(id, db, czyWariant);
        }

        public static Kryterium pobierzKryteriumWariant(int id, ExpertHelperDataContext db)
        {
            var kryterium = (from kr in db.Kryteriums
                             where kr.ID == id
                             select kr).FirstOrDefault();

            if (null != kryterium)
            {
                return kryterium;
            }

            return null;
        }

        public static List<Kryterium> pobierzListePodkryteriow(int idRoot, int idCelu)
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            return listaKryteriow.AsEnumerable().Select(row => new Kryterium()
            {
                ID = int.Parse(row["ID"].ToString()),
                ID_Rodzica = int.Parse(row["ID_Rodzica"].ToString()),
                ID_Celu = int.Parse(row["ID_Celu"].ToString()),
                Nazwa = row["Cel"].ToString(),
                Opis = row["Opis"].ToString(),
                Liczba_Podkryteriow = int.Parse(row["Liczba_Podkryteriow"].ToString()),
                Czy_Wariant = bool.Parse(row["Czy_Wariant"].ToString())
            }).Where(row => row.ID_Rodzica == idRoot && row.ID_Celu ==  idCelu && !row.Czy_Wariant).ToList();
        }

        public static DataTable pobierzTabeleWariantow(int idCelu)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Wariantu");
            dt.Columns.Add("Nazwa");
            dt.Columns.Add("Opis");

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from w in db.Kryteriums
                        where w.ID_Rodzica == idCelu && w.Czy_Wariant
                        select w.ID;

            foreach (var w in lista)
            {
                Kryterium wariant = pobierzKryterium(w, db, true);

                if (null != wariant)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID_Wariantu"] = wariant.ID;
                    dr["Nazwa"] = wariant.Nazwa;
                    dr["Opis"] = wariant.Opis;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        public static List<Kryterium> pobierzListeWariantow(int idCelu)
        {
            List<Kryterium> listaWariantow = new List<Kryterium>();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from w in db.Kryteriums
                        where w.ID_Rodzica == idCelu && w.Czy_Wariant
                        select w.ID;

            foreach (var w in lista)
            {
                listaWariantow.Add(pobierzKryterium(w, db, true));
            }

            return listaWariantow;
        }

        public static Dictionary<String, int> pobierzListeIdKryteriow(int idCelu)
        {
            Dictionary<String, int> listaIdKryteriow = new Dictionary<String, int>();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from w in db.Kryteriums
                        where w.ID_Celu == idCelu
                        select w;

            foreach (var w in lista)
            {
                listaIdKryteriow.Add(w.Nazwa, w.ID);
            }

            return listaIdKryteriow;
        }

        public static Dictionary<int, String> pobierzListeNazwKryteriow(int idCelu)
        {
            Dictionary<int, String> listaIdKryteriow = new Dictionary<int, String>();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from w in db.Kryteriums
                        where w.ID_Celu == idCelu
                        select w;

            foreach (var w in lista)
            {
                listaIdKryteriow.Add(w.ID, w.Nazwa);
            }

            return listaIdKryteriow;
        }

        private static TreeNode stworzDrzewo(TreeNode root, int idCelu)
        {
            List<Kryterium> listaDzieci = pobierzListePodkryteriow(int.Parse(root.Name.ToString()), idCelu);

            listaDzieci.ForEach(k =>
            {
                TreeNode rootItem = new TreeNode();
                rootItem.Name = k.ID.ToString();
                rootItem.Text = k.Nazwa;

                root.Nodes.Add(rootItem);
                root.Expand();

                stworzDrzewo(rootItem, idCelu);

            });

            return root;
        }

        private static void stworzListeIdPodkryteriow(int idKryterium, List<int> lista, int idCelu)
        {
            List<Kryterium> listaDzieci = pobierzListePodkryteriow(idKryterium, idCelu);

            listaDzieci.ForEach(k =>
            {
                lista.Add(k.ID);

                stworzListeIdPodkryteriow(k.ID, lista, idCelu);

            });
        }
    }
}
