using Seq.Api;
using Seq.Api.Model.Events;
using SEQ.Models;

namespace SEQ
{
    public class SeqClient
    {
        public async Task<List<EventEntity>> GetLastDayLogs() =>
            await GetLogsByDate(DateTime.Now.AddDays(-1), DateTime.Now);

        public List<ExceptionEvent> EventEntityToExceptionEventList(List<EventEntity> events)
        {
            return events.Where(@event => @event.Properties.Any(property => property.Name.Equals(Configuration.APPLICATION_NAME)))
                .Select(@event => new ExceptionEvent
                {
                    Id = @event.Id,
                    Exception = @event.Exception.Substring(0, Math.Min(Configuration.EXCEPTION_LIMIT, @event.Exception.Length)),
                    ApplicationName = @event.Properties?.FirstOrDefault(property => property.Name.Equals(Configuration.APPLICATION_NAME))?.Value?.ToString()
                }).ToList();
        }

        private async Task<List<EventEntity>> GetLogsByDate(DateTime from, DateTime to) =>
            await (await GetConnection()).Events.ListAsync(fromDateUtc: from, toDateUtc: to);

        private async Task<SeqConnection> GetConnection()
        {
            SeqConnection connection = new SeqConnection("");
            await connection.Users.LoginAsync("admin", "password");

            return connection;
        }

    }
}
