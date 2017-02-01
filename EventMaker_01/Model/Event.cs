using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker_01.Model
{
    class Event
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
    }
}
