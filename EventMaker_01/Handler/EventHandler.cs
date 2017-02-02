using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker_01.Converter;
using EventMaker_01.Model;
using EventMaker_01.ViewModel;

namespace EventMaker_01.Handler
{
    public class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }
        
        

        public EventHandler(EventViewModel eventViewModel)
        {
            EventViewModel = eventViewModel;
        }

        public void CreateEvent()
        {
            Event newEvent = new Event
            (
                EventViewModel.Id,
                EventViewModel.Name,
                EventViewModel.Description,
                EventViewModel.Place,
                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time)
            );

            EventViewModel.EventCatalogSingleton.AddEvent(newEvent);
        }

        
    }
}
