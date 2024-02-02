using Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Health
{
    public class HealthCheckLogDashboard
    {
        public int RegistredApplications { get; set; } = 0;
        public int FailedChecksToday { get; set; } = 0;
        public int Downtime { get; set; } = 0;

        public PaginateDTO<HealthCheckLog> Logs { get; set; } = new PaginateDTO<HealthCheckLog>();

        public static HealthCheckLogDashboard Create() =>
            new();

        public HealthCheckLogDashboard WithRegistredApplications(int count)
        {
            RegistredApplications = count;
            return this;
        }

        public HealthCheckLogDashboard WithFailedChecksToday(int count)
        {
            FailedChecksToday = count;
            return this;
        }

        public HealthCheckLogDashboard WithDowntime(int count)
        {
            Downtime = count;
            return this;
        }

        public HealthCheckLogDashboard WithLogs(PaginateDTO<HealthCheckLog> logs)
        {
            Logs = logs;
            return this;
        }
    }
}
