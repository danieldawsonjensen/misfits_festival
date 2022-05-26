﻿using System;
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

	public class FrivilligController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
	{
		private readonly IBrugerRepository Brugere = new BrugerRepository(); // definerer en ny instans af interfacet med
																				  // metoderne til CRUD funktionalitet

		public FrivilligController(IBrugerRepository brugerRepository)
		{
			if (Brugere == null && brugerRepository != null)
			{
				Frivillig = brugerRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet]
		public async Task<IEnumerable<Bruger>> GetAlleFrivillige() // http get på alle frivillige i systemet
		{
			Console.WriteLine("getAlleFrivillige - koordinatorController");
			return await Brugere.GetAlleFrivillige();
		}


		// frivillig funktioner
		

		[HttpPost("addbruger")]
		public void AddBruger(Bruger bruger) // http post til at tilføje en ny vagt til tabellen
		{
			Console.WriteLine("addBruger - frivilligController");
			Frivillig.AddBruger(bruger);
		}

        [HttpGet("getkompetencer")]
		public async Task<IEnumerable<Kompetence>> GetAlleKompetencer()
        {
            Console.WriteLine("getAlleKompetencer - frivilligController");
			return await Frivillig.GetAlleKompetencer();
        }

        [HttpPut("updatekompetencer")]
		public void UpdateKompetencer(int brugerId, int kompetenceId)
        {
            Console.WriteLine("updateKompetencer - frivilligController");
			Frivillig.UpdateKompetencer(brugerId, kompetenceId);
        }

	}
}