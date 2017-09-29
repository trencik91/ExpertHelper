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
            }

            return macierzWag;
        }
    }
}
