using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpertHelper
{
    public partial class GoalCanvas : Canvas
    {
        private int kryteriumID = 0;
        private int wariantID = 0;
        private int selectedIndex = 0;
        private int liczbaPodkryteriow = 0;
        private int liczbaZaglebienDrzewa = 0;

        private const int PODKRYTERIA = 9;
        private const int ZAGLEBIENIA = 3;

        private Grid mainGrid;

        public GoalCanvas()
        {
            InitializeComponent();
            nazwaTextBox.Focus();
            nextButton.IsEnabled = false;
            beforeButton.IsEnabled = false;
            pobierzCele();
        }

        public GoalCanvas(Grid mainGrid)
        {
            InitializeComponent();
            nazwaTextBox.Focus();
            nextButton.IsEnabled = false;
            beforeButton.IsEnabled = false;
            pobierzCele();
            this.mainGrid = mainGrid;
            ustalWartoscCheckBoxa(goalCheckBox, true);
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (goalCheckBox.IsChecked.Value)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, 0);
            }
            else if (cryterionCheckBox.IsChecked.Value)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, kryteriumID);
                liczbaPodkryteriow++;
            }
            else if (wariantCheckBox.IsChecked.Value)
            {
                WariantController.dodajWariant(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, kryteriumID);
            }

            pobierzCele();
            listaProblemowDataGrid.SelectedIndex = selectedIndex;
            wyczyscKontrolki();
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
            wyczyscKontrolki();
            dodajButton.IsEnabled = false;
            zapiszButton.IsEnabled = true;

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
            wariantListBox.Items.Clear();
            wyczyscKontrolki();
            dodajButton.IsEnabled = false;
            zapiszButton.IsEnabled = true;

            if (listaProblemowDataGrid.SelectedItems.Count == 1)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)listaProblemowDataGrid.SelectedItem;
                    kryteriumID = int.Parse(dataRow.Row.ItemArray[1].ToString());
                    selectedIndex = listaProblemowDataGrid.SelectedIndex;

                    kryteriumTreeView.Items.Add(KryteriumController.pobierzDrzewo(kryteriumID));
                    List<Wariant> listaWariantow = WariantController.pobierzListeWariantow(kryteriumID);

                    if (listaWariantow.Count > 0)
                    {
                        listaWariantow.ForEach(w =>
                        {
                            wariantListBox.Items.Add(w.Nazwa);
                        });
                    }
                    
                    nazwaTextBox.Text = dataRow.Row.ItemArray[3].ToString();
                    opisRichTextBox.AppendText(dataRow.Row.ItemArray[4].ToString());

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
            wyczyscKontrolki();
            ustalWartoscCheckBoxa(cryterionCheckBox, true);
            dodajButton.IsEnabled = true;
            zapiszButton.IsEnabled = false;

            if (null != kryteriumTreeView.SelectedItem)
            {
                if (liczbaPodkryteriow < PODKRYTERIA)
                {
                    TreeViewItem item = (TreeViewItem)kryteriumTreeView.SelectedItem;

                    nazwaTextBox.Focus();

                    kryteriumID = int.Parse(item.Uid);
                }
                else
                {
                    MessageBox.Show("Maksymalna liczba podkryteriów wynosi " + PODKRYTERIA + "!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void usunMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (null != kryteriumTreeView.SelectedItem)
            {
                int id = int.Parse(((TreeViewItem)kryteriumTreeView.SelectedItem).Uid);

                MessageBoxResult resutlt = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone kryterium i wszystkie jego podkryteria?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resutlt == MessageBoxResult.Yes)
                {
                    List<int> listaPodkryteriow = KryteriumController.stworzListeDoUsuniecia(id);

                    foreach (int idPodkryterium in listaPodkryteriow)
                    {
                        KryteriumController.usunKryterium(idPodkryterium);
                    }
                }
            }
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            wyczyscKontrolki();
            dodajButton.IsEnabled = true;
            zapiszButton.IsEnabled = false;
            nazwaTextBox.Focus();
            ustalWartoscCheckBoxa(goalCheckBox, true);
            kryteriumID = 0;
        }

        private void dodajWariantMenuItem_Click(object sender, RoutedEventArgs e)
        {
            wyczyscKontrolki();
            dodajButton.IsEnabled = true;
            zapiszButton.IsEnabled = false;
            ustalWartoscCheckBoxa(wariantCheckBox, true);
            nazwaTextBox.Focus();
        }

        private void ustalWagiButton_Click(object sender, RoutedEventArgs e)
        {
            if (wariantListBox.Items.Count > 1)
            {
                this.Visibility = Visibility.Hidden;
                CryterionCanvas cc = new CryterionCanvas(kryteriumID);
                mainGrid.Children.Add(cc);
                cc.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Musisz dodać przynajmniej 2 warianty!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {
            if (goalCheckBox.IsChecked.Value || cryterionCheckBox.IsChecked.Value)
            {
                KryteriumController.edytujKryterium(kryteriumID, nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text);
            }
            else if (wariantCheckBox.IsChecked.Value)
            {
                WariantController.dodajWariant(nazwaTextBox.Text, new TextRange(opisRichTextBox.Document.ContentStart, opisRichTextBox.Document.ContentEnd).Text, kryteriumID);
            }
        }

        private void wariantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wariantID = int.Parse(((ItemsControl)wariantListBox.SelectedItem).Uid);
            Console.WriteLine("id " + wariantID);
        }

        private void goalCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ustalWartoscCheckBoxa(cryterionCheckBox, false);
            ustalWartoscCheckBoxa(wariantCheckBox, false);
        }

        private void cryterionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ustalWartoscCheckBoxa(goalCheckBox, false);
            ustalWartoscCheckBoxa(wariantCheckBox, false);
        }

        private void wariantCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ustalWartoscCheckBoxa(cryterionCheckBox, false);
            ustalWartoscCheckBoxa(goalCheckBox, false);
        }

        private void pobierzCele()
        {
            DataTable dt = KryteriumController.pobierzTabeleCelow();

            listaProblemowDataGrid.ItemsSource = dt.AsDataView();
            listaProblemowDataGrid.CanUserAddRows = true;

            if (listaProblemowDataGrid.Columns.Count > 1)
            {
                listaProblemowDataGrid.Columns[0].Width = 41;
                listaProblemowDataGrid.Columns[3].Width = 210;
                listaProblemowDataGrid.Columns[1].Visibility = Visibility.Collapsed;
                listaProblemowDataGrid.Columns[2].Visibility = Visibility.Collapsed;
                listaProblemowDataGrid.Columns[4].Visibility = Visibility.Collapsed;
            }
        }

        private void ustalBlokadeKontrolek(bool czyOdblokowane)
        {
            dodajPodkryteriumMenuItem.IsEnabled = czyOdblokowane;
            usunMenuItem.IsEnabled = czyOdblokowane;
            ustalWagiButton.IsEnabled = czyOdblokowane;
        }

        private void ustalWartoscCheckBoxa(ToggleButton checkBox, bool wartosc)
        {
            checkBox.IsChecked = wartosc;
        }

        private void wyczyscKontrolki()
        {
            nazwaTextBox.Clear();
            opisRichTextBox.Document.Blocks.Clear();
        }
    }
}
