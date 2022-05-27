using System;

namespace misfits_festival.Shared.Models
{
    public class Vagt
    {
        public int? VagtId { get; set; }
        public DateTime? Dato { get; set; } = DateTime.Now;
        public string? VagtStart { get; set; }
        public string? VagtSlut { get; set; }
        public int? Pause { get; set; }
        public string? Område { get; set; }

        public int? OpgaveId { get; set; }

        public string? OpgaveBeskrivelse { get; set; }

        // public string Status { get; set; }

        public int? BrugerId { get; set; }
        public string? BrugerEmail { get; set; }

        public string? Status { get; set; }

        public Vagt()
        {
        }
    }
}
