using System;


namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, string user, DateTime date, string desc)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
            Desc = desc;
            Created = DateTime.Now;
        }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }
        public string Desc { get; private set; }
        public DateTime Created { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }
        public void MarkAsUndone()
        {
            Done = false;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void UpdateDesc(string desc)
        {
            Desc = desc;
        }
    }
}