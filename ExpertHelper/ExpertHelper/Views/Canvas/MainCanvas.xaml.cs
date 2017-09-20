using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainCanvas.xaml
    /// </summary>
    public partial class MainCanvas : Canvas
    {
        private Grid mainGrid;

        public MainCanvas()
        {
            InitializeComponent();
        }

        public MainCanvas(Grid mainGrid)
        {
            InitializeComponent();
            this.mainGrid = mainGrid;
        }

        private void celButton_Click(object sender, RoutedEventArgs e)
        {
            GoalCanvas gc = new GoalCanvas(mainGrid);
            this.Visibility = Visibility.Hidden;
            mainGrid.Children.Add(gc);
            gc.Visibility = Visibility.Visible;
        }

        private void zakonczButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę w programie?", "Zakończ pracę", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void listaCeliButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
