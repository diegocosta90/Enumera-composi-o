using Course.Entities;
using Course.Entities.Enums;
using System;
using System.Globalization;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name of the department: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker's Data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/Midlevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());//está recebendo um enum como parâmetro e esse enum precisa ser transformado em string
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);//sobrecarga de construtor
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                Console.WriteLine($"Enter #{i} contract Data: ");//interpolação, usando o simbolo do dolar e das chaves para entender qual contrato estamos mexendo de acordo com a interação
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);//Contrato criado acima é adicionado para o trabalhador
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string MonthAndYear = Console.ReadLine();
            int month = int.Parse(MonthAndYear.Substring(0, 2));//verifica a string do mês MM passada anteiormente e a recorta e depois armazena na variavel month.
            int year = int.Parse(MonthAndYear.Substring(3));//verifica a string do mês YYYY passada anteiormente e a recorta e depois armazena na variavel year.

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Department: " + worker.department.Name);
            Console.WriteLine("Income for " + MonthAndYear + ": " + worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
