﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertHelper
{
    class DataGridController
    {
        protected DataGridController()
        {

        }

        public static DataTable stworzTabeleWag(int idCelu, int idKryterium)
        {
            DataTable tabelaWag = new DataTable();
            List<Kryterium> listaDzieci = KryteriumController.pobierzListeDzieci(idKryterium);
            Kryterium ojciec = KryteriumController.pobierzKryterium(idKryterium);

            if (listaDzieci.Count > 0)
            {
                tabelaWag.Columns.Add(ojciec.Nazwa);
                listaDzieci.ForEach(d => 
                {
                    tabelaWag.Columns.Add(d.Nazwa); tabelaWag.Rows.Add(d.Nazwa);
                });

            }
            else
            {
                List<Wariant> listaWariantow = WariantController.pobierzListeWariantow(idCelu);
                tabelaWag.Columns.Add("");
                listaWariantow.ForEach(w =>
                {
                    tabelaWag.Rows.Add(w.Nazwa);
                });
            }

            return tabelaWag;
        }
    }
}
