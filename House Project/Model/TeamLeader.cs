using House_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Project.Model
{
    public class TeamLeader : IWorker
    {
        public TeamLeader()
        {
            this.position = position.manager;
        }
        public string fullName { get; set; }
        public double salary { get; set; }

        public position position { get; private set; }

        public double calculateSalary(TimeSpan timespan)
        {
            return timespan.TotalHours * salary * 1.05;
        }

        public void printInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} ({1})", fullName, position);
            Console.WriteLine("Ставка: {0:0,000 KZT}", salary);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
