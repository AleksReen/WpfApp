using System;
using System.Windows;
using WpfApp.EDMX;

namespace WpfApp.Pages.Forms
{
    public partial class NewEmployee : Window
    {
        public static EmpDBEntities db { get; set; }

        public NewEmployee(Employees newEmp)
        {
            db = new EmpDBEntities();         
            InitializeComponent();
            dpDate.SelectedDate = DateTime.Today;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.tbName.Clear();
            this.tbPatronymic.Clear();
            this.tbSurname.Clear();
            this.tbTelephone.Clear();
            this.cbTitle.SelectedIndex = -1;
            this.dpDate.SelectedDate = DateTime.Today;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string patronymic = tbPatronymic.Text;
            string surname = tbSurname.Text;
            string telephone = tbTelephone.Text;
            int title = Convert.ToInt32(cbTitle.SelectedValue);
            DateTime date = Convert.ToDateTime(dpDate.Text);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(patronymic) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(telephone) && title > -1)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Добавить нового сотрудника?", "Проверка", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        var emp = new Employee()
                        {
                            Name = name,
                            DateReceipt = date,
                            Patronymic = patronymic,
                            Surname = surname,
                            Telephone = telephone,
                            TitleID = title,
                            DataDesmissal = null                        
                        };
                        db.Employee.Add(emp);
                        db.SaveChanges();
                        MessageBox.Show("Новый сотрудник добавлен", "Добавлен");
                    }
                }
                catch
                {
                    MessageBox.Show(" Добавление невозможно \n Проверьте заполнение полей!!!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка");
            }
        }
    }
}
