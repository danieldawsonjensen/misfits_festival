using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IKoordinatorService
	{
		Task<Vagt[]?> GetAlleVagter(); // metode til get på samtlige vagter

		Task<int> AddVagt(Vagt vagt); // metode til post af en ny instans af vagt klassen

		Task<int> DeleteVagt(int id); // metode til delete af en vagt, bruger et specifikt vagtId

		Task<int> UpdateVagt(int vagtId, Vagt vagt); // metode til update på en vagt, bruger et vagtId, samt en instans af vagt klassen

		Task<int> AddOpgave(Opgave opgave); // metode til post af en ny instans af opgave klassen

		Task<Opgave[]?> GetAlleOpgaver();

		Task<Bruger[]?> GetAlleFrivillige(); // metode til get af alle frivillige

	}
}
