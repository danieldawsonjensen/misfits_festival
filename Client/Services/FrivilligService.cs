using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
    public class FrivilligService : IFrivilligService
    {
        private readonly HttpClient httpClient;

        public async Task<Vagt[]?> GetMineVagter()
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/frivillig"); // httpGet fra api'en
            return result;
        }

        public async Task<Vagt[]?> GetLedigeVagter()
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/frivillig/ledigevagter"); // httpGet fra api'en
            return result;
        }

        public async Task<int> BookVagt(Vagt vagt)
        {
            var response = await httpClient.PostAsJsonAsync("api/frivillig", vagt); // httpPost fra api'en
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        public FrivilligService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
