using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Hooks.Models
{
    public class WebHookSubscriber
    {
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
