using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Core.Events.SQL.SQLDepedency;

namespace Core.Events.SQL
{
    public class SQLDepedencyAdapter<T> : IDisposable where T : class
    {
        public readonly SQLDepedency Listener;

        private readonly static string DATABASE_NAME = "lessla";
        private readonly static string DATABASE_TABLE_NAME = "logs";

        public SQLDepedencyAdapter(string connectionString)
        {
            Listener = new SQLDepedency(connectionString, DATABASE_NAME, DATABASE_TABLE_NAME);

            Listener.TableChanged += HandleChange;

            Listener.Start();
        }

        private void HandleChange(object? _, TableChangedEventArgs @event) { 
            if(@event.NotificationType == NotificationTypes.Insert && @event.Data != null)
            {
                var dataElement = @event.Data.Element("inserted");

                if(dataElement != null)
                {
                    var rows = dataElement.Elements("row");

                    foreach(var row in rows ) {
                        if (row != null)
                        {
                            var entity = CastRow(row);
                        }
                    }
                }
            }
        }

        private T? CastRow(XElement element) =>
            (T) new XmlSerializer(element.GetType()).Deserialize(element.CreateReader())!;

        public void Dispose() =>
            Listener.Stop();
    }
}
