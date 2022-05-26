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
