using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SampleForHttp.Model;
using Newtonsoft.Json;

namespace SampleForHttp.Service
{
    public class TeamService
    {
        private readonly string _token;

        public TeamService(string token)
        {
            this._token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public async Task Add(Team team)
        {
            string serializedTeam = JsonConvert.SerializeObject(team);
            var content = new StringContent(serializedTeam, Encoding.UTF8,"application/json");
            using (HttpClient client = new  HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);

                var response = await client.PostAsync("http://dev.trainee.dex-it.ru/api/Team/Add", content);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<TeamResponse> GetTeams()
        {
            HttpResponseMessage responseMessage;
            TeamResponse teamResponse;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
                responseMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Team/GetTeams");
                responseMessage.EnsureSuccessStatusCode();
                string serializedMessage = await responseMessage.Content.ReadAsStringAsync();
                teamResponse = JsonConvert.DeserializeObject<TeamResponse>(serializedMessage);
            }
            return teamResponse;

        }
    }
}