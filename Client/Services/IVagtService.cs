using System;
using misfits_festival.Shared.Models;

namespace misfits_festival.Client.Services
{
    public interface IVagtService
    {
        // koordinator funktioner
        Task<Vagt[]?> GetAlleVagter(); // metode til get på samtlige vagter

        Task<int> AddVagt(Vagt vagt); // metode til post af en ny instans af vagt klassen

        Task<int> DeleteVagt(int? id); // metode til delete af en vagt, bruger et specifikt vagtId

        Task<int> UpdateVagt(Vagt vagt); // metode til update på en vagt, bruger et vagtId, samt en instans af vagt klassen


        // frivillig funktioner
        Task<Vagt[]?> GetMineVagter(string? brugerEmail); // metode til get på alle ledige vagter

        Task<Vagt[]?> GetLedigeVagter(); // metode til get på alle ledige vagter

        Task<int> BookVagt(Vagt vagt); // metode til booking af en vagt
    }
}
