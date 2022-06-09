using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Климатический_контроль
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var f = new Object();
            RoutedEventArgs e = new RoutedEventArgs();
            Update(f, e);
        }

        private void Inform_Click(object sender, RoutedEventArgs e)
        {
            string path = "devices.txt";
            string text = File.ReadAllText(path);
            string[] vs = text.Split(';');

            var name = sender as Button;

            for (int i = 0; i < vs.Count()-1; i++)
            {
                string[] device = vs[i].Split(',');
                if (name.Content.ToString() == device[0])
                {
                    deviceId.Text = device[0];
                    deviceName.Text = device[1];
                    tempText.Text = device[2];
                    waterText.Text = device[3];
                    acumText.Text = device[4];
                    statusText.Text = "Состояние обмена: " + device[5];
                }
            }
            float temperature = float.Parse(tempText.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (temperature <= 20.0)
            {
                var bc = new BrushConverter();
                tempBorder.Background = (Brush)bc.ConvertFrom("#FFEE3932");

                var tempBc = new BrushConverter();
                tempText.Foreground = (Brush)tempBc.ConvertFrom("#FFDADADA");
            }
            else if (temperature <= 30.0 && temperature > 20.0)
            {
                var bc = new BrushConverter();
                tempBorder.Background = (Brush)bc.ConvertFrom("#FFF5B642");
                tempText.Foreground = Brushes.Black;
            }
            else if (temperature >= 40.0)
            {
                var bc = new BrushConverter();
                tempBorder.Background = (Brush)bc.ConvertFrom("#FF449723");
                tempText.Foreground = Brushes.Black;
            }

            float water = float.Parse(waterText.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (water <= 20.0)
            {
                var bc = new BrushConverter();
                waterBorder.Background = (Brush)bc.ConvertFrom("#FFEE3932");

                var tempBc = new BrushConverter();
                waterText.Foreground = (Brush)tempBc.ConvertFrom("#FFDADADA");
            }
            else if (water <= 30.0 && water > 20.0)
            {
                var bc = new BrushConverter();
                waterBorder.Background = (Brush)bc.ConvertFrom("#FFF5B642");
                waterText.Foreground = Brushes.Black;
            }
            else if (water >= 40.0)
            {
                var bc = new BrushConverter();
                waterBorder.Background = (Brush)bc.ConvertFrom("#FF449723");
                waterText.Foreground = Brushes.Black;
            }

            float acumulate = float.Parse(acumText.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (acumulate <= 20.0)
            {
                var bc = new BrushConverter();
                acumBorder.Background = (Brush)bc.ConvertFrom("#FFEE3932");

                var tempBc = new BrushConverter();
                acumText.Foreground = (Brush)tempBc.ConvertFrom("#FFDADADA");
            }
            else if (acumulate <= 30.0 && acumulate > 20.0)
            {
                var bc = new BrushConverter();
                acumBorder.Background = (Brush)bc.ConvertFrom("#FFF5B642");
                acumText.Foreground = Brushes.Black;
            }
            else if (acumulate >= 40.0)
            {
                var bc = new BrushConverter();
                acumBorder.Background = (Brush)bc.ConvertFrom("#FF449723");
                acumText.Foreground = Brushes.Black;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();
            addDeviceWindow.ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            stackDevices.Children.Clear();

            string path = "devices.txt";
            string text = File.ReadAllText(path);
            string[] vs = text.Split(';');

            for (int i = 0; i < vs.Count() - 1; i++)
            {
                string[] device = vs[i].Split(',');

                Button button = new Button();
                button.Content = device[0];
                button.Click += Inform_Click;

                stackDevices.Children.Add(button);

                countDevice.Text = "Количество устройств: " + (i + 1);
            }
        }
    }
}
