using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IOpgaveService
	{
		Task<int> AddOpgave(Opgave opgave); // metode til post af en ny instans af opgave klassen

		Task<Opgave[]?> GetAlleOpgaver();

		Task<int> UpdateOpgave(Opgave opgave);

		Task<int> DeleteOpgave(int opgaveId);
	}
}
