using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using misfits_festival.Shared.Models;
using misfits_festival.Server.Models;
using Dapper;
using Npgsql;
using misfits_festival.Client.Services;
using Microsoft.Net.Http;

namespace misfits_festival.Server.Models
{
    internal class OpgaveRepository : IOpgaveRepository
    {
        // string connString = "User ID=postgres;Password=qrm49zyp;Host=localhost;Port=5432;Database=2_semester_projekt;";
        string connString = "User ID=adminbruger;Password=!hej1234;Host=misfitsfestival-db.postgres.database.azure.com;Port=5432;Database=postgres;";
        string sql = "";


        public async Task<IEnumerable<Opgave>> GetAlleOpgaver()
        {
            sql = $@"SELECT * FROM opgave";

            Console.WriteLine("getAlleOpgaver opgaveRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleOpgaver = await connection.QueryAsync<Opgave>(sql);
                return alleOpgaver.ToList();
            }
        }

        public async void AddOpgave(Opgave opgave)
        {
            sql =
                $@"INSERT INTO opgave (""opgave_beskrivelse"")
                    VALUES ('{opgave.OpgaveBeskrivelse}')";

            Console.WriteLine("addOpgave opgaveRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var opretOpgave = await connection.ExecuteAsync(sql);
            }
        }

        public async void UpdateOpgave(Opgave opgave)
        {
            sql = $@"UPDATE opgave
                     SET opgave_beskrivelse = '{opgave.OpgaveBeskrivelse}'
                     WHERE opgave_id = {opgave.OpgaveId};";

            Console.WriteLine("updateOpgave opgaveRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var updateOpgave = await connection.ExecuteAsync(sql);
            }
        }

        public async void DeleteOpgave(int? opgaveId)
        {
            sql = $@"DELETE FROM opgave WHERE opgave_id = 9;";
            Console.WriteLine("sql:" + sql);
            Console.WriteLine("deleteOpgave opgaveRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var updateOpgave = await connection.ExecuteAsync(sql);
            }
        }

        public OpgaveRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
