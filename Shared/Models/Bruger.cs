using System;

namespace misfits_festival.Shared.Models
{
    public class Bruger
    {
        public int BrugerId { get; set; }
        public string BrugerNavn { get; set; }
        public string BrugerEmail { get; set; }
        public int TelefonNummer { get; set; }
        public int RolleId { get; set; }

        public int[]? KompetenceId { get; set; }
        public string[]? KompetenceBeskrivelse { get; set; }

        // public DateOnly FødselsDato { get; set; } // alder skal være 16+


        public Bruger()
        {

        }
    }
}