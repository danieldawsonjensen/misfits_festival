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
		[HttpGet("allefrivillige")] // eftersom der er flere get metoder ifm brugere, defineres et ekstra endepunkt her
		public async Task<IEnumerable<Bruger>> GetAlleFrivillige()
		{
			Console.WriteLine("getAlleFrivillige - brugerController");
			return await Brugere.GetAlleFrivillige();
		}

		[HttpGet("allekoordinatorer")] // eftersom der er flere get metoder ifm brugere, defineres et ekstra endepunkt her
		public async Task<IEnumerable<Bruger>> GetAlleKoordinatorer()
		{
			Console.WriteLine("getAlleKoordinatorer - brugerController");
			return await Brugere.GetAlleKoordinatorer();
		}


        // frivillig funktioner
        [HttpGet("{brugerEmail}")] // brugerEmail henter email fra BrugerService som modtager specifik email fra razor siden
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

		[HttpGet("getkompetencer")]  // eftersom der er flere get metoder i controlleren, defineres et ekstra endepunkt her
		public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            Console.WriteLine("getAlleKompetencer - frivilligController");
			return await Brugere.GetAlleKompetencer();
        }

		[HttpPut("updatekompetencer")]  // eftersom der er flere put metoder i controlleren, defineres et ekstra endepunkt her
		public void UpdateKompetencer(BrugerKompetence brugerKompetence)
		{
			Console.WriteLine("updateKompetencer - brugerController");
			Brugere.UpdateKompetencer(brugerKompetence);
		}

	}
}
