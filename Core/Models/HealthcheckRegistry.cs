using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class HealthcheckRegistry
    {
        public string ApplicationName { get; set; }
        public int MinutesInterval { get; set; } = 60;
        public string Endpoint { get; set; }
    }
}
