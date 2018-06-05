using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.EDMX;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public static EmpDBEntities db { get; set; }
        private List<Employee> ListEmployees;

        public Employees()
        {
            db = new EmpDBEntities();
            InitializeComponent();
            ListEmployees = new List<Employee>();
        }

        private void EmployeesPage_Loaded(object sender, RoutedEventArgs e)
        {
            ListEmployees = db.Employee.ToList();
            this.DataGridEmployee.ItemsSource = ListEmployees;
            tbCount.Text = ListEmployees.Count().ToString();
            tbDate.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridEmployee.IsReadOnly = false;
            DataGridEmployee.BeginEdit();
            tbSt.Text = "РЕДАКТИРУЕТСЯ";
        }
    }
}
