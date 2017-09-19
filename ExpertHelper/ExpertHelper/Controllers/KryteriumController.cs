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
                ID_Rodzica = idRodzica
            };

            db.Kryteriums.InsertOnSubmit(kryterium);
            db.SubmitChanges();

            return kryterium;
        }

        public static bool usunKryterium(int id)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Kryterium kryterium = pobierzKryterium(id);

            if (null != kryterium)
            {
                kryterium.ID_Rodzica = -1;
                db.SubmitChanges();
            }

            return false;
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

            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var lista = from d in db.Kryteriums
                        select new
                        {
                            id = d.ID,
                            idRodzica = d.ID_Rodzica,
                            cel = d.Nazwa
                        };

            int lp = 1;

            foreach (var cel in lista)
            {
                DataRow dr = listaKryteriow.NewRow();
                dr["Lp"] = lp;
                dr["ID"] = cel.id;
                dr["ID_Rodzica"] = cel.idRodzica;
                dr["Cel"] = cel.cel;

                lp++;

                listaKryteriow.Rows.Add(dr);
            }

            return listaKryteriow;
        }

        public static TreeViewItem pobierzDrzewo(int idRoot)
        {
            TreeViewItem rootItem = new TreeViewItem();
            Kryterium rootKryterium = pobierzKryterium(idRoot);

            if (null != rootKryterium)
            {
                rootItem.Uid = rootKryterium.ID.ToString();
                rootItem.Header = rootKryterium.Nazwa;
            }

            stworzDrzewo(rootItem);

            return rootItem;
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

        private static Kryterium pobierzKryterium(int id)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            var k = (from kr in db.Kryteriums
                     where kr.ID == id
                     select kr).FirstOrDefault();

            if (null != k)
            {
                Kryterium kryterium = new Kryterium
                {
                    ID = id,
                    ID_Rodzica = k.ID_Rodzica,
                    Nazwa = k.Nazwa,
                    Opis = k.Opis
                };

                return kryterium;
            }

            return null;
        }

        public static List<Kryterium> pobierzListeDzieci(int idRoot)
        {
            DataTable listaKryteriow = pobierzListeKryteriow();

            return listaKryteriow.AsEnumerable().Select(row => new Kryterium()
            {
                ID = int.Parse(row["ID"].ToString()),
                ID_Rodzica = int.Parse(row["ID_Rodzica"].ToString()),
                Nazwa = row["Cel"].ToString()
            }).Where(row => row.ID_Rodzica == idRoot).ToList();
        }

        private static TreeViewItem stworzDrzewo(TreeViewItem root)
        {
            List<Kryterium> listaDzieci = pobierzListeDzieci(int.Parse(root.Uid));

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
    }
}
