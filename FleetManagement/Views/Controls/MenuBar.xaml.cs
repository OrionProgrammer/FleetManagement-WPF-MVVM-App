using FleetManagement.Views;
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
using static FleetManagement.Helpers.EnumValues;

namespace FleetManagement.Views.Controls;

/// <summary>
/// Interaction logic for MenuBar.xaml
/// </summary>
public partial class MenuBar : UserControl
{
    
    public MenuBar()
    {
        InitializeComponent();
    }

    //Event Handlers

    private void Exit(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void NewVehicle(object sender, RoutedEventArgs e)
    {
        DoNavigation(PageName.Vehicle);
    }

    private void VehilceList(object sender, RoutedEventArgs e)
    {
        DoNavigation(PageName.VehicleList);
    }

    private static void DoNavigation(PageName PageName)
    {
        Window rootWinndow = Application.Current.Windows.OfType<Window>()!.SingleOrDefault(x => x.IsActive);

        Frame mainFrame = (Frame)rootWinndow!.FindName("Main");

        switch (PageName)
        {
            case PageName.Home:
                break;
            case PageName.Vehicle:
                mainFrame.Content = new ManageVehicleView();
                break;
            case PageName.VehicleList:
                mainFrame.Content = new VehicleListingView();
                break;
            default:
                break;
        }
    }
}
