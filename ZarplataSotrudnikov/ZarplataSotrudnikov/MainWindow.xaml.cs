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
                        YearlySalary = Math.Round(totalSalary, 2),
                        Total = Math.Round(totalSalary, 2)
                    });
                }

                DataGridEmployees.ItemsSource = employees;
            }
            else
            {
                MessageBox.Show("Введите корректное количество сотрудников.");
            }
        }

        private void ShowTotals_Click(object sender, RoutedEventArgs e)
        {
            var employees = DataGridEmployees.ItemsSource as List<Employee>;
            if (employees != null && employees.Count > 0)
            {
                decimal[] monthlyTotals = new decimal[12];
                decimal grandTotal = 0;

                // Считаем общие суммы по месяцам и общую сумму
                foreach (var employee in employees)
                {
                    for (int month = 0; month < 12; month++)
                    {
                        monthlyTotals[month] += employee.Salaries[month];
                    }
                    grandTotal += employee.Total;
                }

                // Добавляем строку с итогами
                employees.Add(new Employee
                {
                    Name = "Итого",
                    Salaries = monthlyTotals,
                    YearlySalary = Math.Round(grandTotal, 2),
                    Total = Math.Round(grandTotal, 2)
                });

                // Обновляем источник данных
                DataGridEmployees.ItemsSource = null;
                DataGridEmployees.ItemsSource = employees;
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public decimal[] Salaries { get; set; }
        public decimal YearlySalary { get; set; }
        public decimal Total { get; set; }
    }
}
