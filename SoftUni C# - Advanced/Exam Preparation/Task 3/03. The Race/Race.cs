using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        //• Field data – collection that holds added data
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        //• Getter Count – returns the number of data.
        public int Count => data.Count;


        //• Method Add(Racer Racer) – adds an entity to the data if there is room for him/her.
        public void Add(Racer racer)
        {
            if (!data.Contains(racer) && data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        //• Method Remove(string name) – removes an Racer by given name, if such exists, and returns bool.
        public bool Remove(string name)
        {
            Racer racerToRemove = data.FirstOrDefault(p => p.Name == name);

            if (racerToRemove != null)
            {
                data.Remove(racerToRemove);
            }

            return false;
        }

        //• Method GetOldestRacer() – returns the oldest Racer.
        public Racer GetOldestRacer()
        {
            Racer oldestRacer = data.OrderByDescending(r => r.Age)
                .FirstOrDefault();
            return oldestRacer;
        }

        //• Method GetRacer(string name) – returns the Racer with the given name.
        public Racer GetRacer(string name)
        {
            Racer currentRacer = data.Find(r => r.Name == name);
            return currentRacer;
        }

        //• Method GetFastestRacer() – returns the Racer whose car has the highest speed.
        public Racer GetFastestRacer()
        {
            Racer fastestRacer = data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
            return fastestRacer;
        }

        //• Report() – returns a string in the following format:
        public string Report()
        {
            var result = $"data participating at {Name}\n";
            foreach (Racer racer in data)
            {
                result += $"{racer}\n";
            }
            return result.TrimEnd();
        }
        //o "data participating at {RaceName}:
        //{Racer1} 
        //{Racer2}
    }
}

