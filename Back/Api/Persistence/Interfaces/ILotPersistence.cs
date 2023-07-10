using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    internal interface ILotPersistence
    {
        Task<List<Lot>> GetAllLotsByNameAsync(string name, bool includeEvents = false);
        Task<List<Lot>> GetAllLotsAsync(bool includeEvents = false);
        Task<Lot> GetLotsByIdAsync(int lotId, bool includeEvents = false);
    }
}
