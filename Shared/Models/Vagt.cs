using System;

namespace misfits_festival.Shared.Models
{
    public class Vagt
    {
        public int VagtId { get; set; }
        public DateTime Dato { get; set; }
        public TimeSpan VagtStart { get; set; }
        public TimeSpan VagtSlut { get; set; }
        public int Pause { get; set; }
        public string Område { get; set; }
        public int OpgaveId { get; set; }
        public string OpgaveBeskrivelse { get; set; }

        // public bool ErBooket { get; set; }

        public int BrugerId { get; set; }

        public Vagt()
        {
        }
    }
}
