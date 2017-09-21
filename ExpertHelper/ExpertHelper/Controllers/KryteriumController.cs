using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Windows.Controls;

namespace ExpertHelper
{
    class KryteriumController
    {
        protected KryteriumController()
        {
        }

        public static Kryterium dodajKryterium(String nazwa, String opis, int idRodzica)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = new Kryterium
            {
                Nazwa = nazwa,
                Opis = opis,
                Data_utworzenia = DateTime.Now,
                ID_Rodzica = idRodzica,
                Liczba_Podkryteriow = 0
            };

            db.Kryteriums.InsertOnSubmit(kryterium);
            db.SubmitChanges();

            return kryterium;
        }

        public static void edytujKryterium(int id, String nazwa, String opis)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(id, db);

            if (null != kryterium)
            {
                kryterium.Nazwa = nazwa;
                kryterium.Opis = opis;
            }

            db.SubmitChanges();
        }

        public static void usunKryterium(int id)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(id, db);

            if (null != kryterium)
            {
                kryterium.ID_Rodzica = -1;
                db.SubmitChanges();
            }
        }

        public static void dodajLiczbePodkryteriow(int idKryterium)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(idKryterium, db);

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

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from d in db.Kryteriums
                        select new
                        {
                            id = d.ID,
                            idRodzica = d.ID_Rodzica,
                            cel = d.Nazwa,
                            opis = d.Opis,
                            liczbaPodkryteriow = d.Liczba_Podkryteriow
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

                lp++;

                listaKryteriow.Rows.Add(dr);
            }

            return listaKryteriow;
        }

        public static TreeViewItem pobierzDrzewo(int idRoot)
        {
            TreeViewItem rootItem = new TreeViewItem();
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium rootKryterium = pobierzKryterium(idRoot, db);

            if (null != rootKryterium)
            {
                rootItem.Uid = rootKryterium.ID.ToString();
                rootItem.Header = rootKryterium.Nazwa;
            }

            stworzDrzewo(rootItem);

            return rootItem;
        }

        public static List<int> stworzListeDoUsuniecia(int idRoot)
        {
            List<int> listaIdDoUsuniecia = new List<int>();
            listaIdDoUsuniecia.Add(idRoot);

            stworzListeIdPodkryteriow(idRoot, listaIdDoUsuniecia);

            foreach (int id in listaIdDoUsuniecia)
            {
                Console.WriteLine("id = " + id);
            }

            return listaIdDoUsuniecia;
        }

        public static List<Kryterium> pobierzListeCelow()
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            return listaKryteriow.AsEnumerable().Select(row => new Kryterium()).Where(row => row.ID_Rodzica == 0).ToList();
        }

        public static DataTable pobierzTabeleCelow()
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            if (listaKryteriow.Rows.Count > 0)
            {
                return listaKryteriow.AsEnumerable().Where(p => p.Field<string>("ID_Rodzica") == "0").CopyToDataTable();
            }
            else
            {
                return listaKryteriow;
            }
        }

        public static Kryterium pobierzKryterium(int id, ExpertHelperDataContext db)
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

        public static List<Kryterium> pobierzListePodkryteriow(int idRoot)
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            return listaKryteriow.AsEnumerable().Select(row => new Kryterium()
            {
                ID = int.Parse(row["ID"].ToString()),
                ID_Rodzica = int.Parse(row["ID_Rodzica"].ToString()),
                Nazwa = row["Cel"].ToString(),
                Opis = row["Opis"].ToString(),
                Liczba_Podkryteriow = int.Parse(row["Liczba_Podkryteriow"].ToString())
            }).Where(row => row.ID_Rodzica == idRoot).ToList();
        }

        private static TreeViewItem stworzDrzewo(TreeViewItem root)
        {
            List<Kryterium> listaDzieci = pobierzListePodkryteriow(int.Parse(root.Uid));

            listaDzieci.ForEach(k =>
            {
                TreeViewItem rootItem = new TreeViewItem();
                rootItem.Uid = k.ID.ToString();
                rootItem.Header = k.Nazwa;

                root.Items.Add(rootItem);
                root.IsExpanded = true;

                stworzDrzewo(rootItem);

            });

            return root;
        }

        private static void stworzListeIdPodkryteriow(int idKryterium, List<int> lista)
        {
            List<Kryterium> listaDzieci = pobierzListePodkryteriow(idKryterium);

            listaDzieci.ForEach(k =>
            {
                lista.Add(k.ID);

                stworzListeIdPodkryteriow(k.ID, lista);

            });
        }
    }
}
