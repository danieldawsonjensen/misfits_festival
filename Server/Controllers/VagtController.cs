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
	[Route("api/vagter")]

	public class VagtController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
	{
		private readonly IVagtRepository Vagter = new VagtRepository(); // definerer en ny instans af interfacet med
																					 // metoderne til CRUD funktionalitet

		public VagtController(IVagtRepository vagtRepository)
		{
			if (Vagter == null && vagtRepository != null)
			{
				Vagter = vagtRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet]
		public async Task<IEnumerable<Vagt>> GetAlleVagter() // http get til samtlige vagter, både bookede og ledige
		{
			Console.WriteLine("getAlleVagter - vagtController");
			return await Vagter.GetAlleVagter();
		}


		[HttpPost]
		public void AddVagt(Vagt vagt) // http post til at tilføje en ny vagt til tabellen
		{
			Console.WriteLine("addVagt - vagtController");
			Vagter.AddVagt(vagt);
		}

		[HttpPut]
		public void UpdateVagt(Vagt vagt) // http putt til opdatering af en vagt, evt ændring af tid, opgave etc
		{
			Console.WriteLine("updateVagt - vagtController");
			Vagter.UpdateVagt(vagt);
		}

		[HttpDelete]
		public void DeleteVagt(int vagtId) // http delete til at slette en vagt fra tabellen
		{
			Console.WriteLine("deleteVagt - vagtController");
			Vagter.DeleteVagt(vagtId);
		}


		//frivillig funktioner
		[HttpGet("brugervagter")]
		public async Task<IEnumerable<Vagt>> GetMineVagter(string brugerEmail) // http get task til vagter med et specifikt brugerId
		{
			Console.WriteLine("getminevagter - vagtController");
			return await Vagter.GetMineVagter(brugerEmail);
		}

		[HttpGet("ledigevagter")]
		public async Task<IEnumerable<Vagt>> GetLedigeVagter() // http get task til vagter der er ledige
		{
			Console.WriteLine("getledigevagter - vagtController");
			return await Vagter.GetLedigeVagter();
		}

		[HttpPut("bookvagt")]
		public void BookVagt(Vagt vagt) // http post til booking af en vagt, bruger et brugerId og
													  // vagtId'et til den vagt man vil booke
		{
			Console.WriteLine("getledigevagter - vagtController");
			Vagter.BookVagt(vagt);
		}


	}
}