using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Климатический_контроль
{
    /// <summary>
    /// Логика взаимодействия для AddDeviceWindow.xaml
    /// </summary>
    public partial class AddDeviceWindow : Window
    {
        public AddDeviceWindow()
        {
            InitializeComponent();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            string path = "devices.txt";
            string text = File.ReadAllText(path);
            string[] vs = text.Split(';');

            string[] device = vs[vs.Count()-2].Split(',');

            string[] deviceId = device[0].Split('-');

            string writeText = "Устройство ID-" + (Convert.ToInt32(deviceId[1])+1).ToString() + "," + nameText.Text.ToString() + "," + tempText.Text.ToString() + "," + waterText.Text.ToString() + "," + acumText.Text.ToString() + "," + "Отличное" + ";";

            using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                writer.Write(writeText);
            }
            MessageBox.Show("Устройство ID-" + (Convert.ToInt32(deviceId[1])+1).ToString() + " добавлено!");
        }
    }
}
