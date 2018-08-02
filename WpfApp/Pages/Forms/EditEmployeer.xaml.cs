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
using System.Windows.Shapes;
using WpfApp.EDMX;

namespace WpfApp.Pages.Forms
{
    /// <summary>
    /// Interaction logic for EditEmployeer.xaml
    /// </summary>
    public partial class EditEmployeer : Window
    {
        public static EmpDBEntities db { get; set; }
        Employee emp;

        public EditEmployeer(Employee employee)
        {
            db = new EmpDBEntities();
            InitializeComponent();
            emp = employee;

            GetEditEmp();
        }

        private void GetEditEmp()
        {
            this.tbName.Text = emp.Name;
            this.tbPatronymic.Text = emp.Patronymic;
            this.tbSurname.Text = emp.Surname;
            this.tbTelephone.Text = emp.Telephone;

            var title = db.Title.OrderBy( t => t.Title1).ToArray();


            var index = 0;

            for (int i = 0; i < title.Length; i++)
            {
                if (title[i].Title1 == emp.Title.Title1)
                {
                    index = i;
                    break;
                }
            }
           
            this.cbTitle.SelectedIndex = index;
            this.dpDate.SelectedDate = emp.DateReceipt;
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
            this.emp.Name = tbName.Text;
            this.emp.Patronymic = tbPatronymic.Text;
            this.emp.Surname = tbSurname.Text;
            this.emp.Telephone = tbTelephone.Text;

            int idTitle = Convert.ToInt32(cbTitle.SelectedValue);

            this.emp.Title = db.Title.Where(t => t.Id == idTitle).FirstOrDefault();

            if (!string.IsNullOrEmpty(this.emp.Name) 
                && !string.IsNullOrEmpty(this.emp.Patronymic) 
                && !string.IsNullOrEmpty(this.emp.Surname) 
                && !string.IsNullOrEmpty(this.emp.Telephone))
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Обновить запись по сотруднику?", "Проверка", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Запись обновлена", "Добавлен");
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
