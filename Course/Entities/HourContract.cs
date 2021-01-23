using System;


namespace Course.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValurPerHour { get; set; }
        public int Hours { get; set; }

        //construtor padrão

        public HourContract()//construtor vazio da classe
        {
        }

        public HourContract(DateTime date, double valurPerHour, int hours)//construtor com patâmetro gerado pela ferramenta
        {
            Date = date;
            ValurPerHour = valurPerHour;
            Hours = hours;
        }

        public double TotalValue() 
        {
            return Hours * ValurPerHour;
        }
    }
}
