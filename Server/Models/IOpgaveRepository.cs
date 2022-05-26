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
	public interface IOpgaveRepository
	{
		Task<IEnumerable<Opgave>> GetAlleOpgaver();

		void AddOpgave(Opgave opgave); // metode til post af en ny opgave

		void UpdateOpgave(Opgave opgave);

		void DeleteOpgave(int opgaveId);
	}
}
