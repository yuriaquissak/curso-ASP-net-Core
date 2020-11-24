using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validtodo = new TodoItem("Titulinho", "mightyfool", DateTime.Now, "desc");
        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            
            Assert.AreEqual(_validtodo.Done, false);
        }
    }
}