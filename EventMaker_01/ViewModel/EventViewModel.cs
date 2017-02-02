using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker_01.Common;
using EventMaker_01.Handler;
using EventMaker_01.Model;

namespace EventMaker_01.ViewModel
{
    public class EventViewModel
    {
        public EventCatalogSingleton EventCatalogSingleton { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        private DateTimeOffset date;

        public DateTimeOffset Date      
        {
            get { return date; }
            set { date = value; }
        }

        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        private ICommand createEventCommand;

        public ICommand CreateEventCommand
        {
            get { return createEventCommand; }
            set { createEventCommand = value; }
        }

        public Handler.EventHandler EventHandler { get; set; }



        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0,0,0,0, new TimeSpan());
            time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            EventHandler = new Handler.EventHandler(this);

            createEventCommand = new RelayCommand(EventHandler.CreateEvent,null);

            EventCatalogSingleton = EventCatalogSingleton.Instance;
        }
    }
}
