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
    }
}
