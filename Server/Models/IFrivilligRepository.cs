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
	public interface IFrivilligRepository
	{
		Task<IEnumerable<Vagt>> GetMineVagter(string brugerNavn); // metode til at se sine egne bookede vagter

		Task<IEnumerable<Vagt>> GetLedigeVagter(); // metode til at se alle de nuværende ledige vagter

		void BookVagt(int vagtId, int brugerId); // metode til at booke en vagt

		void AddBruger(Bruger bruger);

		Task<IEnumerable<Kompetence>> GetAlleKompetencer();

		void UpdateKompetencer(int brugerId, int kompetenceId);
	}
}
