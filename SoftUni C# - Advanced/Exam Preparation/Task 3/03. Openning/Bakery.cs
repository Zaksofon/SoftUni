

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Openning
{
   public class Bakery
   {
       private List<Employee> data;

       private Bakery()
       {
           this.data = new List<Employee>();
       }

       public Bakery(string name, int capacity)
       :this()
       {
           Name = name;
           Capacity = capacity;
       }
       public string Name { get; set; }
       public int Capacity { get; set; }    

       public int Count => data.Count;

       public void Add(Employee employee)
       {
           if (data.Count + 1 <= Capacity)
           {
               data.Add(employee);
           }
       }

       public bool Remove(string name)
       {
           Employee employee = data.FirstOrDefault(e => e.Name == name);

           if (employee == null)
           {
               return false;
           }

           data.Remove(employee);
           return true;
       }

       public Employee GetOldestEmployee()
       {
           Employee oldestEmployee = data.OrderByDescending(e => e.Age).FirstOrDefault();
           return oldestEmployee;
       }

       public Employee GetEmployee(string name)
       {
           Employee employee = data.FirstOrDefault(e => e.Name == name);
           return employee;
       }

       public string Report()
       {
           StringBuilder sb = new StringBuilder();

           sb.AppendLine($"Employees working at Bakery {Name}:");

           foreach (Employee employee in data)
           {
               sb.AppendLine($"{employee}");
           }

           return sb.ToString().TrimEnd();
       }
    }
}
