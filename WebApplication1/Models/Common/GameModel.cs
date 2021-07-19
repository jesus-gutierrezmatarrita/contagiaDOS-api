using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContagiaDOS_API.Models.Common
{
    public class GameModel
    {
        public string GameId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
