using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustWanna.Web.Models
{
    public class ReservationForUniqueFieldValue
    {
        public string Id { get; set; }
    }
    public class User : INamedDocument
    {
        public User(string name)
        {
            Name = name;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public IList<string> Friends { get; private set; }
        public IList<UserActivity> Activities { get; private set; }

        public void AddActivity(Activity activity)
        {
            Activities.Add(new UserActivity(this, activity));
        }
    }
    public class Activity
    {
        public Activity(string title)
        {
            Title = title;
        }
        public string Id { get; private set; }
        public string Title { get; private set; }
        public Location Location { get; private set; }
        public ITemporalExpression Expression { get; private set; }
    }
    public class Location
    {
        public string Input { get; set; }
    }
    public class DayInMonthTemporalExpression : ITemporalExpression
    {
        public bool Includes(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
    public interface ITemporalExpression
    {
        bool Includes(DateTime date);
    }
    public class Schedule
    {
        
    }
    public class UserActivity
    {
        public UserActivity(User user, Activity activity)
        {
            UserId = user.Id;
            ActivityId = activity.Id;
        }
        public string UserId { get; private set; }
        public string ActivityId { get; private set; }
    }

    public class DenormalizedReference<T> where T : INamedDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static implicit operator DenormalizedReference<T>(T doc)
        {
            return new DenormalizedReference<T>
                       {
                           Id = doc.Id,
                           Name = doc.Name
                       };
        }
    }

    public interface INamedDocument
    {
        string Id { get; }
        string Name { get; }
    }
}