using System;
using Dapper;
using Npgsql;

namespace misfits_festival.Server.Models
{
	public class DBContext
	{
		public string connString { get; set; }
		public NpgsqlConnection connection { get; set; }

		public DBContext()
		{
			connString = "User ID=adminbruger;Password=!hej1234;Host=misfitsfestival-db.postgres.database.azure.com;Port=5432;Database=postgres;";
			connection = new NpgsqlConnection(connString);
		}
	}
}

