using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input.ForceFeedback;
using Windows.UI.Input;


namespace EventMaker_01.Model
{
    public class EventCatalogSingleton
    {

    
        public ObservableCollection<Event> Events { get; set; }

      


        public EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            Event minEvent = new Event(01, "Fest", "Mega Stor Fest", "Her", new DateTime(2016, 05, 25));
            Events.Add(minEvent);

        }

        public void AddEvent(int id,string name,string description,string place,DateTime dateTime)
        {
            Event nyEvent = new Event(id,name,description,place,dateTime);
            Events.Add(nyEvent);
            

        }
    }
}
