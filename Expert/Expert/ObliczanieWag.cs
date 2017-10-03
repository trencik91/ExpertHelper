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
            DataTable macierzWag = wagi.Copy();
            macierzWag.Columns.Add("Suma elementów");
            macierzWag.Columns.Add("Waga");

            for (int i = 0; i < 2; i++)
            {
                wagi = podniesMacierzDoKwardratu(wagi);

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
                            macierzWag.Rows[dr.Table.Rows.IndexOf(dr)][dc.Ordinal] = obliczonaWaga;
                        }
                    }
                }

                decimal sumaWszystkichKolumn = 0;

                foreach (DataRow dr in macierzWag.Rows)
                {
                    decimal sumaWierszy = 0;

                    foreach (DataColumn dc in macierzWag.Columns)
                    {
                        if (dr.Table.Columns[dc.ColumnName].Ordinal > 0 && dr.Table.Columns[dc.ColumnName].Ordinal < dr.Table.Columns.Count - 2)
                        {
                            sumaWierszy = sumaWierszy + decimal.Parse(dr[dc].ToString());
                        }
                    }

                    sumaWszystkichKolumn = sumaWszystkichKolumn + sumaWierszy;

                    dr["Suma elementów"] = decimal.Round(sumaWierszy, ROUND);
                }

                foreach (DataRow dr in macierzWag.Rows)
                {
                    decimal wagaWiersza = decimal.Parse(dr["Suma elementów"].ToString()) / sumaWszystkichKolumn;

                    dr["Waga"] = decimal.Round(wagaWiersza, ROUND);
                }
            }

            return macierzWag;
        }

        public static List<Wynik> pobierzWektorWag(int idCelu, int idKryterium)
        {
            List<Kryterium> listaWariantow = KryteriumController.pobierzListeWariantow(idCelu);

            return WynikController.pobierzWynikiKryterium(idCelu, idKryterium, listaWariantow);
        }

        private static DataTable podniesMacierzDoKwardratu(DataTable macierz)
        {
            DataTable macierzA = macierz.Copy();

            DataTable macierzDoKwadratu = macierz.Copy();

            foreach (DataRow dr in macierzDoKwadratu.Rows)
            {
                foreach (DataColumn dc in macierzDoKwadratu.Columns)
                {
                    if (dc.Table.Columns[dc.ColumnName].Ordinal > 0)
                    {
                        dr[dc] = 0;
                    }
                }
            }

            int rozmiarMacierzy = macierz.Rows.Count;

            for (int i = 0; i < rozmiarMacierzy; i++)
            {
                for (int j = 1; j <= rozmiarMacierzy; j++)
                {
                    double val = 0;

                    int kol = 1;

                    for (int k = 0; k < rozmiarMacierzy; k++)
                    {
                        double valueA = Convert.ToDouble(macierzA.Rows[i][kol].ToString());
                        double valueB = Convert.ToDouble(macierzA.Rows[k][j].ToString());
                        double value = valueA * valueB;
                        val += value;

                        kol++;
                    }

                    macierzDoKwadratu.Rows[i][j] = val;
                }
            }

            return macierzDoKwadratu;
        }
    }
}
