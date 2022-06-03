using System;
using System.Net.Http.Json;
using misfits_festival.Shared.Models;
using misfits_festival.Client.Services;
using Dapper;
using Npgsql;

namespace misfits_festival.Client.Services
{
    public class OpgaveService : IOpgaveService // implementerer metoder fra interfacet
    {
        private readonly HttpClient httpClient;


        public Task<Opgave[]?> GetAlleOpgaver()
        {
            var result = httpClient.GetFromJsonAsync<Opgave[]>("api/opgaver");
            return result;
        }

        public async Task<int> AddOpgave(Opgave opgave)
        {
            var response = await httpClient.PostAsJsonAsync("api/opgaver", opgave);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateOpgave(Opgave opgave)
        {
            var response = await httpClient.PutAsJsonAsync("api/opgaver", opgave);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> DeleteOpgave(int? opgaveId)
        {
            var response = await httpClient.DeleteAsync("api/opgaver/" + opgaveId);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        public OpgaveService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
