using System;
using Todo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Todo.Domain.Commands
{
	public class CreateTodoCommand : Notifiable, ICommand
	{
		public CreateTodoCommand() { }

		public CreateTodoCommand(string title, string user, DateTime date, string desc)
		{
			Title = title;
			User = user;
			Date = date;
			Desc = desc;
		}
		
		public string Title { get; set; }
		public string User { get; set; }
		public DateTime Date { get; set; }
		public string Desc { get; set; }

		public void Validate()
		{
			AddNotifications(
				new Contract()
					.Requires()
					.HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
					.HasMinLen(User, 6, "User", "Usu�rio invalido!")
					);
		}
	}
}