using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    internal interface IEventAssignedSpeakerPersistence
    {
        Task<List<EventAssignedSpeaker>> GetAllEventsAssignedSpeakersByNameAsync(string name, bool includeSpeakers);
        Task<List<EventAssignedSpeaker>> GetAllEventsAssignedSpeakersAsync(bool includeSpeakers);
        Task<EventAssignedSpeaker> GetEventsAssignedSpeakersByIdAsync(int eventId, bool includeSpeakers);
    }
}
