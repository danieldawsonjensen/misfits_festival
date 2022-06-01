using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;
using misfits_festival.Client.Services;
using Dapper;
using Npgsql;

namespace misfits_festival.Client.Services
{
    public class VagtService : IVagtService
    {
        private readonly HttpClient httpClient;

        // koordinator funktioner
        public Task<Vagt[]?> GetAlleVagter()
        {
            var result = httpClient.GetFromJsonAsync<Vagt[]>("api/vagter/allevagter");
            return result;
        }

        public async Task<int> AddVagt(Vagt vagt)
        {
            var response = await httpClient.PostAsJsonAsync("api/vagter", vagt);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateVagt(Vagt vagt)
        {
            var response = await httpClient.PutAsJsonAsync("api/vagter/updatevagt", vagt);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> DeleteVagt(int? vagtId)
        {
            var response = await httpClient.DeleteAsync("api/vagter/" + vagtId); // hvad skal der stå her?
                                                                                 // skal der står DeleteAsync?

            Console.WriteLine("vagtService - deleteVagt" + vagtId);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        // frivillig funktioner
        public async Task<Vagt[]?> GetMineVagter(string? brugerEmail)
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/vagter/" + brugerEmail); // httpGet fra api'en
            return result;
        }

        public async Task<Vagt[]?> GetLedigeVagter()
        {
            var result = await httpClient.GetFromJsonAsync<Vagt[]>("api/vagter/ledigevagter"); // httpGet fra api'en
            return result;
        }

        // muligvis skal man ikke selv kunne vælge en vagt, men koordinatoren skal derimod booke dig ind..?
        public async Task<int> BookVagt(Vagt vagt)
        {
            var response = await httpClient.PutAsJsonAsync("api/vagter/bookvagt", vagt); // httpPut fra api'en
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public VagtService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
