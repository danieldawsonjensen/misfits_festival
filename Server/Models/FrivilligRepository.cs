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
        // string connString = "User ID=postgres;Password=qrm49zyp;Host=localhost;Port=5432;Database=2_semester_projekt;";
        string connString = "User ID=adminbruger;Password=!hej1234;Host=misfitsfestival-db.postgres.database.azure.com;Port=5432;Database=postgres;";
        string sql = "";


        public async Task<IEnumerable<Vagt>> GetMineVagter(int brugerId)
        {
            /*sql = $@"SELECT * FROM vagt_opgave
            WHERE bruger_id = {brugerId}";*/

            sql = $@"SELECT v.vagt_id, v.dato, v.vagt_start, v.vagt_slut, v.pause, v.""område"", o.opgave_beskrivelse, b.bruger_navn
                     FROM vagt v
                     JOIN opgave o USING (opgave_id)
                     LEFT JOIN bruger b USING (bruger_id)
                     WHERE bruger_id = {brugerId};";

            Console.WriteLine("sql:" + sql);

            Console.WriteLine("getMineVagter frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var mineVagter = await connection.QueryAsync<Vagt>(sql);
                return mineVagter.ToList();
            }
        }


        public async Task<IEnumerable<Vagt>> GetLedigeVagter()
        {
            sql = @"SELECT * FROM vagt_opgave
            WHERE bruger_navn IS NULL";

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

        public async void AddBruger(Bruger bruger)
        {
            sql =
                $@"CALL opret_bruger ('{bruger.BrugerNavn}', '{bruger.BrugerEmail}', {bruger.RolleId}, '{bruger.TelefonNummer}')";

            Console.WriteLine("addbBruger frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var addBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            sql = $@"SELECT * FROM kompetence";

            Console.WriteLine("getAlleKompetencer frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleKompetencer = await connection.QueryAsync<Kompetence>(sql);
                return alleKompetencer.ToList();
            }
        }

        public async void UpdateKompetencer(int brugerId, int kompetenceId)
        {
            sql = $@"INSERT INTO bruger_kompetence
                        VALUES ({brugerId}, {kompetenceId})";

            Console.WriteLine("updateKompetencer frivilligRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var updateKompetencer = await connection.ExecuteAsync(sql);
            }
        }

        public FrivilligRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
