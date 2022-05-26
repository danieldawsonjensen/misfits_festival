using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IFrivilligService
	{
		

		Task<int> AddBruger(Bruger bruger);

        Task<Kompetence[]?> GetAlleKompetencer();

		Task<int> UpdateKompetencer(int brugerId, int kompetenceId);
	}
}