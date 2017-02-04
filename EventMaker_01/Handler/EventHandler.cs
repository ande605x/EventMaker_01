using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using EventMaker_01.Common;
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
            try
            {
                if (EventViewModel.Name != null)
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
                else
                {
                    throw new ArgumentException("En ny event blev ikke oprettet!");
                }
            }
            catch (Exception ex)
            {

                MessageDialogHelper.Show("'Når man opretter en ny event skal alle felterne udfyldes!", ex.Message);
            }
        }

        public async void DeleteEvent()
        {
            EventViewModel.EventCatalogSingleton.RemoveEvent(EventViewModel.SelectedEvent);
        }

        public void RestoreEvent()
        {
            EventViewModel.EventCatalogSingleton.RemoveSlettetEvents(EventViewModel.SelectedEvent);
            
        }

        public void DeleteEventForGood()
        {
            EventViewModel.EventCatalogSingleton.DeleteEventForever(EventViewModel.SelectedEvent);
        }
        
    }
}
