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
                "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoi0JHQvtCz0LTQsNC9IiwidGVuYW50IjoiNzI5IiwibmJmIjoxNjMwMDA4MDI5LCJleHAiOjE2MzAwOTQ0MjksImlzcyI6IlRlc3QtQmFja2VuZC0xIiwiYXVkIjoiQmFza2V0QmFsbENsdWJTYW1wbGUifQ.RGPR5EmYQ47CeH03lzRAUg0IljZ1EIPgoiSpIJAbino";
            TeamService teamService = new TeamService(token);
            Team team = new Team()
            {
                Name = "CSKA",
                foundationYear = 2009,
                division = "first",
                conference = "conf",
                imageUrl = "/images/ukhuqcbe.jpg"
            };
            await teamService.Add(team);
            TeamResponse teamresponse = await teamService.GetTeams();
            
            //Добавление и получение игрока
            PlayerService playerService = new PlayerService(token);
            Player player = new Player()
            {
                name = "Popandopolo",
                team = 826,
                number = 33,
                position = "Guard",
                birthday = new DateTime(1980,3,3),
                height = 199,
                weight = 99,
                avatarUrl = "SOmeAvatarUrl"
            };
            await playerService.Add(player);
            PlayerResponse playerResponse = await playerService.GetPlayers();
            Console.WriteLine(teamresponse.Teams);
            Console.WriteLine(playerResponse.Players);
        }
    }
}