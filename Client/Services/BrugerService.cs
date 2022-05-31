using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
    public class BrugerService : IBrugerService
    {
        private readonly HttpClient httpClient;

        // koordinator funktioner
        public Task<Bruger[]?> GetAlleFrivillige()
        {
            var result = httpClient.GetFromJsonAsync<Bruger[]>("api/bruger/allefrivillige");
            return result;
        }

        public Task<Bruger[]?> GetAlleKoordinatorer()
        {
            var result = httpClient.GetFromJsonAsync<Bruger[]>("api/bruger/allekoordinatorer");
            return result;
        }


        // frivillig funktioner
        public Task<Bruger[]?> GetBruger(string? brugerEmail)
        {
            var result = httpClient.GetFromJsonAsync<Bruger[]>("api/bruger/" + brugerEmail);
            return result;
        }

        public async Task<int> AddBruger(Bruger bruger)
        {
            var response = await httpClient.PostAsJsonAsync("api/bruger", bruger);
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
