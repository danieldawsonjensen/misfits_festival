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


        [HttpGet("getfrivillige")]
        public async Task<IEnumerable<Bruger>> GetAlleFrivillige() // http get på alle frivillige i systemet
        {
            Console.WriteLine("getAlleFrivillige - koordinatorController");
            return await Vagter.GetAlleFrivillige();
        }

    }
}