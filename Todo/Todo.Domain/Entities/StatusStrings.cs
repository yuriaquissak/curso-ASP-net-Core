using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Todo.Domain.Entities
{
    public class StatusStrings
    {
        public StatusStrings(string server, string database)
        {
            Server = server;
            Database = database;
        }
        public string Server { get; private set; }
        public string Database { get; private set; }
    }
}
