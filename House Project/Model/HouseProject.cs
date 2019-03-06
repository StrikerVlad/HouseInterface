using House_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace House_Project.Model
{
    public class HouseProject
    {
        public HouseProject()
        {
            createProject();
            team.createTeam();
            createTasks();

        }
        List<IPart> parts = new List<IPart>();
        List<ITask> tasks = new List<ITask>();

        Team team = new Team();

        private Random rnd = new Random();
        private void createProject()
        {
            Basement basement = new Basement()
            {
                countPart = 1,
                price = rnd.Next(),
                partName = "basement",
                order = 0
            };
            Roof roof = new Roof()
            {
                countPart = 1,
                price = rnd.Next(),
                partName = "roof",
                order = 2
            };

            Wall wall = new Wall()
            {
                countPart = rnd.Next(4, 12),
                price = rnd.Next(),
                partName = "roof",
                order = 1
            };
            parts.Add(basement);
            parts.Add(roof);
            parts.Add(wall);

        }
        private void createTasks()
        {
            int k = 0;
            foreach (IPart part in parts.OrderBy(o => o.order))
            {
                for (int i = 0; i < part.countPart; i++)
                {
                    Task task = new Task();
                    task.part = part;
                    task.id = k++;
                    tasks.Add(task);
                }
            }
        }

        public void startBuilding()
        {
            ITask task = getUnfinishedTask();
            while (task != null)
            {
                var worker = team.getFreeWorker();

                if (worker.position == position.manager)
                {
                    Console.WriteLine("Работаем че....");
                }
                else
                {
                    tasks[task.id].status = status.complete;
                    tasks[task.id].worker = worker;
                    tasks[task.id].begin = DateTime.Now;
                    tasks[task.id].end = DateTime.Now.AddDays(rnd.Next(2, 20));

                    for (int i = 0; i < (tasks[task.id].end - tasks[task.id].begin).TotalDays; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Работы по строительству {0} - завершены", tasks[task.id].part.partName);
                }
                task = getUnfinishedTask();
            }
            Console.WriteLine("Работы по строительству завершены");
        }

        private ITask getUnfinishedTask()
        {
            return tasks.OrderBy(o => o.part.order)
                              .Where(w => w.status == status.create)
                              .FirstOrDefault();
        }

    }
}
