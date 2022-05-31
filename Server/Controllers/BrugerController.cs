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


namespace misfits_festival.Server.Controllers
{
	[ApiController]
	[Route("api/bruger")]

	public class BrugerController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
	{
		private readonly IBrugerRepository Brugere = new BrugerRepository(); // definerer en ny instans af interfacet med
																			 // metoderne til CRUD funktionalitet

		public BrugerController(IBrugerRepository brugerRepository)
		{
			if (Brugere == null && brugerRepository != null)
			{
				Brugere = brugerRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		// koordinator funktioner
		[HttpGet("allefrivillige")]
		public async Task<IEnumerable<Bruger>> GetAlleFrivillige() // http get på alle frivillige i systemet
		{
			Console.WriteLine("getAlleFrivillige - brugerController");
			return await Brugere.GetAlleFrivillige();
		}

		[HttpGet("allekoordinatorer")]
		public async Task<IEnumerable<Bruger>> GetAlleKoordinatorer() // http get på alle frivillige i systemet
		{
			Console.WriteLine("getAlleKoordinatorer - brugerController");
			return await Brugere.GetAlleKoordinatorer();
		}


        // frivillig funktioner
        [HttpGet("{brugerEmail}")]
		public async Task<IEnumerable<Bruger>> GetBruger(string? brugerEmail)
        {
            Console.WriteLine("getBruger - brugerController");
			return await Brugere.GetBruger(brugerEmail);
        }

		[HttpPost]
		public void AddBruger(Bruger bruger)
		{
			Console.WriteLine("addBruger - brugerController");
			Brugere.AddBruger(bruger);
		}

		[HttpPut]
		public void UpdateBruger(Bruger bruger)
        {
            Console.WriteLine("updateBruger - brugerController");
			Brugere.UpdateBruger(bruger);
        }

		[HttpDelete]
		public void DeleteBruger(string brugerEmail)
		{
			Console.WriteLine("deleteBruger - brugerController");
			Brugere.DeleteBruger(brugerEmail);
		}

		[HttpGet("getkompetencer")]
		public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            Console.WriteLine("getAlleKompetencer - frivilligController");
			return await Brugere.GetAlleKompetencer();
        }

	}
}
