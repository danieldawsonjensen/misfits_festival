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
	public interface IVagtRepository
	{
		// koordinator funktioner
		Task<IEnumerable<Vagt>> GetAlleVagter(); // metode til get alle vagter i systemet

		void AddVagt(Vagt vagt); // metode til at poste en ny vagt

		void UpdateVagt(Vagt vagt); // metode til at update en vagt

		void DeleteVagt(int? id); // metode til delete af en vagt


		// frivillig funktioner
		Task<IEnumerable<Vagt>> GetMineVagter(string? brugerEmail); //skal muligvis være int brugerId // metode til at se sine egne bookede vagter

		Task<IEnumerable<Vagt>> GetLedigeVagter(); // metode til at se alle de nuværende ledige vagter

		void BookVagt(Vagt vagt);
	}
}
