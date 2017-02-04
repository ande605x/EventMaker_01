using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using EventMaker_01.Common;
using EventMaker_01.Model;
using Newtonsoft.Json;

namespace EventMaker_01.Persistency
{
    public class PersistencyService
    {
        
        private static string eventFileName = "AlleEvents.txt";

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string eventsJsonString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(eventsJsonString, eventFileName);
        }


        private static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }

        private static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                MessageDialogHelper.Show("Filen for events blev ikke fundet \n File not found!", ex.Message);
                return null;
            }
        }




    }
}
