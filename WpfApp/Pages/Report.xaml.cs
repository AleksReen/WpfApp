using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp.EDMX;

namespace WpfApp.Pages
{
    public partial class Report : Page
    {
        public static EmpDBEntities db { get; set; }

        public Report()
        {
            db = new EmpDBEntities();
            InitializeComponent();
        }

        private void Report_Loaded(object sender, RoutedEventArgs e)
        {
            var listEmployeesTitles = db.GetEmployeesReport().ToList();
            this.DataGridReport.ItemsSource = listEmployeesTitles;
            tbCount.Text = listEmployeesTitles.Sum(x=>x.CoutEmployees).ToString();
            tbDate.Text = DateTime.Today.ToString("dd MMMM yyyy");
            tbSt.Text = "ЗАГРУЖЕНО";
        }
    }
}
