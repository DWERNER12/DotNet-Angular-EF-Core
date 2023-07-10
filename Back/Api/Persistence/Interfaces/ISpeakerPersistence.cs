using Domain;

namespace Persistence.Interfaces
{
    public interface ISpeakerPersistence
    {
        Task<List<Speaker>> GetAllSpeakersByNameAsync(string name, bool includeEvents = false);
        Task<List<Speaker>> GetAllSpeakersAsync(bool includeEvents = false);
        Task<Speaker> GetSpeakersByIdAsync(int speakerId, bool includeEvents = false);
    }
}
