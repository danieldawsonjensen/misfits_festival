using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using misfits_festival.Shared.Models;
using misfits_festival.Server.Models;
using Dapper;
using Npgsql;
using misfits_festival.Client.Services;
using System.Net.Http;
using Microsoft.Net.Http;

namespace misfits_festival.Server.Models
{
    internal class FrivilligRepository : IFrivilligRepository
    {
        string connString = "User ID=postgres;Password=qrm49zyp;Host=localhost;Port=5432;Database=2_semester_projekt;";
        string sql = "";


        public async Task<IEnumerable<Vagt>> GetMineVagter(int brugerId)
        {
            sql = $@"SELECT * FROM vagt
            WHERE bruger_id = {brugerId}";

            Console.WriteLine("getMineVagter frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var mineVagter = await connection.QueryAsync<Vagt>(sql);
                return mineVagter.ToList();
            }
        }


        public async Task<IEnumerable<Vagt>> GetLedigeVagter()
        {
            sql = @"SELECT * FROM vagt
            WHERE bruger_id IS NULL";

            Console.WriteLine("getLedigeVagter frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var ledigeVagter = await connection.QueryAsync<Vagt>(sql);
                return ledigeVagter.ToList();
            }
        }


        public async void BookVagt(int vagtId, int brugerId)
        {
            sql =
                $@"UPDATE vagt
                SET bruger_id = {brugerId}
                WHERE vagt_id = {vagtId}";

            Console.WriteLine("bookVagt frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var bookVagt = await connection.ExecuteAsync(sql);
            }
        }



        public FrivilligRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
