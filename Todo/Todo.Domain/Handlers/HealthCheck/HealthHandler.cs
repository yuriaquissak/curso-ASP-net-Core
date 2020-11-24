using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers.HealthCheck
{
     public class HealthHandler
        
    {
        string strName;
        string strDataBase;
        TodoItem Test;
        private readonly ITodoRepository _repository;
        public HealthHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public StatusStrings Handle(string str)
        {
            string[] substrings = str.Split(';');
            strName = substrings[0];
            strDataBase = substrings[1];
            return new StatusStrings(strName, strDataBase);
        }
        public Stopwatch Watch(ITodoRepository repository)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Test = repository.GetTest();
            stopwatch.Stop();
            return stopwatch;
        }
        
    }
}
