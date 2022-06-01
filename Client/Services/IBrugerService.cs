using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IBrugerService
	{
		// koordinator funktioner
		Task<Bruger[]?> GetAlleFrivillige(); // metode til get af alle frivillige

        Task<Bruger[]?> GetAlleKoordinatorer();


		// frivillig funktioner
		Task<Bruger[]?> GetBruger(string? brugerEmail);

		Task<int> AddBruger(Bruger bruger);

		Task<int> UpdateBruger(Bruger bruger);

		Task<int> DeleteBruger(string brugerEmail);

        Task<Kompetence[]?> GetAlleKompetencer();

		Task<int> UpdateKompetencer(Bruger bruger, Kompetence kompetence);
	}
}