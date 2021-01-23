using Course.Entities.Enums; //é necessário para "puxar os dados da classe/enum WorkerLevel
using System.Collections.Generic;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }//Só é possível colocar esse atributo devido à importação do course.entities.enums
        public double BaseSalary { get; set; }
        public Department department { get; set; }//Essa propriedade criará uma associação do objeto worker com o objeto department
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//O trabalhador está associado a uma lista de contratos e ela é instanciada para que não seja vazia.


        public Worker()//construtor vazio padrão
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)//O construtor não possuia associação 1 para muitos por via de regra, por esse motivo a lista de contratos não foi incluída
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            this.department = department;
        }

        public void AddContract(HourContract contract)//Método adiciona contrato. Recebe ele como parâmetro e depois adiciona
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)//Método remove  contrato. Recebe ele como parâmetro e depois remove
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            
            foreach (HourContract contract in Contracts) //percorre todos os contratos
            {
                if (contract.Date.Year == year && contract.Date.Month == month)//verifica se o ano e o mês estão de acordo com o parâmetro
                {

                    sum = sum += contract.TotalValue();//realiza a soma dos valores dos contratos
                }
            }
            return sum;
        }
    }
}
