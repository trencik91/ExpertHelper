using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpertHelper
{
    public partial class CryterionCanvas : Canvas
    {
        private int idCelu = 0;

        public DependencyProperty ElevationAngleProperty { get; set; }

        public CryterionCanvas()
        {
            InitializeComponent();
        }

        public CryterionCanvas(int idCelu)
        {
            InitializeComponent();
            this.idCelu = idCelu;
            problemTreeView.Items.Clear();
            wariantyListBox.Items.Clear();
            uzupelnijDrzewoProblemu();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Binding b = new Binding();
            b.ElementName = "wagaSlider";
            SetBinding(ElevationAngleProperty, b);
        }

        private void wagaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(wagaSlider.Value);
        }

        private void uzupelnijDrzewoProblemu()
        {
            problemTreeView.Items.Add(KryteriumController.pobierzDrzewo(idCelu));
            List<Wariant> listaWariantow = WariantController.pobierzListeWariantow(idCelu);

            if (listaWariantow.Count > 0)
            {
                listaWariantow.ForEach(w => wariantyListBox.Items.Add(w.Nazwa));
            }
        }

        private void problemTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (null != problemTreeView.SelectedItem)
            {
                //try
                //{
                    TreeViewItem item = (TreeViewItem)problemTreeView.SelectedItem;
                    int id = int.Parse(item.Uid);

                    stworzKolumnyDataGrid(DataGridController.stworzTabeleWag(idCelu, id));

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Błąd przy tworzeniu identyfikatora danych! " + ex.ToString(), "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }

        private void stworzKolumnyDataGrid(DataTable tabelaWag)
        {
            wagiDataGrid.ItemsSource = tabelaWag.AsDataView();
            wagiDataGrid.CanUserAddRows = false;

            foreach (DataRow dr in tabelaWag.Rows)
            {
                foreach (DataColumn dc in tabelaWag.Columns)
                {
                    if (dr[0].ToString() == dc.ToString())
                    {
                        dr[dc] = 1;
                    }
                }
            }
        }
    }
}
