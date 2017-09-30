﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert
{
    class ObliczanieWag
    {
        private const int ROUND = 4;

        protected ObliczanieWag()
        {

        }

        public static DataTable ustalMacierzWag(DataTable wagi)
        {
            DataTable macierzWag = wagi;

            foreach (DataColumn dc in wagi.Columns)
            {
                decimal sumaKolumn = 0;

                foreach (DataRow dr in wagi.Rows)
                {
                    if (dr.Table.Columns[dc.ColumnName].Ordinal > 0)
                    {
                        decimal wartoscWierszaKolumny = 0;

                        bool czyWartoscPoprawna = decimal.TryParse(dr[dc].ToString(), out wartoscWierszaKolumny);

                        if (czyWartoscPoprawna)
                        {
                            sumaKolumn = sumaKolumn + wartoscWierszaKolumny;
                        }
                    }
                }

                foreach (DataRow dr in wagi.Rows)
                {
                    if (dr.Table.Columns[dc.ColumnName].Ordinal > 0)
                    {
                        decimal wartoscKomorki = decimal.Parse(dr[dc].ToString());
                        decimal obliczonaWaga = decimal.Round(wartoscKomorki / sumaKolumn, ROUND);
                        macierzWag.Rows[dr.Table.Rows.IndexOf(dr)][dc] = obliczonaWaga;
                    }
                }
            }

            macierzWag.Columns.Add("Suma elementów");
            macierzWag.Columns.Add("Waga");

            decimal sumaWszystkichKolumn = 0;

            foreach (DataRow dr in wagi.Rows)
            {
                decimal sumaWierszy = 0;

                foreach (DataColumn dc in wagi.Columns)
                {
                    if (dr.Table.Columns[dc.ColumnName].Ordinal > 0 && dr.Table.Columns[dc.ColumnName].Ordinal < dr.Table.Columns.Count - 2)
                    {
                        sumaWierszy = sumaWierszy + decimal.Parse(dr[dc].ToString());
                    }
                }

                sumaWszystkichKolumn = sumaWszystkichKolumn + sumaWierszy;

                dr["Suma elementów"] = decimal.Round(sumaWierszy, ROUND);
            }

            foreach (DataRow dr in wagi.Rows)
            {
                decimal wagaWiersza = decimal.Parse(dr["Suma elementów"].ToString()) / sumaWszystkichKolumn;

                dr["Waga"] = decimal.Round(wagaWiersza, ROUND);
            }

            return macierzWag;
        }

        public static List<int> pobierzWektorWag(int idCelu, int idKryterium)
        {
            List<int> wektorWagWariantow = new List<int>();

            List<Kryterium> listaWariantow = KryteriumController.pobierzListeWariantow(idCelu);

            List<Wynik> listaWynikow = WynikController.pobierzWynikiCelu(idCelu, idKryterium, listaWariantow);

            foreach (Wynik w in listaWynikow)
            {
                Console.WriteLine(w.KryteriumGlowne + "   " + w.Kryterium1 + "   " + w.Kryterium2 + "   " + w.Waga);
            }

            return wektorWagWariantow;
        }
    }
}
