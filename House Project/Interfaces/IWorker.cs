using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Project.Interfaces
{
    public enum position { manager, worker }
    public interface IWorker
    {
        string fullName { get; set; }
        double salary { get; set; }
        position position { get; }
        void printInfo();
        double calculateSalary(TimeSpan timespan);
    }
}
