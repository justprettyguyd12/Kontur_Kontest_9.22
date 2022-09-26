using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task3
{
    public static class Program
    {
        public static void Main()
        {
            var allTeams = new Dictionary<string, int>();
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var data = Console.ReadLine().Split(' ');
                allTeams.Add(data[0], int.Parse(data[1]));
            }
            var teams = Console.ReadLine().Split('-');
            
            Console.WriteLine($"{GetPlaceOnWin(allTeams, teams[0], teams[1])} " +
                              $"{GetPlaceOnDraw(allTeams, teams[0], teams[1])} " +
                              $"{GetPlaceOnLoss(allTeams, teams[0], teams[1])}");
        }
        
        private static int GetPlaceOnLoss(IDictionary<string, int> teams, string teamA, string teamB)
        {
            var teamsAfterMatch = teams.ToDictionary(t => t.Key, t => t.Value);
            teamsAfterMatch[teamB] += 3;
            return GetPlace(teamsAfterMatch, teamA);
        }
        
        private static int GetPlaceOnDraw(IDictionary<string, int> teams, string teamA, string teamB)
        {
            var teamsAfterMatch = teams.ToDictionary(t => t.Key, t => t.Value);
            teamsAfterMatch[teamA] += 1;
            teamsAfterMatch[teamB] += 1;
            return GetPlace(teamsAfterMatch, teamA);
        }
        
        private static int GetPlaceOnWin(IDictionary<string, int> teams, string teamA, string teamB)
        {
            var teamsAfterMatch = teams.ToDictionary(t => t.Key, t => t.Value);
            teamsAfterMatch[teamA] += 3;
            return GetPlace(teamsAfterMatch, teamA);
        }

        private static int GetPlace(IDictionary<string, int> teams, string team)
        {
            var teamsAfterMatch = teams.OrderByDescending(t => t.Value)
                .ThenBy(t => t.Key)
                .ToDictionary(t => t.Key, t => t.Value);
            var place = 1;
            foreach (var (key, value) in teamsAfterMatch)
            {
                if (key == team)
                    return place;
                place++;
            }
            return 0;
        }
    }
}