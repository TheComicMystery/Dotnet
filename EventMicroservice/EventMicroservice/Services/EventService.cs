using EventMicroservice.Models;
using System.Collections.Generic;

namespace EventMicroservice.Services
{
    public class EventService
    {
        private readonly List<Event> _events = new List<Event>();

        public List<Event> GetAllEvents()
        {
            return _events;
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }
    }
}
