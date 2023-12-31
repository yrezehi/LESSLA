﻿using Core.Models.DTO;
using Core.Models.Serilog;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;

namespace Core.Services
{
    public class EventLogsService : ServiceBase<EventLog>
    {
        public EventLogsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<EventLog> Live() =>
            new List<EventLog>();

        public async Task<PaginateDTO<EventLog>> History(int page) =>
            await this.Paginate(page);
    }
}
