using Microsoft.Extensions.Logging;
using Seq.Api;
using Seq.Api.Model.Events;
using SeqNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeqNotification.Models.Extension;

namespace SeqNotification.Services
{
    public class SeqClient
    {
        public readonly int EXCEPTION_LIMIT = 120;
        public readonly string APPLICATION_NAME = "ApplicationName";

        public async Task<List<EventEntity>> GetLastDayLogs()
        {
            return await GetLogsByDate(DateTime.Now.AddDays(-1), DateTime.Now);
        }

        public List<ExceptionEvent> EventEntityToExceptionEventList(List<EventEntity> events)
        {
            return events.Where(@event => @event.Properties.Any(property => property.Name.Equals(APPLICATION_NAME)))
                .Select(@event => new ExceptionEvent {
                    Id = @event.Id,
                    Exception = @event.Exception.Substring(0, Math.Min(EXCEPTION_LIMIT, @event.Exception.Length)),
                    ApplicationName = @event.Properties?.FirstOrDefault(property => property.Name.Equals(APPLICATION_NAME))?.Value?.ToString()
                }).ToList();
        }

        private async Task<List<EventEntity>> GetLogsByDate(DateTime from, DateTime to)
        {
            return await (await GetConnection()).Events.ListAsync(fromDateUtc: from, toDateUtc: to);
        }

        private async Task<SeqConnection> GetConnection()
        {
            SeqConnection connection = new SeqConnection("http://localhost:80");
            await connection.Users.LoginAsync("admin", "password");

            return connection;
        }

    }
}
