using Core.Configurations;
using Core.Models.Serilog;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Core.Events.SQL.SQLDepedency;

namespace Core.Events.SQL
{
    public class SQLDepedencyAdapter: IDisposable
    {
        public readonly SQLDepedency Listener;

        private Action<EventLog> OnInsert;

        private readonly static string DATABASE_NAME = "lessla";
        private readonly static string DATABASE_TABLE_NAME = "logs";

        public SQLDepedencyAdapter()
        {
            Listener = new SQLDepedency(Configuration.GetValue<string>("ConnectionStrings:Default"), DATABASE_NAME, DATABASE_TABLE_NAME);
            Listener.Start();
        }

        public SQLDepedencyAdapter ListenChanges(Action<EventLog> onInsert)
        {
            OnInsert = onInsert;
            Listener.TableChanged += HandleChange;

            return this;
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

        private EventLog? CastRow(XElement element) =>
            (EventLog) new XmlSerializer(element.GetType()).Deserialize(element.CreateReader())!;

        public void Dispose() =>
            Listener.Stop();
    }
}
