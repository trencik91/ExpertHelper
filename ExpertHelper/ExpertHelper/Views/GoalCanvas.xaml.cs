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
    /// <summary>
    /// Interaction logic for GoalCanvas.xaml
    /// </summary>
    public partial class GoalCanvas : Canvas
    {
        private int kryteriumID = 0;

        private int selectedIndex = 0;

        private int liczbaPodkryteriow = 0;
        private int liczbaZaglebienDrzewa = 0;

        private const int PODKRYTERIA = 9;
        private const int ZAGLEBIENIA = 3;

        private DataTable wszystkieKryteria = new DataTable();

        private List<Kryterium> listaCelow = new List<Kryterium>();

        public GoalCanvas()
        {
            InitializeComponent();
            nazwaTextBox.Focus();
            nextButton.IsEnabled = false;
            beforeButton.IsEnabled = false;
            wszystkieKryteria = KryteriumController.pobierzListeKryteriow();
            listaCelow = KryteriumController.pobierzListeCelow();
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (kryteriumID == 0)
            {
                Kryterium kryterium = KryteriumController.dodajKryterium(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, 0);
            }
            else
            {
                Kryterium kryterium = KryteriumController.dodajKryterium(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, kryteriumID);
                liczbaPodkryteriow++;
            }

            nazwaTextBox.Clear();
            opisRichTextBox.Document.Blocks.Clear();
            pobierzCele();

            listaProblemowDataGrid.SelectedIndex = selectedIndex;
        }

        private void kryteriumTreeView_Initialized(object sender, EventArgs e)
        {
            if (liczbaPodkryteriow == PODKRYTERIA || liczbaZaglebienDrzewa == ZAGLEBIENIA)
            {
                dodajPodkryteriumMenuItem.IsEnabled = false;
            }
            else if (kryteriumTreeView.Items.Count > 0)
            {
                dodajPodkryteriumMenuItem.IsEnabled = true;
            }
        }

        private void kryteriumTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (null == kryteriumTreeView.SelectedItem)
            {
                ustalBlokadeKontrolek(false);
            }
            else
            {
                ustalBlokadeKontrolek(true);
            }
        }

        private void listaProblemowDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kryteriumTreeView.Items.Clear();

            if (listaProblemowDataGrid.SelectedItems.Count == 1)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)listaProblemowDataGrid.SelectedItem;
                    int id = int.Parse(dataRow.Row.ItemArray[1].ToString());
                    selectedIndex = listaProblemowDataGrid.SelectedIndex;

                    kryteriumTreeView.Items.Add(KryteriumController.pobierzDrzewo(id));

                    ustalWagiButton.IsEnabled = false;
                }
                catch
                {
                    MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void dodajPodkryteriumMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (null != kryteriumTreeView.SelectedItem)
            {
                TreeViewItem item = (TreeViewItem)kryteriumTreeView.SelectedItem;

                nazwaTextBox.Focus();

                kryteriumID = int.Parse(item.Uid);
            }
        }

        private void usunMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (null != kryteriumTreeView.SelectedItem)
            {
                int id = int.Parse(((TreeViewItem)kryteriumTreeView.SelectedItem).Uid);

                //if (!KryteriumController.checkIsRoot(id))
                //{
                //    MessageBoxResult resutlt = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone kryterium?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //    if (resutlt == MessageBoxResult.Yes)
                //    {
                //        KryteriumController.usunKryterium(id);
                //    }
                //}
            }
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            nazwaTextBox.Focus();

            kryteriumID = 0;
        }

        private void pobierzCele()
        {
            List<Kryterium> listaCelow = KryteriumController.pobierzListeCelow();
            DataTable dt = KryteriumController.pobierzListeKryteriow();

            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Where(p => p.Field<string>("ID_Rodzica") == "0").CopyToDataTable();
            }

            listaProblemowDataGrid.ItemsSource = dt.AsDataView();
            listaProblemowDataGrid.CanUserAddRows = true;

            if (listaProblemowDataGrid.Columns.Count > 1)
            {
                listaProblemowDataGrid.Columns[0].Width = 41;
                listaProblemowDataGrid.Columns[3].Width = 210;
                listaProblemowDataGrid.Columns[1].Visibility = Visibility.Collapsed;
                listaProblemowDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            }
        }

        private void ustalBlokadeKontrolek(bool czyOdblokowane)
        {
            dodajPodkryteriumMenuItem.IsEnabled = czyOdblokowane;
            usunMenuItem.IsEnabled = czyOdblokowane;
            ustalWagiButton.IsEnabled = czyOdblokowane;
        }
    }
}
