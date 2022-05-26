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
	public interface IKoordinatorRepository
	{
		Task<IEnumerable<Vagt>> GetAlleVagter(); // metode til get alle vagter i systemet

		void AddVagt(Vagt vagt); // metode til at poste en ny vagt

		void UpdateVagt(int vagtId, Vagt vagt); // metode til at update en vagt

		void DeleteVagt(int id); // metode til delete af en vagt

		void AddOpgave(Opgave opgave); // metode til post af en ny opgave

		Task<IEnumerable<Opgave>> GetAlleOpgaver();

		Task<IEnumerable<Bruger>> GetAlleFrivillige(); // task til at hente alle frivillige i systemet

	}
}
