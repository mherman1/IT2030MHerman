using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<EventApplicationDB>
    {
        protected override void Seed(EventApplicationDB context)
        {
            var eventtypes = new List<EventType>
            {
                new EventType { Type = "Music" },
                new EventType { Type = "Sports" },
                new EventType { Type = "Arts" },
                new EventType { Type = "Film" },
                new EventType { Type = "Culture" },
                new EventType { Type = "Charity" },
                new EventType { Type = "Hobbies" },
                new EventType { Type = "Government" },
                new EventType { Type = "Business" },
                new EventType { Type = "Science" }
            };

            new List<Event>
            {
                new Event {Type = eventtypes.Single(e => e.Type == "Culture"), Title = "Wine HIstory", Description = "", StartDate = new DateTime(2019, 05, 04, 22, 00, 00), EndDate = new DateTime(2019, 05, 04, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Music"), Title = "Vampire Weekend", Description = "", StartDate = new DateTime(2019, 05, 05, 21, 00, 00), EndDate = new DateTime(2019, 05, 05, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Arts"), Title = "Shakespeare Fest", Description = "", StartDate = new DateTime(2019, 05, 07, 12, 00, 00), EndDate = new DateTime(2019, 05, 07, 17, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Film"), Title = "The Princess Bride", Description = "", StartDate = new DateTime(2019, 05, 08, 19, 30, 00), EndDate = new DateTime(2019, 05, 08, 21, 30, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Hobbies"), Title = "Whiskey Tasting", Description = "", StartDate = new DateTime(2019, 05, 09, 12, 00, 00), EndDate = new DateTime(2019, 05, 09, 16, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Sports"), Title = "Tennis Tournament", Description = "", StartDate = new DateTime(2019, 05, 10, 17, 00, 00), EndDate = new DateTime(2019, 05, 10, 20, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cleveland", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Charity"), Title = "Fundraiser", Description = "", StartDate = new DateTime(2019, 05, 04, 22, 00, 00), EndDate = new DateTime(2019, 05, 04, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Music"), Title = "100 One Man Bands", Description = "", StartDate = new DateTime(2019, 05, 07, 21, 00, 00), EndDate = new DateTime(2019, 05, 07, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Arts"), Title = "Metalsmithing Expo", Description = "", StartDate = new DateTime(2019, 05, 06, 18, 00, 00), EndDate = new DateTime(2019, 05, 06, 22, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Film"), Title = "Rush Hour", Description = "", StartDate = new DateTime(2019, 05, 08, 21, 00, 00), EndDate = new DateTime(2019, 05, 08, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Hobbies"), Title = "Colonial Basket Weaving", Description = "", StartDate = new DateTime(2019, 05, 09, 14, 00, 00), EndDate = new DateTime(2019, 05, 09, 18, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Sports"), Title = "Soccer Game", Description = "", StartDate = new DateTime(2019, 05, 11, 16, 30, 00), EndDate = new DateTime(2019, 05, 11, 19, 30, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Akron", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Government"), Title = "City Council Meeting", Description = "", StartDate = new DateTime(2019, 05, 25, 21, 00, 00), EndDate = new DateTime(2019, 05, 25, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Music"), Title = "U2", Description = "", StartDate = new DateTime(2019, 05, 12, 21, 00, 00), EndDate = new DateTime(2019, 05, 12, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Arts"), Title = "Sculpture Today", Description = "", StartDate = new DateTime(2019, 05, 13, 12, 00, 00), EndDate = new DateTime(2019, 05, 13, 21, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Film"), Title = "Fight Club", Description = "", StartDate = new DateTime(2019, 05, 05, 17, 00, 00), EndDate = new DateTime(2019, 05, 05, 19, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Hobbies"), Title = "Gardening Club", Description = "", StartDate = new DateTime(2019, 05, 07, 12, 00, 00), EndDate = new DateTime(2019, 05, 07, 18, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Sports"), Title = "Basketball Game", Description = "", StartDate = new DateTime(2019, 05, 15, 18, 30, 00), EndDate = new DateTime(2019, 05, 15, 21, 30, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Columbus", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Business"), Title = "MBAs Today", Description = "", StartDate = new DateTime(2019, 05, 18, 21, 00, 00), EndDate = new DateTime(2019, 05, 18, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Music"), Title = "String Quartet", Description = "", StartDate = new DateTime(2019, 05, 24, 21, 00, 00), EndDate = new DateTime(2019, 05, 24, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Arts"), Title = "Painting Expo", Description = "", StartDate = new DateTime(2019, 05, 17, 13, 00, 00), EndDate = new DateTime(2019, 05, 17, 17, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Film"), Title = "Bourne Identity", Description = "", StartDate = new DateTime(2019, 05, 20, 21, 00, 00), EndDate = new DateTime(2019, 05, 20, 23, 30, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Hobbies"), Title = "Model Train Show", Description = "", StartDate = new DateTime(2019, 05, 06, 10, 00, 00), EndDate = new DateTime(2019, 05, 06, 17, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Sports"), Title = "Hockey Game", Description = "", StartDate = new DateTime(2019, 05, 12, 19, 00, 00), EndDate = new DateTime(2019, 05, 12, 22, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Cincinnati", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Science"), Title = "River Pollution and You", Description = "", StartDate = new DateTime(2019, 05, 24, 21, 00, 00), EndDate = new DateTime(2019, 05, 24, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Music"), Title = "Ochestra Concert", Description = "", StartDate = new DateTime(2019, 05, 10, 21, 00, 00), EndDate = new DateTime(2019, 05, 10, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Arts"), Title = "Photography Show", Description = "", StartDate = new DateTime(2019, 05, 23, 14, 00, 00), EndDate = new DateTime(2019, 05, 23, 17, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Film"), Title = "Raging Bull", Description = "", StartDate = new DateTime(2019, 05, 16, 18, 00, 00), EndDate = new DateTime(2019, 05, 16, 20, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Hobbies"), Title = "Book Fair", Description = "", StartDate = new DateTime(2019, 05, 28, 11, 00, 00), EndDate = new DateTime(2019, 05, 28, 16, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
                new Event {Type = eventtypes.Single(e => e.Type == "Sports"), Title = "Baseball Game", Description = "", StartDate = new DateTime(2019, 05, 05, 20, 00, 00), EndDate = new DateTime(2019, 05, 05, 23, 00, 00), MaxTickets = 100, AvailableTickets = 100, Organizer = "EventOH!", OrganizerContactInfo = "", City = "Toledo", State = "Ohio"},
            }.ForEach(a => context.Events.Add(a));
        }
    }
}