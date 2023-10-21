using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events.SQL
{
    public class SQLDepedencyAdapter
    {
        public readonly SQLDepedency Listener;

        private readonly static string DATABASE_NAME = "lessla";
        private readonly static string DATABASE_TABLE_NAME = "logs";

        public SQLDepedencyAdapter(string connectionString)
        {
            Listener = new SQLDepedency(connectionString, DATABASE_NAME, DATABASE_TABLE_NAME);

            Listener.TableChanged += (_, _) => HandleChange();
        }

        private void HandleChange() { }
    }
}
