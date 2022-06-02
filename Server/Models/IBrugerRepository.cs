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
	public interface IBrugerRepository
	{
		// koordinator funktioner
		Task<IEnumerable<Bruger>> GetAlleFrivillige();

		Task<IEnumerable<Bruger>> GetAlleKoordinatorer();


		// frivillig funktioner
		Task<IEnumerable<Bruger>> GetBruger(string? brugerEmail);

		void AddBruger(Bruger bruger);

		void UpdateBruger(Bruger bruger);


		Task<IEnumerable<Kompetence>> GetAlleKompetencer();

		void UpdateKompetencer(BrugerKompetence brugerKompetence);
	}
}
