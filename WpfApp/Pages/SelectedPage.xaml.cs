using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace WpfApp.Pages
{
    public partial class SelectedPage : Page
    {
        public SelectedPage()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Employees.xaml", UriKind.Relative));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Report.xaml", UriKind.Relative));
        }
    }
}
