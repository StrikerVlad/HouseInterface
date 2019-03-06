using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Project.Interfaces
{
    public enum status { create, process, complete }
    public interface ITask
    {
        int id { get; set; }
        DateTime begin { get; set; }
        DateTime end { get; set; }
        status status { get; set; }
        IWorker worker { get; set; }
        IPart part { get; set; }

        void printInfo();
    }
}
