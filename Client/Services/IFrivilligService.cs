using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IFrivilligService
	{
		Task<Vagt[]?> GetLedigeVagter(); // metode til get på alle ledige vagter

		Task<Vagt[]?> GetMineVagter(); // metode til get på alle ledige vagter

		Task<int> BookVagt(Vagt vagt); // metode til booking af en vagt
	}
}