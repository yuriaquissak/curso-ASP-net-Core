using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user, string desc)
        {
            Id = id;
            Title = title;
            User = user;
            Desc = desc;
        }
        public Guid Id { get; set; }
        public string Title { get; set;  }
        public string User { get; set; }
        public string Desc { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa")
                    .HasMinLen(User, 6, "User", "Usu�rio inv�lido")
                    .HasMinLen(Desc, 3, "Desc", "Por favor, descreva melhor esta tarefa")
                    );
        }
    }
}