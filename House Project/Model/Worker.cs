using House_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Project.Model
{
    public class Worker : IWorker
    {
        public Worker(position position)
        {
            tasks = new List<ITask>();
            this.position = position;
        }

        public string fullName { get; set; }
        public double salary { get; set; }
        public position position { get; private set; }

        public List<ITask> tasks;

        public double calculateSalary(TimeSpan timespan)
        {
            return timespan.TotalHours * salary;
        }

        public void printInfo()
        {
            Console.WriteLine("{0} ({1})", fullName, position);
            Console.WriteLine("Ставка: {0:0,000 KZT}", salary);
        }

    }
}
