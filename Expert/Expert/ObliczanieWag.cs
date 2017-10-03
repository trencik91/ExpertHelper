using System;
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
            DataTable macierzWag = podniesMacierzDoKwardratu(wagi);

            //foreach (DataColumn dc in wagi.Columns)
            //{
            //    decimal sumaKolumn = 0;

            //    foreach (DataRow dr in wagi.Rows)
            //    {
            //        if (dr.Table.Columns[dc.ColumnName].Ordinal > 0)
            //        {
            //            decimal wartoscWierszaKolumny = 0;

            //            bool czyWartoscPoprawna = decimal.TryParse(dr[dc].ToString(), out wartoscWierszaKolumny);

            //            if (czyWartoscPoprawna)
            //            {
            //                sumaKolumn = sumaKolumn + wartoscWierszaKolumny;
            //            }
            //        }
            //    }

            //    foreach (DataRow dr in wagi.Rows)
            //    {
            //        if (dr.Table.Columns[dc.ColumnName].Ordinal > 0)
            //        {
            //            decimal wartoscKomorki = decimal.Parse(dr[dc].ToString());
            //            decimal obliczonaWaga = decimal.Round(wartoscKomorki / sumaKolumn, ROUND);
            //            macierzWag.Rows[dr.Table.Rows.IndexOf(dr)][dc] = obliczonaWaga;
            //        }
            //    }
            //}

            //macierzWag.Columns.Add("Suma elementów");
            //macierzWag.Columns.Add("Waga");

            //decimal sumaWszystkichKolumn = 0;

            //foreach (DataRow dr in wagi.Rows)
            //{
            //    decimal sumaWierszy = 0;

            //    foreach (DataColumn dc in wagi.Columns)
            //    {
            //        if (dr.Table.Columns[dc.ColumnName].Ordinal > 0 && dr.Table.Columns[dc.ColumnName].Ordinal < dr.Table.Columns.Count - 2)
            //        {
            //            sumaWierszy = sumaWierszy + decimal.Parse(dr[dc].ToString());
            //        }
            //    }

            //    sumaWszystkichKolumn = sumaWszystkichKolumn + sumaWierszy;

            //    Console.WriteLine(sumaWierszy);

            //    dr["Suma elementów"] = decimal.Round(sumaWierszy, ROUND);
            //}

            //Console.WriteLine("suma kolumn " + sumaWszystkichKolumn);

            //foreach (DataRow dr in wagi.Rows)
            //{
            //    decimal wagaWiersza = decimal.Parse(dr["Suma elementów"].ToString()) / sumaWszystkichKolumn;

            //    dr["Waga"] = decimal.Round(wagaWiersza, ROUND);
            //}

            return macierzWag;
        }

        public static List<Wynik> pobierzWektorWag(int idCelu, int idKryterium)
        {
            List<Kryterium> listaWariantow = KryteriumController.pobierzListeWariantow(idCelu);

            return WynikController.pobierzWynikiKryterium(idCelu, idKryterium, listaWariantow);
        }

        private static DataTable podniesMacierzDoKwardratu(DataTable macierz)
        {
            DataTable macierzA = macierz;
            DataTable macierzB = macierz;

            DataTable macierzDoKwadratu = macierz;

            int rozmiarMacierzy = macierzA.Rows.Count;

            for (int i = 0; i < rozmiarMacierzy; i++)
            {
                for (int j = 0; j < rozmiarMacierzy; j++)
                {
                    macierzDoKwadratu.Rows[i][j] = 0;

                    for (int k = 0; k < rozmiarMacierzy; k++)
                    {
                        if (k == 0)
                        {
                            macierzDoKwadratu.Rows[i][0] = macierzA.Rows[i][0];
                            macierzDoKwadratu.Rows[0][j] = macierzA.Rows[0][j];
                        }
                        else
                        {
                            double valueA = Convert.ToDouble(macierzA.Rows[i][k].ToString());
                            double valueB = Convert.ToDouble(macierzB.Rows[k][j].ToString());
                            double value = valueA * valueB;
                            macierzDoKwadratu.Rows[i][j] = value;
                        }
                    }
                }
            }

            return macierzDoKwadratu;
        }
    }
}
