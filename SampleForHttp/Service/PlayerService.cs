using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleForHttp.Model;

namespace SampleForHttp.Service
{
    public class PlayerService
    {
        private readonly string _token;

        public PlayerService(string token)
        {
            this._token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public async Task Add(Player player)
        {
            string serializedPlayer = JsonConvert.SerializeObject(player);
            var content = new StringContent(serializedPlayer, Encoding.UTF8,"application/json");
            using (HttpClient client = new  HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
               
                var response = await client.PostAsync("http://dev.trainee.dex-it.ru/api/Player/Add", content);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<PlayerResponse> GetPlayers()
        {
            HttpResponseMessage responseMessage;
            PlayerResponse playerResponse;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
                responseMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Player/GetPlayers");
                responseMessage.EnsureSuccessStatusCode();
                string serializedMessage = await responseMessage.Content.ReadAsStringAsync();
                playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(serializedMessage);
            }

            return playerResponse;
        }
    }
}