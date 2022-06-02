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
	// i controlleren defineres de diverse api-endepunkter der benyttes af metoderne

	[ApiController]
	[Route("api/vagter")]

	// nedarvning fra ControllerBase er meget vigtig til api requests
	public class VagtController : ControllerBase
	{
		private readonly IVagtRepository Vagter = new VagtRepository();

		public VagtController(IVagtRepository vagtRepository)
		{
			if (Vagter == null && vagtRepository != null)
			{
				Vagter = vagtRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		// koordinator funktioner
		[HttpGet("allevagter")] // eftersom der er flere get metoder ifm vagter, defineres et ekstra endepunkt her
		public async Task<IEnumerable<Vagt>> GetAlleVagter()
		{
			Console.WriteLine("getAlleVagter - vagtController");
			return await Vagter.GetAlleVagter();
		}


		[HttpPost]
		public void AddVagt(Vagt vagt)
		{
			Console.WriteLine("addVagt - vagtController");
			Vagter.AddVagt(vagt);
		}

		[HttpPut("updatevagt")]
		public void UpdateVagt(Vagt vagt)
		{
			Console.WriteLine("updateVagt - vagtController");
			Vagter.UpdateVagt(vagt);
		}

		[HttpDelete("{vagtId:int?}")] //vagtId hentes fra VagtService som modtager ID'et fra razor siden
		public void DeleteVagt(int? vagtId)
		{
			Console.WriteLine("deleteVagt - vagtController" + vagtId);
			Vagter.DeleteVagt(vagtId);
		}


		//frivillig funktioner
		[HttpGet("{brugerEmail}")] // brugerEmail hentes fra VagtService som modtager mail fra razor siden
		public async Task<IEnumerable<Vagt>> GetMineVagter(string? brugerEmail)
		{
			Console.WriteLine("getminevagter - vagtController");
			return await Vagter.GetMineVagter(brugerEmail);
		}

		[HttpGet("ledigevagter")] // eftersom der er flere get metoder ifm vagter, defineres et ekstra endepunkt her
		public async Task<IEnumerable<Vagt>> GetLedigeVagter()
		{
			Console.WriteLine("getledigevagter - vagtController");
			return await Vagter.GetLedigeVagter();
		}

		[HttpPut("bookvagt")] // eftersom der er flere put metoder ifm vagter, defineres et ekstra endepunkt her
		public void BookVagt(Vagt vagt)
		{
			Console.WriteLine("bookvagt - vagtController");
			Vagter.BookVagt(vagt);
		}


	}
}
