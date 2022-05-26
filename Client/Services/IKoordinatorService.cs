﻿using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
	public interface IKoordinatorService
	{
		
		Task<int> AddOpgave(Opgave opgave); // metode til post af en ny instans af opgave klassen

		Task<Opgave[]?> GetAlleOpgaver();

		Task<Bruger[]?> GetAlleFrivillige(); // metode til get af alle frivillige

	}
}
