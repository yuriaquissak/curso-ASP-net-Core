using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
	public interface ITodoRepository
	{
		void Create(TodoItem todo);
		void Update(TodoItem todo);
		TodoItem GetTest();
		TodoItem GetById(Guid id, string user);

		IEnumerable<TodoItem> GetAllUsers();

		IEnumerable<TodoItem> GetAll(string user);
		IEnumerable<TodoItem> GettAllDone(string user);
		IEnumerable<TodoItem> GetAllUndone(string user);
		IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
	}
}