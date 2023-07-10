using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    internal interface ISocialNetworkPersistence
    {
        Task<List<SocialNetwork>> GetAllSocialNetworksByNameAsync(string name, bool includeEvents);
        Task<List<SocialNetwork>> GetAllSocialNetworksAsync(bool includeEvents);
        Task<SocialNetwork> GetSocialNetworksByIdAsync(int socialNetworkId, bool includeEvents);
    }
}
