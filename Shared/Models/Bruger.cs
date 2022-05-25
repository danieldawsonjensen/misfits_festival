using System.ComponentModel.DataAnnotations;
using System;

namespace misfits_festival.Shared.Models
{
    public class Bruger
    {
        [Required]
        public int BrugerId { get; set; }

        [Required]
        public string BrugerNavn { get; set; }

        [Required]
        public string BrugerEmail { get; set; }

        [Required]
        public string TelefonNummer { get; set; }

        [Required]
        public int RolleId { get; set; }

        public string Kompetencer { get; set; }

        // public DateOnly FødselsDato { get; set; } // alder skal være 16+


        public Bruger()
        {

        }
    }
}