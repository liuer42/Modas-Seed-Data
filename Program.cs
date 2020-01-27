using System;
using System.Collections.Generic;

namespace Assignment_01_Seed_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Location> locationList = new List<Location>(){
                new Location { LocationId = 1, Name = "Bedroom"},
                new Location { LocationId = 2, Name = "Front Door"},
                new Location { LocationId = 3, Name = "Office"},
                new Location { LocationId = 4, Name = "Garage"},
                new Location { LocationId = 5, Name = "Basement"},
            };

            var currentDate = DateTime.Now;
            DateTime eventDate = currentDate.AddMonths(-6);

            List<Event> events = new List<Event>();

            CreateEvents(locationList, currentDate, eventDate, events);

            foreach (Event e in events)
            {
                Console.WriteLine($"{e.TimeStamp}, {e.Location.Name}");
            }
            
        }

        public static void CreateEvents(List<Location> Locations, DateTime currentDate, DateTime eventDate, List<Event> events)
        {
            Random rand = new Random();
            int num = rand.Next(0, 6);

            SortedList<DateTime, Event> dailyEvents = new SortedList<DateTime, Event>();
            while (eventDate < currentDate)
            { 
                for (int i = 0; i < num; i++)
                {
                    int hour = rand.Next(0, 24);
                    int minute = rand.Next(0, 60);
                    int second = rand.Next(0, 60);
                    int loc = rand.Next(0, Locations.Count);

                    DateTime d = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, minute, second);
                    Event e = new Event
                    {
                        Flagged = false, 
                        Location = Locations[loc], 
                        LocationId = Locations[loc].LocationId, 
                        TimeStamp = d
                    };
                    dailyEvents.Add(d, e);
                }

                foreach (var de in dailyEvents)
                {
                    events.Add(de.Value);
                }
                eventDate = eventDate.AddDays(1);
            }
            
        }
    }
}
