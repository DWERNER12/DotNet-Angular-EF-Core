using Application.Interfaces;
using Domain;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EventsService : IEventsService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IEventPersistence _eventsPersistence;
        public EventsService(IGeneralPersistence generalPersistence, IEventPersistence eventPersistence)
        {
            _generalPersistence = generalPersistence;
            _eventsPersistence = eventPersistence;
        }

        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _generalPersistence.Add<Event>(model);
                if (await _generalPersistence.SaveChangesAsync()) 
                {
                    return await _eventsPersistence.GetEventsByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var eventDb = await _eventsPersistence.GetEventsByIdAsync(eventId);
                if (eventDb == null) return null;

                model.Id = eventDb.Id;

                _generalPersistence.Update(model);
                if (await _generalPersistence.SaveChangesAsync())
                {
                    return await _eventsPersistence.GetEventsByIdAsync(model.Id);
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var eventDb = await _eventsPersistence.GetEventsByIdAsync(eventId);
                if (eventDb == null) throw new Exception("Evento não encontrado!") ;

                _generalPersistence.Delete<Event>(eventDb);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Event>> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var eventsDb = await _eventsPersistence.GetAllEventsAsync(includeSpeakers);
                if (eventsDb == null) return null;

                return eventsDb;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Event>> GetAllEventsByNameAsync(string name, bool includeSpeakers = false)
        {
            try
            {
                var eventDb = await _eventsPersistence.GetAllEventsByNameAsync(name, includeSpeakers);
                if (eventDb == null) return null;
                
                return eventDb;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventsByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var eventDb = await _eventsPersistence.GetEventsByIdAsync(eventId, includeSpeakers);
                if (eventDb == null) return null;
                
                return eventDb;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
