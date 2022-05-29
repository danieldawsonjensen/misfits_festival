using System.ComponentModel.DataAnnotations;
using System;

namespace misfits_festival.Shared.Models
{
    public class Bruger
    {
        public int? BrugerId { get; set; }
        public string BrugerNavn { get; set; }
        public string? BrugerEmail { get; set; }
        public string TelefonNummer { get; set; }
        public int RolleId { get; set; }

        public string? Kompetencer { get; set; }

        // public DateOnly FødselsDato { get; set; } // alder skal være 16+


        public Bruger()
        {

        }
    }
}