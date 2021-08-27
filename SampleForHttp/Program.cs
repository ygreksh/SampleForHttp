using System;
using System.Threading.Tasks;
using SampleForHttp.Model;
using SampleForHttp.Service;

namespace SampleForHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token =
                "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoi0JHQvtCz0LTQsNC9IiwidGVuYW50IjoiNzI5IiwibmJmIjoxNjMwMDQzMTYzLCJleHAiOjE2MzAxMjk1NjMsImlzcyI6IlRlc3QtQmFja2VuZC0xIiwiYXVkIjoiQmFza2V0QmFsbENsdWJTYW1wbGUifQ.jvJVXwklKOouUg4AtT1FE2nIDgpNKTzFWeskEb6K8t0";
            TeamService teamService = new TeamService(token);
            Team team = new Team()
            {
                Name = "DINAMO",
                FoundationYear = 1900,
                Division = "first",
                Conference = "conf",
                ImageUrl = "/images/ukhuqcbe.jpg"
            };
            await teamService.Add(team);
            TeamResponse teamresponse = await teamService.GetTeams();
            
            //Добавление и получение игрока
            PlayerService playerService = new PlayerService(token);
            Player player = new Player()
            {
                Name = "Ivanov",
                //Number = 5,
                Position = "Forward",
                Team = 1007,
                Birthday = new DateTime(1980, 5, 6),
                Heigth = 190,
                Weigth = 90,
                AvatarUrl = "SomeImageUrl",
                //Id = 10,
                //TeamName = "Arsenal"
            };
            await playerService.Add(player);
            PlayerResponse playerResponse = await playerService.GetPlayers();
            Console.WriteLine(teamresponse.Data);
            foreach (var item in teamresponse.Data)
            {
                Console.WriteLine($"{item.Id}, {item.Name}");
            }
            Console.WriteLine(playerResponse.Data);
            foreach (var item in playerResponse.Data)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Birthday}");
            }
        }
    }
}