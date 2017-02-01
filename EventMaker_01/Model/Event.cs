using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EventMaker_01.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }

        public Event(int id,string name,string description,string place,DateTime dateTime)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Place = place;
            this.DateTime = dateTime;
        }

        public override string ToString()
        {
            return string.Format("Id: {0} Name: {1} Description: {2} Place: {3} DateTime: {4}", Id, Name, Description, Place, DateTime);
        }
    }
}
