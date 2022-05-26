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
    internal class BrugerRepository : IBrugerRepository
    {
        // string connString = "User ID=postgres;Password=qrm49zyp;Host=localhost;Port=5432;Database=2_semester_projekt;";
        string connString = "User ID=adminbruger;Password=!hej1234;Host=misfitsfestival-db.postgres.database.azure.com;Port=5432;Database=postgres;";
        string sql = "";


        // koordinator funktioner
        public async Task<IEnumerable<Bruger>> GetAlleFrivillige()
        {
            // sql = @"SELECT * FROM frivillig_kompetencer";
            sql = $@"SELECT * FROM frivillig_kompetencer;";

            Console.WriteLine("getAlleFrivillige brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleFrivillige = await connection.QueryAsync<Bruger>(sql);
                return alleFrivillige.ToList();
            }
        }


        // frivillig funktioner
        public async void AddBruger(Bruger bruger)
        {
            sql =
                $@"CALL opret_bruger ('{bruger.BrugerNavn}', '{bruger.BrugerEmail}', {bruger.RolleId}, '{bruger.TelefonNummer}')";

            Console.WriteLine("addbBruger brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var addBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async void UpdateBruger(Bruger bruger) // skal man kunne opdatere mere end bare navn fx?
        {
            sql = $@"UPDATE bruger
                     SET bruger_navn = '{bruger.BrugerNavn}'
                     WHERE brugerEmail = '{bruger.BrugerEmail}'";

            Console.WriteLine("updateBruger brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var deleteBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async void DeleteBruger(string brugerEmail)
        {
            sql = $@"DELETE FROM bruger
                     WHERE brugerEmail = '{brugerEmail}'";

            Console.WriteLine("deleteBruger brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var deleteBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            sql = $@"SELECT * FROM kompetence";

            Console.WriteLine("getAlleKompetencer brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleKompetencer = await connection.QueryAsync<Kompetence>(sql);
                return alleKompetencer.ToList();
            }
        }


        public BrugerRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
