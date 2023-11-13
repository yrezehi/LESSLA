using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Hooks.Models.Enums;

namespace Core.Hooks.Models.DTO
{
    public class HookSubscribeRequestDTO
    {
        public string Email { get; set; }
        public IEnumerable<WebHookEvent> Events { get; set; }
    }
}
