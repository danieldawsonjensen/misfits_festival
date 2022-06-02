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
		Task<IEnumerable<Vagt>> GetAlleVagter();

		void AddVagt(Vagt vagt);

		void UpdateVagt(Vagt vagt);

		void DeleteVagt(int? id);


		// frivillig funktioner
		Task<IEnumerable<Vagt>> GetMineVagter(string? brugerEmail);

		Task<IEnumerable<Vagt>> GetLedigeVagter();

		void BookVagt(Vagt vagt);
	}
}
