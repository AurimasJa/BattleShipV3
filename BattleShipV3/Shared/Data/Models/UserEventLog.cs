using BattleShipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Shared.Data.Models
{
    public class UserEventLog
    {
        public User User { get; set; }
        public DateTime EventDateTime { get; set; }
        public UserEvent UserEvent { get; set; }
    }
}
