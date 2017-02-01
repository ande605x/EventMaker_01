using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker_01.Model
{
    class EventCatalogSingleton
    {

    
        public ObservableCollection<Event> Events { get; set; }

        public EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            
        }

        public void AddEvent(int id,string name,string description,string place,DateTime dateTime)
        {
            Event nyEvent = new Event(id,name,description,place,dateTime);
            Events.Add(nyEvent);

        }
    }
}
