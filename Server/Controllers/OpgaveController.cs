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
	[Route("api/opgaver")]

	public class OpgaveController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
	{
		private readonly IOpgaveRepository Opgaver = new OpgaveRepository(); // definerer en ny instans af interfacet med
																					 // metoderne til CRUD funktionalitet

		public OpgaveController(IOpgaveRepository opgaveRepository)
		{
			if (Opgaver == null && opgaveRepository != null)
			{
				Opgaver = opgaveRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet]
		public async Task<IEnumerable<Opgave>> GetAlleOpgaver()
		{
			Console.WriteLine("getAlleOpgaver - opgaveController");
			return await Opgaver.GetAlleOpgaver();
		}

		[HttpPost]
		public void AddOpgave(Opgave opgave) // http post til at tilføje en ny opgave
		{
			Console.WriteLine("addOpgave - opgaveController");
			Opgaver.AddOpgave(opgave);
		}

        [HttpPut]
		public void UpdateOpgave(Opgave opgave)
        {
			Console.WriteLine("updateOpgave - opgaveController");
			Opgaver.UpdateOpgave(opgave);
		}

        [HttpDelete]
		public void DeleteOpgave(int? opgaveId)
        {
			Console.WriteLine("deleteOpgave - opgaveController");
			Opgaver.DeleteOpgave(opgaveId);
		}
	
	}
}
