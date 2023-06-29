using Domain;

namespace Persistence.Interfaces
{
    public interface ISpeakerPersistence
    {
        Task<List<Speaker>> GetAllSpeakersByNameAsync(string name, bool includeEvents);
        Task<List<Speaker>> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakersByIdAsync(int speakerId, bool includeEvents);
    }
}
