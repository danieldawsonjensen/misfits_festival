using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IFrivilligService
	{
		// koordinator funktioner
		Task<Bruger[]?> GetAlleFrivillige(); // metode til get af alle frivillige


		// frivillig funktioner
		Task<int> AddBruger(Bruger bruger);

		Task<int> UpdateBruger(Bruger bruger);

		Task<int> DeleteBruger(string brugerEmail);

        Task<Kompetence[]?> GetAlleKompetencer();
	}
}