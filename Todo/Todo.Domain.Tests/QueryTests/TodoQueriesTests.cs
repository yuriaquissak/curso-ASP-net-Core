using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;
        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now, "desc"));
            _items.Add(new TodoItem("Tarefa 2", "mightyfool", DateTime.Now, "desc"));
            _items.Add(new TodoItem("Tarefa 3", "usuarioA", DateTime.Now, "desc"));
            _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now, "desc"));
            _items.Add(new TodoItem("Tarefa 5", "mightyfool", DateTime.Now, "desc"));
        }
        [TestMethod]
        public void Dada_consulta_retornar_tarefas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("mightyfool"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Dada_consulta_retornar_tarefas_feitas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("mightyfool"));
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void Dada_consulta_retornar_tarefas_nao_feitas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("mightyfool"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Dada_consulta_retornar_tarefas_de_agora_nao_feitas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("mightyfool", DateTime.Now, false));
            Assert.AreEqual(2, result.Count());
        }
    }
}