using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
    public class FrivilligService : IFrivilligService
    {
        private readonly HttpClient httpClient;

        // koordinator funktioner
        public Task<Bruger[]?> GetAlleFrivillige()
        {
            var result = httpClient.GetFromJsonAsync<Bruger[]>("api/bruger");
            return result;
        }


        // frivillig funktioner
        public async Task<Vagt[]?> GetMineVagter(string brugerEmail)
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/frivillig/brugervagter"); // httpGet fra api'en
            return result;
        }

        public async Task<Vagt[]?> GetLedigeVagter()
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/frivillig/ledigevagter"); // httpGet fra api'en
            return result;
        }

        public async Task<int> AddBruger(Bruger bruger)
        {
            var response = await httpClient.PostAsJsonAsync("api/frivillig/addbruger", bruger);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateBruger(Bruger bruger)
        {
            var response = await httpClient.PutAsJsonAsync("api/bruger", bruger);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> DeleteBruger(string brugerEmail)
        {
            var response = await httpClient.PostAsJsonAsync("api/bruger", brugerEmail); // hvad skal der stå her?
                                                                                        // skal der står DeleteAsync?
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<Kompetence[]?> GetAlleKompetencer()
        {
            var result = await httpClient.GetFromJsonAsync<Kompetence[]>("api/bruger/getkompetencer");
            return result;
        }


        public BrugerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
