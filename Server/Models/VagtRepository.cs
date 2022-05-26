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
    internal class VagtRepository : IVagtRepository
    {
        // string connString = "User ID=postgres;Password=qrm49zyp;Host=localhost;Port=5432;Database=2_semester_projekt;";
        string connString = "User ID=adminbruger;Password=!hej1234;Host=misfitsfestival-db.postgres.database.azure.com;Port=5432;Database=postgres;";
        string sql = "";

        // koordinator funktioner
        public async Task<IEnumerable<Vagt>> GetAlleVagter()
        {
            sql = @"SELECT * FROM vagt_opgave";

            Console.WriteLine("getAlleVagter vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var alleVagter = await connection.QueryAsync<Vagt>(sql);
                return alleVagter.ToList();
            }
        }

        public async void AddVagt(Vagt vagt)
        {
            // sql = $@"CALL opret_vagt ({vagt.VagtId}, {vagt.Dato}, {vagt.VagtStart}, {vagt.VagtSlut}, {vagt.Pause}, {vagt.Område}, {vagt.OpgaveId}, {vagt.OpgaveBeskrivelse})";
            sql = $@"INSERT INTO vagt (dato, vagt_start, vagt_slut, pause, område, opgave_id)
                        VALUES ('{vagt.Dato}', '{vagt.VagtStart}', '{vagt.VagtSlut}', {vagt.Pause}, '{vagt.Område}', '{vagt.OpgaveId}')";

            Console.WriteLine("addVagt vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var opretVagt = await connection.ExecuteAsync(sql);
            }
        }


        public async void UpdateVagt(Vagt vagt)
        {
            sql =
                $@"UPDATE vagt
                SET dato = {vagt.Dato}, ""vagt_start"" = {vagt.VagtStart}, ""vagt_slut"" = {vagt.VagtSlut}, pause = {vagt.Pause}, område = {vagt.Område},
                    ""opgave_id"" = {vagt.OpgaveBeskrivelse}, ""bruger_id"" = {vagt.BrugerId}
                WHERE vagt_id = {vagt.VagtId}";

            Console.WriteLine("updateVagt vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var updateVagt = await connection.ExecuteAsync(sql);
            }
        }

        public async void DeleteVagt(int vagtId)
        {
            sql =
                $@"DELETE FROM vagt
                WHERE vagt_id = {vagtId}";

            Console.WriteLine("updateVagt vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var deleteVagt = await connection.ExecuteAsync(sql);
            }
        }


        // frivillig funktioner
        public async Task<IEnumerable<Vagt>> GetMineVagter(string brugerEmail)
        {
            /*sql = $@"SELECT * FROM vagt_opgave
            WHERE bruger_id = {brugerId}";*/

            sql = $@"SELECT v.vagt_id, v.dato, v.vagt_start, v.vagt_slut, v.pause, v.""område"", o.opgave_beskrivelse, b.bruger_email
                     FROM vagt v
                     JOIN opgave o USING(opgave_id)
                     LEFT JOIN bruger b USING(bruger_id)
                     WHERE bruger_email = '{brugerEmail}'; ";

            Console.WriteLine("sql:" + sql);

            Console.WriteLine("getMineVagter vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var mineVagter = await connection.QueryAsync<Vagt>(sql);
                return mineVagter.ToList();
            }
        }


        public async Task<IEnumerable<Vagt>> GetLedigeVagter()
        {
            sql = @"SELECT * FROM vagt_opgave
            WHERE bruger_email IS NULL";

            Console.WriteLine("getLedigeVagter vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var ledigeVagter = await connection.QueryAsync<Vagt>(sql);
                return ledigeVagter.ToList();
            }
        }


        public async void BookVagt(Vagt vagt)
        {
            sql =
                $@"UPDATE vagt
                SET bruger_id = {brugerId}
                WHERE vagt_id = {vagtId}";

            Console.WriteLine("bookVagt vagtRepository");

            using (var connection = new NpgsqlConnection(connString))
            {
                var bookVagt = await connection.ExecuteAsync(sql);
            }
        }


        public VagtRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
