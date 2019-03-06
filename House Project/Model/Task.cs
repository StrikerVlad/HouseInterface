using House_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Project.Model
{
    public class Task : ITask
    {
        public int id { get; set; }
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
        public status status { get; set; }
        public IWorker worker { get; set; }
        public IPart part { get; set; }

        public void printInfo()
        {
            switch (status)
            {
                case status.create:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-> ", part.partName);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case status.process:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-> ", part.partName);
                        Console.WriteLine("Начало: {0}", begin);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case status.complete:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-> ", part.partName);
                        Console.WriteLine("Начало: {0}-{1}", begin, end);
                        worker.printInfo();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
            }
        }
    }
}
