using System;
namespace misfits_festival.Shared.Models
{
	public class BrugerKompetence
	{
		// denne klasse bruges til at implementere associeringstabellen mellem brugere og kompetencer
		public Bruger? Bruger { get; set; }
		public Kompetence? Kompetence { get; set; }

		public BrugerKompetence()
		{
		}
	}
}

