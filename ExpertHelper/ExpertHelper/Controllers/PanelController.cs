using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExpertHelper
{
    class PanelController
    {
        protected PanelController()
        {

        }

        public static bool showCanvas(Window window, String canvasName)
        {
            return setPanelVisible(window, canvasName, Visibility.Visible);
        }

        public static bool hideCanvas(Window window, String canvasName)
        {
            return setPanelVisible(window, canvasName, Visibility.Hidden);
        }

        private static bool setPanelVisible(Window window, String canvasName, Visibility visibility)
        {
            Canvas canvas = getCanvas(window, canvasName);

            if (null != canvas)
            {
                canvas.Visibility = visibility;
                return true;
            }

            return false;
        }

        private static Canvas getCanvas(Window window, String canvasName)
        {
            return (Canvas)window.FindName(canvasName);
        }
    }

    class PanelObject
    {
        private String panelName { get; set; }
        private bool isVisible { get; set; }

        public PanelObject(String panelName, bool isVisible)
        {
            this.panelName = panelName;
            this.isVisible = isVisible;
        }
    }
}

