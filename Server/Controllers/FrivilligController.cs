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
	[Route("api/frivillig")]

	public class FrivilligController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
	{
		private readonly IFrivilligRepository Frivillig = new FrivilligRepository(); // definerer en ny instans af interfacet med
																				  // metoderne til CRUD funktionalitet

		public FrivilligController(IFrivilligRepository frivilligRepository)
		{
			if (Frivillig == null && frivilligRepository != null)
			{
				Frivillig = frivilligRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet("brugervagter")]
		public async Task<IEnumerable<Vagt>> GetMineVagter(int brugerId) // http get task til vagter med et specifikt brugerId
		{
			Console.WriteLine("getledigevagter - frivilligController");
			return await Frivillig.GetMineVagter(brugerId);
		}

		[HttpGet("ledigevagter")]
		public async Task<IEnumerable<Vagt>> GetLedigeVagter() // http get task til vagter der er ledige
		{
			Console.WriteLine("getledigevagter - frivilligController");
			return await Frivillig.GetLedigeVagter();
		}

		[HttpPost]
		public void BookVagt(int vagtId, int brugerId) // http post til booking af en vagt, bruger et brugerId og
													   // vagtId'et til den vagt man vil booke
		{
			Console.WriteLine("bookVagt - frivilligController");
			Frivillig.BookVagt(vagtId, brugerId);
		}

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
		public async void UpdateKompetencer(int brugerId, int kompetenceId)
        {
            Console.WriteLine("updateKompetencer - frivilligController");
			Frivillig.UpdateKompetencer(brugerId, kompetenceId);
        }

	}
}
