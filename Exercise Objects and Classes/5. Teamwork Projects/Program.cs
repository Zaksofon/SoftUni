using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    class Program
    {
        class Team
        {
            public Team(string creator, string name)
            {
                Creator = creator;
                Name = name;
                Members = new List<string>();
            }

            public string Creator { get; set; }

            public string Name { get; set; }

            public List<string> Members { get; set; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IList<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string newCreator = input[0];
                string newTeam = input[1];

                if (teams.Any(t => t.Name == newTeam))
                {
                    Console.WriteLine($"Team {newTeam} was already created!");
                    continue;
                }

                if (teams.Any(c => c.Creator == newCreator))
                {
                    Console.WriteLine($"{newCreator} cannot create another team!");
                    continue;
                }

                var team = new Team(newCreator, newTeam);
                teams.Add(team);
                Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] parts = input.Split("->", StringSplitOptions.RemoveEmptyEntries);

                string newMember = parts[0];
                string currentTeam = parts[1];

                if (teams.All(t => t.Name != currentTeam))
                {
                    Console.WriteLine($"Team {currentTeam} does not exist!");
                    continue;
                }

                if (teams.Any(m => m.Members.Contains(newMember)) || teams.Any(t => t.Creator == newMember))
                {
                    Console.WriteLine($"Member {newMember} cannot join team {currentTeam}!");
                    continue;
                }

                teams.First(t => t.Name == currentTeam).Members.Add(newMember);
            }

            IList<Team> disbandTeams = teams
                .Where(m => m.Members.Count == 0)
                .OrderBy(n => n.Name)
                .ToList();

            IList<Team> sortedTeams = teams
                .Where(m => m.Members.Count > 0)
                .OrderByDescending(m => m.Members.Count)
                .ThenBy(n => n.Name)
                .ToList();

            foreach (var squad in sortedTeams)
            {
                Console.WriteLine(squad.Name);
                Console.WriteLine($"- {squad.Creator}");

                IList<string> sortedMembers = squad.Members
                    .OrderBy(m => m).ToList();

                foreach (var member in sortedMembers)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var squad in disbandTeams)
            {
                Console.WriteLine(squad.Name);
            }
        }
    }
}
