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
		Task<IEnumerable<Bruger>> GetAlleFrivillige(); // task til at hente alle frivillige i systemet


		// frivillig funktioner
		void AddBruger(Bruger bruger);

		void UpdateBruger(Bruger bruger);

		void DeleteBruger(string brugerEmail); // ?? hvordan skal denne implementeres og er den nødvendig?

		Task<IEnumerable<Kompetence>> GetAlleKompetencer();
	}
}
