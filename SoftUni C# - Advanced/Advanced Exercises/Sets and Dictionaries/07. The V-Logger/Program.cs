using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> hosts = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            string line = "";

            while (line != "Statistics")
            {
                line = Console.ReadLine();

                string[] input = line
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Contains("joined"))
                {
                    string joiner = input[0];

                    if (!hosts.ContainsKey(joiner))
                    {
                        hosts.Add(joiner, new List<string>());
                        guests.Add(joiner, new List<string>());
                    }
                }

                else if (input.Contains("followed"))
                {
                    string guest = input[0];
                    string host = input[2];

                    if (guest == host || !hosts.ContainsKey(host) || !hosts.ContainsKey(guest))
                    {
                        continue;
                    }

                    if (!hosts[host].Contains(guest))
                    {
                        hosts[host].Add(guest);
                        guests[guest].Add(host);
                    }
                }
            }
            int counter = 0;

            hosts = hosts
                .OrderByDescending(y => y.Value.Count)
                .ThenBy(x => guests[x.Key].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"The V-Logger has a total of {hosts.Count} vloggers in its logs.");

            foreach (var host in hosts)
            {
                counter++;
                Console.WriteLine($"{counter}. {host.Key} : {host.Value.Count} followers, {guests[host.Key].Count} following");

                foreach (var follower in host.Value.OrderBy(x => x))
                {
                    if (counter > 1)
                    {
                        break;
                    }
                    Console.WriteLine($"*  {follower}");
                }
            }
        }
    }
}
    

