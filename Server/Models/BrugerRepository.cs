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
            sql = $@"SELECT * FROM frivillig_kompetencer;";

            Console.WriteLine("getAlleFrivillige - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleFrivillige = await connection.QueryAsync<Bruger>(sql);
                return alleFrivillige.ToList();
            }
        }

        public async Task<IEnumerable<Bruger>> GetAlleKoordinatorer()
        {
            sql = $@"SELECT * FROM alle_koordinatorer;";

            Console.WriteLine("getAlleKoordinatorer - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleKoordinatorer = await connection.QueryAsync<Bruger>(sql);
                return alleKoordinatorer.ToList();
            }
        }


        // frivillig funktioner
        public async Task<IEnumerable<Bruger>> GetBruger(string? brugerEmail)
        {
            
            sql = $@" SELECT
                        b.bruger_id,
                        b.bruger_navn,
                        b.bruger_email,
                        b.telefonnummer,
                        string_agg(k.kompetence_beskrivelse, ', '::text) AS kompetencer
                    FROM bruger b
                    JOIN bruger_kompetence bk ON b.bruger_id = bk.bruger_bruger_id
                    JOIN kompetence k ON bk.kompetence_kompetence_id = k.kompetence_id
                    WHERE b.rolle_id = 1 AND bruger_email = '{brugerEmail}'
                    GROUP BY b.bruger_id, b.bruger_navn, b.bruger_email, b.telefonnummer
                    ORDER BY b.bruger_navn;";
            
            // sql = $@"SELECT * FROM bruger WHERE bruger_email = '{brugerEmail}'";

            Console.WriteLine("getBruger - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var minBruger = await connection.QueryAsync<Bruger>(sql);
                return minBruger.ToList();
            }
        }

        public async void AddBruger(Bruger bruger)
        {
            sql =
                $@"CALL opret_bruger ('{bruger.BrugerNavn}', '{bruger.BrugerEmail}', 1, '{bruger.TelefonNummer}')";

            Console.WriteLine("addbBruger - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var addBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async void UpdateBruger(Bruger bruger) // where bruger_id = {bruger.brugerId}
        {
            sql =
                $@"UPDATE bruger SET bruger_navn = '{bruger.BrugerNavn}', bruger_email = '{bruger.BrugerEmail}', telefonnummer = '{bruger.TelefonNummer}' WHERE bruger_id = {bruger.BrugerId};";

            Console.WriteLine("updateBruger - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var deleteBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async void DeleteBruger(string brugerEmail)
        {
            sql = $@"DELETE FROM bruger
                     WHERE brugerEmail = '{brugerEmail}'";

            Console.WriteLine("deleteBruger - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var deleteBruger = await connection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            sql = $@"SELECT * FROM kompetence";

            Console.WriteLine("getAlleKompetencer - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleKompetencer = await connection.QueryAsync<Kompetence>(sql);
                return alleKompetencer.ToList();
            }
        }

        public async void UpdateKompetencer(BrugerKompetence brugerKompetence)
        {
            sql =
                $@"INSERT INTO bruger_kompetence VALUES ({brugerKompetence.Bruger.BrugerId}, {brugerKompetence.Kompetence.KompetenceId});";
            Console.WriteLine("sql: " + sql);

            Console.WriteLine("updateKompetencer - brugerRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var updateKompetencer = await connection.ExecuteAsync(sql);
            }
        }

        public BrugerRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
