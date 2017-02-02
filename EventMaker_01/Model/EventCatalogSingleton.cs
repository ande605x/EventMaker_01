using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input.ForceFeedback;
using Windows.UI.Input;
using EventMaker_01.Persistency;
using Newtonsoft.Json;


namespace EventMaker_01.Model
{
    public class EventCatalogSingleton
    {


        public PersistencyService ps;

        private ObservableCollection<Event> events;

        public ObservableCollection<Event> Events
        {
            get { return events; }
            set { events = value; }
        }


        private static EventCatalogSingleton instance;

        public static EventCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventCatalogSingleton();
                }

                return instance;
            }
        }


        public EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();

            ps = new PersistencyService();
            // Bruges som test dummi test date, for at se om listview er bindet rigtigt.
            //Event minEvent = new Event(01, "Fest", "Mega Stor Fest", "Her", new DateTime(2016, 05, 25));
            //Events.Add(minEvent);
            LoadEventsAsync();

        }

        public void AddEvent(Event e)
        {
            this.Events.Add(e);

            PersistencyService.SaveEventsAsJsonAsync(Events);

        }

        public void RemoveEvent(Event e)
        {
            Events.Remove(e);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }


        public async void LoadEventsAsync()
        {
            var events = await PersistencyService.LoadEventsFromJsonAsync();
            if (events != null)
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            else
            {
                Event OpretEvent = new Event(1,"Event navn her", "Forklaring her", "Sted her",new DateTime(2017, 06,27,12,10,00));
                

                Events.Add(OpretEvent);
                PersistencyService.SaveEventsAsJsonAsync(Events);


            }

        }

    }
}
