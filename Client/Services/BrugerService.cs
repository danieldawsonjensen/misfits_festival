using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
    public class BrugerService : IBrugerService // implementerer metoder fra interfacet
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
            var response = await httpClient.PostAsJsonAsync("api/bruger/", bruger);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateBruger(Bruger bruger)
        {
            var response = await httpClient.PutAsJsonAsync("api/bruger", bruger);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> DeleteBruger(string? brugerEmail)
        {
            var response = await httpClient.DeleteAsync("api/bruger" + brugerEmail);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<Kompetence[]?> GetAlleKompetencer()
        {
            var result = await httpClient.GetFromJsonAsync<Kompetence[]>("api/bruger/getkompetencer");
            return result;
        }

        public async Task<int> UpdateKompetencer(Bruger bruger, Kompetence kompetence)

        {
            // der sker lidt meget i denne service, men essentielt samler den et Bruger objekt og et Kompetence objekt;
            // disse samles i database i mange-til-mange tabellen bruger_kompetence
            BrugerKompetence brugerKompetence = new BrugerKompetence();
            brugerKompetence.Bruger = bruger;
            brugerKompetence.Kompetence = kompetence;
            var response = await httpClient.PutAsJsonAsync("api/bruger/updatekompetencer/", brugerKompetence);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        public BrugerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
