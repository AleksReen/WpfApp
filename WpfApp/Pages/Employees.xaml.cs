using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp.EDMX;
using WpfApp.Pages.Forms;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public static EmpDBEntities db { get; set; }
        private List<Employee> ListEmployees { get; set; }

        public Employees()
        {
            db = new EmpDBEntities();
            InitializeComponent();
            ListEmployees = new List<Employee>();
        }

        private void EmployeesPage_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            ListEmployees.Clear();
            ListEmployees = db.Employee.OrderBy(x => x.Surname).ToList();
            this.DataGridEmployee.ItemsSource = ListEmployees;
            tbCount.Text = ListEmployees.Count().ToString();
            tbDate.Text = DateTime.Today.ToString("dd MMMM yyyy");
            tbSt.Text = "ЗАГРУЖЕНО";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridEmployee.IsReadOnly = false;
            DataGridEmployee.BeginEdit();
            tbSt.Text = "РЕДАКТИРУЕТСЯ";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var newEmp = new NewEmployee(this);
            newEmp.Closed += NewEmp_Closed;           
            newEmp.ShowDialog();
        }

        private void NewEmp_Closed(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            DataGridEmployee.IsReadOnly = true;
            tbSt.Text = "СОХРАНЕНО";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = DataGridEmployee.SelectedItem as Employee;
            if (emp != null)
            {
                MessageBoxResult result =
                    MessageBox.Show("Удалить данные", "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    db.Employee.Remove(emp);
                    db.SaveChanges();

                    var selected = DataGridEmployee.SelectedIndex == 0 ? 1 : DataGridEmployee.SelectedIndex - 1;
                    ListEmployees.Remove(emp);
                    DataGridEmployee.Items.Refresh();
                    DataGridEmployee.SelectedIndex = selected;
                    tbCount.Text = Convert.ToString(ListEmployees.Count());

                    MessageBox.Show("Сотрудник удален");
                }
            }
            else
            {
                MessageBox.Show("Выберите отрудника для удаления");
            }
        }

        private void DataGridEmployee_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }
    }
}
