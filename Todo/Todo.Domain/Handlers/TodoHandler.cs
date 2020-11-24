using Flunt.Notifications;
using System.Runtime.CompilerServices;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada ",
                command.Notifications);
            // Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date, command.Desc);
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada ", command.Notifications);
            // Recupera TodoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);
            todo.UpdateDesc(command.Desc);

            // Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada ", command.Notifications);
            
            // Recupera TodoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            if (todo == null || (todo.User != command.User))
            {
                return new GenericCommandResult(false, "Usuario invalido", command.Notifications);
            }
            else
            {
                todo.MarkAsDone();

                // Salva no banco
                _repository.Update(todo);

                //Retorna o resultado
                return new GenericCommandResult(true, "Tarefa salva", todo);
            }
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada ", command.Notifications);
            // Recupera TodoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            if (todo == null || (todo.User != command.User))
            {
                return new GenericCommandResult(false, "Usuario invalido", command.Notifications);
            }
            todo.MarkAsUndone();

            // Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}

