using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;
using misfits_festival.Client.Services;
using Dapper;
using Npgsql;

namespace misfits_festival.Client.Services
{
    public class KoordinatorService : IKoordinatorService
    {
        private readonly HttpClient httpClient;

        public Task<Vagt[]?> GetAlleVagter()
        {
            var result = httpClient.GetFromJsonAsync<Vagt[]>("api/koordinator");
            return result;
        }

        public async Task<int> AddVagt(Vagt vagt)
        {
            var response = await httpClient.PostAsJsonAsync("api/koordinator/addvagt", vagt);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateVagt(int vagtId, Vagt vagt)
        {
            var response = await httpClient.PutAsJsonAsync("api/koordinator/updatevagt", (vagtId, vagt)); // hvad skal der stå her?
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> DeleteVagt(int vagtId)
        {
            var response = await httpClient.PostAsJsonAsync("api/koordinator", vagtId); // hvad skal der stå her?
                                                                                        // skal der står DeleteAsync?
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> AddOpgave(Opgave opgave)
        {
            var response = await httpClient.PostAsJsonAsync("api/koordinator/postopgave", opgave);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public Task<Opgave[]?> GetAlleOpgaver()
        {
            var result = httpClient.GetFromJsonAsync<Opgave[]>("api/koordinator/opgaver");
            return result;
        }

        public Task<Bruger[]?> GetAlleFrivillige()
        {
            var result = httpClient.GetFromJsonAsync<Bruger[]>("api/koordinator/getfrivillige");
            return result;
        }

        public KoordinatorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
