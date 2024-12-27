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

namespace ZarplataSotrudnikov
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateSalaries_Click(object sender, RoutedEventArgs e)
        {
            int employeeCount;
            if (int.TryParse(TextBoxEmployeeCount.Text, out employeeCount) && employeeCount > 0)
            {
                List<Employee> employees = new List<Employee>();

                Random random = new Random();
                for (int i = 0; i < employeeCount; i++)
                {
                    decimal[] monthlySalaries = new decimal[12];
                    decimal totalSalary = 0;

                    for (int month = 0; month < 12; month++)
                    {
                        monthlySalaries[month] = Math.Round((decimal)(random.Next(30000, 100000)), 2);
                        totalSalary += monthlySalaries[month];
                    }

                    employees.Add(new Employee
                    {
                        Name = $"Сотрудник {i + 1}",
                        Salaries = monthlySalaries,
                        YearlySalary = Math.Round(totalSalary, 2)
                    });
                }

                DataGridEmployees.ItemsSource = employees;
            }
            else
            {
                MessageBox.Show("Введите корректное количество сотрудников.");
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public decimal[] Salaries { get; set; }
        public decimal YearlySalary { get; set; }
    }
}
