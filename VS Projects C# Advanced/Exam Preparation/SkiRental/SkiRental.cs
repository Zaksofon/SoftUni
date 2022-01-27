using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
   public class SkiRental
    {
        private List<Ski> data;

        private SkiRental()
        {
            this.data = new List<Ski>();
        }

        public SkiRental(string name, int capacity)
         :this()
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = data.
                FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

            if (skiToRemove == null)
            {
                return false;
            }

            data.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
        {
            Ski newestSki = data.OrderByDescending(s => s.Year).FirstOrDefault();

            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski currentStudent = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            return currentStudent;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (Ski ski in data)
            {
                sb.AppendLine($"{ski}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
