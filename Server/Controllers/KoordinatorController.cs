using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using misfits_festival.Shared.Models;
using misfits_festival.Server.Models;
using Dapper;
using Npgsql;
using misfits_festival.Client.Services;
using System.Net.Http;
using Microsoft.Net.Http;

namespace misfits_festival.Server.Controllers
{
    [ApiController]
    [Route("api/koordinator")]

    public class KoordinatorController : ControllerBase // nedarvning fra ControllerBase er meget vigtig
    {
        private readonly IKoordinatorRepository Vagter = new KoordinatorRepository(); // definerer en ny instans af interfacet med
                                                                                      // metoderne til CRUD funktionalitet

        public KoordinatorController(IKoordinatorRepository koordinatorRepository)
        {
            if (Vagter == null && koordinatorRepository != null)
            {
                Vagter = koordinatorRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Vagt>> GetAlleVagter() // http get til samtlige vagter, både bookede og ledige
        {
            Console.WriteLine("getAlleVagter - koordinatorController");
            return await Vagter.GetAlleVagter();
        }


        [HttpPost("addvagt")]
        public void AddVagt(Vagt vagt) // http post til at tilføje en ny vagt til tabellen
        {
            Console.WriteLine("addVagt - koordinatorController");
            Vagter.AddVagt(vagt);
        }

        [HttpPut("updatevagt")]
        public void UpdateVagt(int vagtId, Vagt vagt) // http post til opdatering af en vagt, evt ændring af tid, opgave etc
        {
            Console.WriteLine("updateVagt - koordinatorController");
            Vagter.UpdateVagt(vagtId, vagt);
        }

        [HttpDelete]
        public void DeleteVagt(int vagtId) // http delete til at slette en vagt fra tabellen
        {
            Console.WriteLine("deleteVagt - koordinatorController");
            Vagter.DeleteVagt(vagtId);
        }

        [HttpPost("postopgave")]
        public void AddOpgave(Opgave opgave) // http post til at tilføje en ny opgave
        {
            Console.WriteLine("addOpgave - koordinatorController");
            Vagter.AddOpgave(opgave);
        }

        [HttpGet("getfrivillige")]
        public async Task<IEnumerable<Bruger>> GetAlleFrivillige() // http get på alle frivillige i systemet
        {
            Console.WriteLine("getAlleFrivillige - koordinatorController");
            return await Vagter.GetAlleFrivillige();
        }

    }
}