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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FleetManagement.View.Controls;
using FleetManagement.View.Pages;

namespace FleetManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnNewVehicle_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ManageVehicleView();
        }

        private void btnVehicleList_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new VehicleListingView();
        }
    }
}
